using System.Text.Json;
using System.Threading.Tasks;
using Shared.Models;

namespace DatabaseAccess.DataAccess.Interfaces
{
    public interface IStreamData
    {
        Task<JsonElement> GetAll(bool isActive);
        Task<JsonElement> Get(int id);
        Task<CreatedRow> Insert(Stream stream);
        Task Update(int id, Stream stream);
    }
}