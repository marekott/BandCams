using Autofac.Extras.Moq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using Shared.Configuration;

namespace RestAPI.UnitTests
{
    [TestFixture]
    public class StartupTests
    {
        [Test]
        public void ConfigureServicesRegistersIConfigProviderTest()
        {
            // assert
            using var mock = AutoMock.GetStrict();
            var services = new ServiceCollection();
            var configuration = new ConfigurationBuilder().Build();
            services.AddSingleton<IConfiguration>(configuration);
            var startup = mock.Create<Startup>();

            // arrange
            startup.ConfigureServices(services);
            var actual = services.BuildServiceProvider().GetService<IConfigProvider>();

            // act
            Assert.IsNotNull(actual);
        }
    }
}
