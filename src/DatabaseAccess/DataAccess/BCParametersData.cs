using System.Data;
using System.Text.Json;
using System.Threading.Tasks;
using Dapper;
using Shared.Configuration;
using DatabaseAccess.DataAccess.Interfaces;
using DatabaseAccess.DataAccess.Internal;
using DatabaseAccess.Helpers;
using Shared.Models;
// ReSharper disable InconsistentNaming

namespace DatabaseAccess.DataAccess
{
    // ReSharper disable once InconsistentNaming
    public class BCParametersData : IBCParametersData
    {
        private readonly ISqlDataAccess _sqlDataAccess;
        private readonly string _dbConnectionString;

        public BCParametersData(ISqlDataAccess sqlDataAccess, IConfigProvider configProvider)
        {
            _sqlDataAccess = sqlDataAccess;
            _dbConnectionString = configProvider.GetConnectionString(Application.BandCamsDb);
        }

        public async Task<JsonElement> GetAll()
        {
            return await _sqlDataAccess.ExecuteStoredProcedureAsync(StoredProcedures.SpBcParameterGetAll, _dbConnectionString, new { });
        }

        public async Task<JsonElement> Get(int id)
        {
            return await _sqlDataAccess.ExecuteStoredProcedureAsync(StoredProcedures.SpBcParameterGet, _dbConnectionString,
                new { Id = id });
        }

        public async Task<CreatedRow> Insert(BCParameter bcParameter)
        {
            var parameters = CreateDynamicBCParameterForInsert(bcParameter);

            await _sqlDataAccess.ExecuteStoredProcedureAsync(StoredProcedures.SpBcParameterInsert, _dbConnectionString,
                parameters);

            return new CreatedRow
            {
                Id = parameters.Get<int>("@Id")
            };
        }

        private static DynamicParameters CreateDynamicBCParameterForInsert(BCParameter bcParameter)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", 0, DbType.Int32, ParameterDirection.Output);
            AddBCParameterProperties(parameters, bcParameter);

            return parameters;
        }

        public async Task Update(int id, BCParameter bcParameter)
        {
            var parameters = CreateDynamicBCParameterForUpdate(id, bcParameter);

            await _sqlDataAccess.ExecuteStoredProcedureAsync(StoredProcedures.SpBcParameterUpdate, _dbConnectionString,
                parameters);
        }

        private static DynamicParameters CreateDynamicBCParameterForUpdate(int id, BCParameter bcParameter)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            AddBCParameterProperties(parameters, bcParameter);

            return parameters;
        }

        private static void AddBCParameterProperties(DynamicParameters parameters, BCParameter bcParameter)
        {
            parameters.Add("@Key", bcParameter.Key);
            parameters.Add("@Value", bcParameter.Value);
        }
    }
}
