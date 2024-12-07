using System.Diagnostics;
using System.IO;
using System.Net;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json;
using HttpListener = System.Net.HttpListener;

namespace FilePicker
{
    public class FilePicker : IFilePicker
    {
        private readonly Serilog.ILogger _logger;

        public FilePicker(Serilog.ILogger logger)
        {
            _logger = logger;
        }

        private static bool TryBindListenerOnFreePort(out HttpListener httpListener, out int port)
        {
            // IANA suggested range for dynamic or private ports
            const int minPort = 49215;
            const int maxPort = 65535;

            for (port = minPort; port < maxPort; port++)
            {
                httpListener = new HttpListener();
                httpListener.Prefixes.Add("http://localhost:" + port + "/");
                try
                {
                    httpListener.Start();
                    return true;
                }
                catch (HttpListenerException)
                {
                    // nothing to do here -- the listener disposes itself when Start throws
                }
            }

            port = 0;
            httpListener = null;
            return false;
        }

        public async Task<FilePick> SelectFile(FilePickerOptions options, CancellationToken cancellationToken)
        {
            int port;
            HttpListener listener;
            if (!TryBindListenerOnFreePort(out listener, out port))
            {
                throw new FilePickerException("No available ports");
            }

            using (listener)
            {
                var uri = "http://localhost:" + port + "/";
                _logger.Debug("Listening for '{uri}'...", uri);
                var _ = await Task.Run(() => Process.Start(uri), cancellationToken);

                while (!cancellationToken.IsCancellationRequested)
                {
                    HttpListenerContext context;
                    try
                    {
                        using (var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
                        {

                            var contextAsync = listener.GetContextAsync();
                            // Allows us to cancel the GetContextAsync call despite its lack of cancellation token support
                            var completed = await Task.WhenAny(contextAsync, Task.Delay(Timeout.Infinite, cts.Token));
                            if (completed != contextAsync)
                            {
                                return null;
                            }

                            cts.Cancel(); // cancel the infinite task.Delay
                            context = contextAsync.Result;
                        }
                    }
                    catch (HttpListenerException ex)
                    {
                        _logger.Error(ex, "Failed to get context: {0}", ex.ErrorCode);
                        throw new FilePickerException("Http listener failed to open", ex);
                    }

                    if (context.Request.HttpMethod == "POST")
                    {
                        return await HandlePost(context);
                    }

                    await HandleGet(options, context);
                }
            }

            return null;
        }

        private async Task HandleGet(FilePickerOptions viewModel, HttpListenerContext context)
        {
            string html;
            using (var stream = Assembly.GetExecutingAssembly()
                       .GetManifestResourceStream("FilePicker.FilePickerView.html"))
            {
                if (stream == null)
                {
                    throw new FilePickerException("File picker view could not be loaded");
                }

                using (var reader = new StreamReader(stream))
                {
                    html = await reader.ReadToEndAsync();
                }
            }

            html = html.Replace("@AccessToken", viewModel.AccessToken)
                .Replace("@AppId", viewModel.AppId)
                .Replace("@GDrivePickerApiKey", viewModel.GDrivePickerApiKey);

            context.Response.KeepAlive = false;
            using (StreamWriter streamWriter = new StreamWriter(context.Response.OutputStream))
            {
                await streamWriter.WriteAsync(html);
            }

            _logger.Debug("File picker page returned to browser.");
        }

        private async Task<FilePick> HandlePost(HttpListenerContext context)
        {
            string input;
            using (var sr = new StreamReader(context.Request.InputStream))
            {
                input = await sr.ReadToEndAsync();
            }

            FilePick pick;
            try
            {
                pick = JsonConvert.DeserializeObject<FilePick>(input);
            }
            catch (JsonSerializationException ex)
            {
                _logger.Error(ex, "Failed to deserialize file pick {response}", input);
                throw new FilePickerException("Invalid post request submitted to listener", ex);
            }

            if (pick == null)
            {
                throw new FilePickerException("Invalid post request submitted to listener")
                {
                    Data = { { "Payload", input } }
                };
            }

            _logger.Debug("Picked {0}, {1}", pick.Id, pick.Name);
            context.Response.StatusCode = 200;
            context.Response.Close();

            return pick;
        }
    }
}
