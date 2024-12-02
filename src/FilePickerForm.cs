using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompileTimeConfigPublicMembers;
using FilePicker;
using KeePass.Plugins;
using Serilog;

namespace KPSyncForDrive
{
    internal class FilePickerForm
    {
        private readonly IPluginHost _mHost;
        private readonly IFilePicker _filePicker;
        private readonly ILogger _logger;
        private readonly DatabaseContext _databaseContext;
        private readonly ICompileTimeConfigAccessor<PluginStaticConfiguration> _compileTimeConfigAccessor;

        internal FilePickerForm(IPluginHost host,
            IFilePicker filePicker, ILogger logger, DatabaseContext databaseContext, ICompileTimeConfigAccessor<PluginStaticConfiguration> compileTimeConfigAccessor)
        {
            _filePicker = filePicker;
            _logger = logger;
            _databaseContext = databaseContext;
            _compileTimeConfigAccessor = compileTimeConfigAccessor;
            _mHost = host;
        }

        public async Task<FilePick> SelectFile(string accessToken, SyncConfiguration syncConfig, CancellationToken cancellationToken)
        {
            using (CancellationTokenSource cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
            {
                return await ShowFilePickForm(accessToken, syncConfig, cts);
            }
        }

        private async Task<FilePick> ShowFilePickForm(string accessToken, SyncConfiguration syncConfig,
            CancellationTokenSource cts)
        {
            using (AuthWaitOrCancel form = new AuthWaitOrCancel(_mHost, _databaseContext, syncConfig as EntryConfiguration))
            {
                // Wait for dialog.
                form.FormClosing += (o, e) =>
                {
                    _logger.Debug("Closing");
                    cts.Cancel();
                };

                DialogResult dr = KPSyncForDriveExt.ShowModalDialogAndDestroy(form);

                var pick = await _filePicker.SelectFile(new FilePickerOptions
                {
                    AccessToken = accessToken,
                    AppId =  _compileTimeConfigAccessor.GetConfig().GoogleDrivePickerAppId,
                    GDrivePickerApiKey = _compileTimeConfigAccessor.GetConfig().DriveFilePickerPublicApiKey
                }, cts.Token);

                _logger.Debug("Wait dialog returned '{0}'.", dr.ToString("G"));

                _logger.Debug("Attempting to close waiter dialog.");
                form.Invoke(new MethodInvoker(form.Close));

                _logger.Debug("Activating KP main window.");
                _mHost.MainWindow.BeginInvoke(new MethodInvoker(_mHost.MainWindow.Activate));

                return pick;
            }
        }
    }
}
