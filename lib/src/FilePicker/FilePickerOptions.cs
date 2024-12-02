namespace FilePicker;

public record FilePickerOptions
{
    public string GDrivePickerApiKey { get; set; } = "";
    public string AppId { get; set; } = "";
    public string AccessToken { get; set; } = "";
}
