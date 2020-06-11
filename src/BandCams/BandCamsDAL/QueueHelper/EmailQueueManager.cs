using System.Threading.Tasks;
using Microsoft.Azure.Storage;
using Microsoft.Azure.Storage.Queue;
using Newtonsoft.Json;
using QueueHelper.Interfaces;
using Shared.Configuration;
using Shared.Models;

namespace QueueHelper
{
    public class EmailQueueManager : IQueueManager
    {
        private readonly IConfigProvider _configProvider;

        public EmailQueueManager(IConfigProvider configProvider)
        {
            _configProvider = configProvider;
        }

        public async Task AddToQueueAsync(EmailQueueMessage messageModel)
        {
            var storageAccount = CloudStorageAccount.Parse(_configProvider.GetConnectionString(Application.BandCamsStorage));
            var cloudQueue = storageAccount.CreateCloudQueueClient().GetQueueReference(_configProvider.GetQueueName(Queue.EmailQueue));

            var message = new CloudQueueMessage(JsonConvert.SerializeObject(messageModel));
            await cloudQueue.AddMessageAsync(message);
        }
    }
}
