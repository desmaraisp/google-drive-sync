using System.Threading;
using System.Threading.Tasks;

namespace FilePicker
{
    public interface IFilePicker
    {
        Task<FilePick> SelectFile(FilePickerOptions options, CancellationToken cancellationToken);
    }


    public class FilePick
    {
        public string Id { get; set; }
        public string Name { get; set; }
    }
}
