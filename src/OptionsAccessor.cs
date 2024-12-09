using CompileTimeConfigPublicMembers;

namespace KPSyncForDrive
{
    [GenerateConfigAccessor(typeof(PluginStaticConfiguration))]
    public partial class OptionsAccessor
    {
    }

    public class PluginStaticConfiguration
    {
        public string ClientId { get; set; }
        public string PublicClientSecret { get; set; }
        public string DriveFilePickerPublicApiKey { get; set; }
        public string GoogleDrivePickerAppId { get; set; }
        public string UpdateUrl { get; set; }
    }
}
