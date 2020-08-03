using System.Text.Json;
using System.Threading.Tasks;

namespace DatabaseAccess.DataAccess.Internal
{
    public interface ISqlDataAccess
    {
        Task<JsonElement> ExecuteStoredProcedureAsync<T>(string procedure, string connectionString, T parameters);
    }
}