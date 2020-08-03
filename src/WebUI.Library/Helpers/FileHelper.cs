using Microsoft.AspNetCore.Http;
using System.IO;
using System.Threading.Tasks;

namespace WebUI.Library.Helpers
{
    public class FileHelper : IFileHelper
    {
        public async Task<byte[]> ConvertToByteArrayAsync(IFormFile file)
        {
            await using var memoryStream = new MemoryStream();
            await file.CopyToAsync(memoryStream);

            return memoryStream.ToArray();
        }
    }
}
