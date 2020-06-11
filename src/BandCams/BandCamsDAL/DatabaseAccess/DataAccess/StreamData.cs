using System.Data;
using System.Text.Json;
using System.Threading.Tasks;
using Dapper;
using Shared.Configuration;
using DatabaseAccess.DataAccess.Interfaces;
using DatabaseAccess.DataAccess.Internal;
using DatabaseAccess.Helpers;
using Shared.Models;

namespace DatabaseAccess.DataAccess
{
    public class StreamData : IStreamData
    {
        private readonly ISqlDataAccess _sqlDataAccess;
        private readonly string _dbConnectionString;

        public StreamData(ISqlDataAccess sqlDataAccess, IConfigProvider configProvider)
        {
            _sqlDataAccess = sqlDataAccess;
            _dbConnectionString = configProvider.GetConnectionString(Application.BandCamsDb);
        }

        public async Task<JsonElement> GetAll(bool isActive)
        {
            return await _sqlDataAccess.ExecuteStoredProcedureAsync(StoredProcedures.SpStreamGetAll, _dbConnectionString, new { isActive });
        }

        public async Task<JsonElement> Get(int id)
        {
            return await _sqlDataAccess.ExecuteStoredProcedureAsync(StoredProcedures.SpStreamGet, _dbConnectionString,
                new { Id = id });
        }

        public async Task<CreatedRow> Insert(Stream stream)
        {
            var parameters = CreateDynamicStreamForInsert(stream);

            await _sqlDataAccess.ExecuteStoredProcedureAsync(StoredProcedures.SpStreamInsert, _dbConnectionString,
                parameters);

            return new CreatedRow
            {
                Id = parameters.Get<int>("@Id")
            };
        }

        private static DynamicParameters CreateDynamicStreamForInsert(Stream stream)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", 0, DbType.Int32, ParameterDirection.Output);
            AddStreamProperties(parameters, stream);

            return parameters;
        }

        public async Task Update(int id, Stream stream)
        {
            var parameters = CreateDynamicStreamForUpdate(id, stream);

            await _sqlDataAccess.ExecuteStoredProcedureAsync(StoredProcedures.SpStreamUpdate, _dbConnectionString,
                parameters);
        }

        private static DynamicParameters CreateDynamicStreamForUpdate(int id, Stream stream)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            AddStreamProperties(parameters, stream);

            return parameters;
        }

        private static void AddStreamProperties(DynamicParameters parameters, Stream stream)
        {
            parameters.Add("@Link", stream.Link);
            parameters.Add("@IsActive", stream.IsActive);
        }
    }
}
