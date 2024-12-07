using System;
using System.Drawing;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CompileTimeConfigPublicMembers;
using FilePicker;
using KeePass;
using KeePass.Plugins;
using Microsoft.CodeAnalysis;
using Serilog;

namespace KPSyncForDrive
{
    public class FilePickerForm
    {
        private readonly IPluginHost _mHost;
        private readonly IFilePicker _filePicker;
        private readonly ILogger _logger;
        private readonly IDatabaseContextAccessor _databaseContextAccessor;
        private readonly ICompileTimeConfigAccessor<PluginStaticConfiguration> _compileTimeConfigAccessor;

        public FilePickerForm(IPluginHost host,
            IFilePicker filePicker,
            ILogger logger,
            IDatabaseContextAccessor databaseContextAccessor,
            ICompileTimeConfigAccessor<PluginStaticConfiguration> compileTimeConfigAccessor)
        {
            _filePicker = filePicker;
            _logger = logger;
            _databaseContextAccessor = databaseContextAccessor;
            _compileTimeConfigAccessor = compileTimeConfigAccessor;
            _mHost = host;
        }

        public async Task<Optional<FilePick>> SelectFile(string accessToken, SyncConfiguration syncConfig, CancellationToken cancellationToken)
        {
            using (CancellationTokenSource cts = CancellationTokenSource.CreateLinkedTokenSource(cancellationToken))
            {
                cts.CancelAfter(TimeSpan.FromMinutes(5));
                return await ShowFilePickForm(accessToken, syncConfig, cts);
            }
        }

        private async Task<Optional<FilePick>> ShowFilePickForm(string accessToken,
            SyncConfiguration syncConfig,
            CancellationTokenSource cts)
        {
            using (AuthWaitOrCancel form = new AuthWaitOrCancel(_mHost, _databaseContextAccessor.GetDatabaseContext(), syncConfig as EntryConfiguration))
            {
                form.StartPosition = FormStartPosition.CenterParent;
                FilePick res;
                var dialogTask = form.ShowDialogAsync(cts);
                try
                {
                    res =  await _filePicker.SelectFile(new FilePickerOptions
                    {
                        AccessToken = accessToken,
                        AppId = _compileTimeConfigAccessor.GetConfig().GoogleDrivePickerAppId,
                        GDrivePickerApiKey = _compileTimeConfigAccessor.GetConfig().DriveFilePickerPublicApiKey
                    }, cts.Token);
                    _mHost.MainWindow.BeginInvoke(new MethodInvoker(_mHost.MainWindow.Activate));
                }
                catch(FilePickerException ex){
                    _logger.Error(ex, "An error occured during file picker form, returning without authorizing file");
                    return null;
                }
                finally
                {
                    form.Close();
                }

                await dialogTask;
                return res;
            }
        }
    }
}
