using System;
using System.Threading.Tasks;

namespace DatabaseAccess.DataAccess.Interfaces
{
    public interface IStoredProceduresData
    {
        Task CloseOldStreams(DateTime? dateTimeNowUtc, int? olderThanInMinutes);
    }
}