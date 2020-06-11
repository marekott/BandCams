using Microsoft.Extensions.DependencyInjection;
using QueueHelper.Interfaces;

namespace QueueHelper
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddQueueHelperLibrary(this IServiceCollection services)
        {
            services.AddScoped<IQueueManager, EmailQueueManager>();

            return services;
        }
    }
}
