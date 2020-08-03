using System.Text.Json;
using System.Threading.Tasks;
using Shared.Models;

namespace DatabaseAccess.DataAccess.Interfaces
{
    // ReSharper disable once InconsistentNaming
    public interface IBCParametersData
    {
        Task<JsonElement> GetAll();
        Task<JsonElement> Get(int id);
        Task<CreatedRow> Insert(BCParameter bcParameter);
        Task Update(int id, BCParameter bcParameter);
    }
}