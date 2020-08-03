using System;
using System.Threading.Tasks;
using DatabaseAccess.DataAccess.Interfaces;
using DatabaseAccess.DataAccess.Internal;
using DatabaseAccess.Helpers;
using Shared.Configuration;

namespace DatabaseAccess.DataAccess
{
    public class StoredProceduresData : IStoredProceduresData
    {
        private readonly ISqlDataAccess _sqlDataAccess;
        private readonly string _dbConnectionString;

        public StoredProceduresData(ISqlDataAccess sqlDataAccess, IConfigProvider configProvider)
        {
            _sqlDataAccess = sqlDataAccess;
            _dbConnectionString = configProvider.GetConnectionString(Application.BandCamsDb);
        }

        public async Task CloseOldStreams(DateTime? dateTimeNowUtc, int? olderThanInMinutes)
        {
            await _sqlDataAccess.ExecuteStoredProcedureAsync(StoredProcedures.SpCloseOldStreams, _dbConnectionString,
                new {dateTimeNowUtc, olderThanInMinutes});
        }
    }
}
