using DatabaseAccess.DataAccess;
using DatabaseAccess.DataAccess.Interfaces;
using DatabaseAccess.DataAccess.Internal;
using Microsoft.Extensions.DependencyInjection;

namespace DatabaseAccess
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddDatabaseAccessLibrary(this IServiceCollection services)
        {
            services.AddScoped<ISqlDataAccess, SqlDataAccess>();
            services.AddScoped<IOnlineEventData, OnlineEventData>();
            services.AddScoped<IStreamData, StreamData>();
            services.AddScoped<IBCParametersData, BCParametersData>();
            services.AddScoped<IStoredProceduresData, StoredProceduresData>();
            services.AddScoped<IEmailTemplatesData, EmailTemplatesData>();

            return services;
        }
    }
}
