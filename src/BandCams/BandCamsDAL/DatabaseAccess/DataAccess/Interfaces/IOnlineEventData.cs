using System;
using System.Text.Json;
using System.Threading.Tasks;
using Shared.Models;

namespace DatabaseAccess.DataAccess.Interfaces
{
    public interface IOnlineEventData
    {
        Task<JsonElement> GetAll(DateTime? fromDate, DateTime? toDate);
        Task<JsonElement> Get(int id);
        Task<CreatedRow> Insert(OnlineEvent onlineEvent);
        Task Update(int id, OnlineEvent onlineEvent);
    }
}