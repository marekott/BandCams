using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using QueueHelper.Interfaces;
using RestAPI.Configuration;
using Shared.Configuration;

namespace QueueHelper.UnitTests
{
    [TestFixture]
    public class ServiceCollectionExtensionTests
    {
        [Test]
        public void AddQueueHelperLibraryRegisters1ServicesTest()
        {
            // arrange
            var expected = 1;
            var services = new ServiceCollection();

            // act
            var actual = services.AddQueueHelperLibrary();

            // assert
            Assert.AreEqual(expected, actual.Count);
        }

        [Test]
        public void AddQueueHelperLibraryRegistersIQueueManagerTest()
        {
            // arrange
            var configuration = new ConfigurationBuilder().Build();
            var services = new ServiceCollection();
            services.AddSingleton<IConfiguration>(configuration);
            services.AddSingleton<IConfigProvider, ConfigProvider>();

            // act
            var actual = services.AddQueueHelperLibrary().BuildServiceProvider().GetService<IQueueManager>();

            // assert
            Assert.IsNotNull(actual);
        }
    }
}
