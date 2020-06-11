using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace WebUI.Library.Helpers
{
    public interface IFileHelper
    {
        Task<byte[]> ConvertToByteArrayAsync(IFormFile file);
    }
}