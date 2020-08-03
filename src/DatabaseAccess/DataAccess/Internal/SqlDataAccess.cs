using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Dapper;

namespace DatabaseAccess.DataAccess.Internal
{
    public class SqlDataAccess : ISqlDataAccess
    {
        public async Task<JsonElement> ExecuteStoredProcedureAsync<T>(string procedure, string connectionString, T parameters)
        {
            await using var connection = new SqlConnection(connectionString); //TODO inicjalizację wydzielić do factorki i wtedy testy jednostkowe?

            var query = await connection.QueryAsync<string>(procedure, parameters,
                commandType: CommandType.StoredProcedure);

            return query.Any() ? JsonDocument.Parse(string.Join("", query)).RootElement: JsonDocument.Parse("[]").RootElement; //TODO przeanalizować
        }
    }
}