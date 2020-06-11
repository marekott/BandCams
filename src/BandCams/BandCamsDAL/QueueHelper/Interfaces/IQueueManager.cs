using System.Threading.Tasks;
using Shared.Models;

namespace QueueHelper.Interfaces
{
    public interface IQueueManager
    {
        Task AddToQueueAsync(EmailQueueMessage messageModel);
    }
}