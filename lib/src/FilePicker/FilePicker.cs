using System.Diagnostics;
using System.Net;
using Newtonsoft.Json;
using RazorLight;

namespace FilePicker;

public class FilePicker : IFilePicker
{
    private readonly Serilog.ILogger _logger;
    private readonly RazorLightEngine _razorEngine;
    private static readonly int[] AllowedPorts = [50100];

    public FilePicker(Serilog.ILogger logger, RazorLightEngine razorEngine)
    {
        _logger = logger;
        _razorEngine = razorEngine;
    }

    private static int GetRandomAllowedPort()
    {
        var r = new Random();
        return AllowedPorts[r.Next(AllowedPorts.Length)];
    }

    public async Task<FilePick> SelectFile(FilePickerOptions options, CancellationToken cancellationToken)
    {
        using var listener = new HttpListener();

        using var cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken);
        cts.CancelAfter(TimeSpan.FromMinutes(5)); // Give 5 minutes or otherwise cancel.

        var uri = $"http://localhost:{GetRandomAllowedPort()}/";
        listener.Prefixes.Add(uri);
        try
        {
            listener.Start();
        }
        catch (HttpListenerException ex)
        {
            _logger.Error("Failed to start HttpListener with error code: {errorCode}", ex.ErrorCode);
            throw new FilePickerException("Http listener failed to open", ex);
        }

        _logger.Debug("Listening for '{uri}'...", uri);
        Process.Start(uri);

        while (!cts.Token.IsCancellationRequested)
        {
            HttpListenerContext context;
            try
            {
                context = await listener.GetContextAsync();
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

        throw new FilePickerCancelledException("File picker exited without result");
    }

    private async Task HandleGet(FilePickerOptions viewModel, HttpListenerContext context)
    {
        string html = await _razorEngine.CompileRenderAsync("EmailTemplates.Body", viewModel);

        context.Response.KeepAlive = false;
        using StreamWriter streamWriter = new StreamWriter(context.Response.OutputStream);
        await streamWriter.WriteAsync(html);
        _logger.Debug("File picker page returned to browser.");
    }

    private async Task<FilePick> HandlePost(HttpListenerContext context)
    {
        using var sr = new StreamReader(context.Request.InputStream);
        var input = await sr.ReadToEndAsync();
        try
        {
            var pick = JsonConvert.DeserializeObject<FilePick>(input);
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
        catch (JsonSerializationException ex)
        {
            _logger.Error(ex, "Failed to deserialize file pick {response}", input);
            throw new FilePickerException("Invalid post request submitted to listener", ex);
        }
    }
}
