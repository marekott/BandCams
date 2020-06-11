using System;
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
    public class OnlineEventData : IOnlineEventData
    {
        private readonly ISqlDataAccess _sqlDataAccess;
        private readonly string _dbConnectionString;

        public OnlineEventData(ISqlDataAccess sqlDataAccess, IConfigProvider configProvider)
        {
            _sqlDataAccess = sqlDataAccess;
            _dbConnectionString = configProvider.GetConnectionString(Application.BandCamsDb);
        }

        public async Task<JsonElement> GetAll(DateTime? fromDate, DateTime? toDate)
        {
            return await _sqlDataAccess.ExecuteStoredProcedureAsync(StoredProcedures.SpOnlineEventGetAll, _dbConnectionString, new { fromDate, toDate });
        }

        public async Task<JsonElement> Get(int id)
        {
            return await _sqlDataAccess.ExecuteStoredProcedureAsync(StoredProcedures.SpOnlineEventGet, _dbConnectionString,
                new { Id = id });
        }

        public async Task<CreatedRow> Insert(OnlineEvent onlineEvent)
        {
            var parameters = CreateDynamicOnlineEventForInsert(onlineEvent);

            await _sqlDataAccess.ExecuteStoredProcedureAsync(StoredProcedures.SpOnlineEventInsert, _dbConnectionString,
                parameters);

            return new CreatedRow
            {
                Id = parameters.Get<int>("@Id")
            };
        }

        private static DynamicParameters CreateDynamicOnlineEventForInsert(OnlineEvent onlineEvent)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", 0, DbType.Int32, ParameterDirection.Output);
            AddOnlineEventProperties(parameters, onlineEvent);

            return parameters;
        }

        public async Task Update(int id, OnlineEvent onlineEvent)
        {
            var parameters = CreateDynamicOnlineEventForUpdate(id, onlineEvent);

            await _sqlDataAccess.ExecuteStoredProcedureAsync(StoredProcedures.SpOnlineEventUpdate, _dbConnectionString,
                parameters);
        }

        private static DynamicParameters CreateDynamicOnlineEventForUpdate(int id, OnlineEvent onlineEvent)
        {
            var parameters = new DynamicParameters();
            parameters.Add("@Id", id);
            AddOnlineEventProperties(parameters, onlineEvent);

            return parameters;
        }

        private static void AddOnlineEventProperties(DynamicParameters parameters, OnlineEvent onlineEvent)
        {
            parameters.Add("@Name", onlineEvent.Name);
            parameters.Add("@Description", onlineEvent.Description);
            parameters.Add("@StartDate", onlineEvent.StartDate);
            parameters.Add("@Organizer", onlineEvent.Organizer);
            parameters.Add("@ImageContent", onlineEvent.ImageContent);
        }
    }
}
