using System.IO;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Xunit;

namespace RestAPI.IntegrationTests.Controllers
{
    public class BaseController : IClassFixture<RestAPIFactory<Startup>>
    {
        protected readonly WebApplicationFactory<Startup> Factory;

        public BaseController(RestAPIFactory<Startup> factory)
        {
            Factory = factory;
        }

        protected WebApplicationFactory<Startup> GetFactory()
        {
            var projectDir = Directory.GetCurrentDirectory();
            var configPath = Path.Combine(projectDir, "appsettings.IntegrationTests.json");

            return Factory.WithWebHostBuilder(builder =>
            {
                builder.UseSolutionRelativeContentRoot($"BandCamsDAL\\{nameof(RestAPI)}");

                builder.ConfigureAppConfiguration((context, conf) =>
                {
                    conf.AddJsonFile(configPath);
                });

                builder.ConfigureTestServices(services =>
                {
                    services.AddMvc().AddApplicationPart(typeof(Startup).Assembly);
                });
            });
        }
    }
}
