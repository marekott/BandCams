using System;
using Shared.Configuration;
using Microsoft.Extensions.Configuration;

namespace RestAPI.Configuration
{
    public class ConfigProvider : IConfigProvider
    {
        private readonly IConfiguration _config;

        public ConfigProvider(IConfiguration config)
        {
            _config = config;
        }

        public string GetConnectionString(Application application)
        {
            switch (application)
            {
                case Application.BandCamsDb:
                    return _config.GetConnectionString("BandCamsDB");

                case Application.BandCamsStorage:
                    return _config.GetConnectionString("BandCamsStorage");

                default:
                    throw new ArgumentOutOfRangeException(nameof(application), application, "Application does not exist");
            }
        }

        public string GetQueueName(Queue queue)
        {
            switch (queue)
            {
                case Queue.EmailQueue:
                    return _config.GetSection("Queues")["EmailQueue"];

                default:
                    throw new ArgumentOutOfRangeException(nameof(queue), queue, "Queue does not exist");
            }
        }
    }
}
