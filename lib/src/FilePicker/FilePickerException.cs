namespace FilePicker;

public class FilePickerException : Exception
{
    public FilePickerException(string message) : base(message) { }
    public FilePickerException(string message, Exception innerException) : base(message, innerException) { }
}


public class FilePickerCancelledException : FilePickerException
{
    public FilePickerCancelledException(string message) : base(message) { }
    public FilePickerCancelledException(string message, Exception innerException) : base(message, innerException) { }
}
