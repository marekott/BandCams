using System;
using Autofac.Extras.Moq;
using Shared.Configuration;
using Microsoft.Extensions.Configuration;
using Moq;
using NUnit.Framework;
using RestAPI.Configuration;

namespace RestAPI.UnitTests.Configuration
{
    [TestFixture]
    public class ConfigProviderTests
    {
        [Test]
        public void GetConnectionStringBandCamsDbTest()
        {
            // arrange
            const string expected = "TestConnectionString";
            var configurationSectionStub = new Mock<IConfigurationSection>();
            configurationSectionStub.Setup(x => x[It.IsAny<string>()]).Returns(expected);
            var configurationStub = new Mock<IConfiguration>();
            configurationStub.Setup(x => x.GetSection(It.IsAny<string>())).Returns(configurationSectionStub.Object);
            var configProvider = new ConfigProvider(configurationStub.Object);

            // act
            var actual = configProvider.GetConnectionString(Application.BandCamsDb);

            // assert
            StringAssert.AreEqualIgnoringCase(expected, actual);
        }

        [Test]
        public void GetConnectionStringBandCamsStorageTest()
        {
            // arrange
            const string expected = "TestConnectionString";
            var configurationSectionStub = new Mock<IConfigurationSection>();
            configurationSectionStub.Setup(x => x[It.IsAny<string>()]).Returns(expected);
            var configurationStub = new Mock<IConfiguration>();
            configurationStub.Setup(x => x.GetSection(It.IsAny<string>())).Returns(configurationSectionStub.Object);
            var configProvider = new ConfigProvider(configurationStub.Object);

            // act
            var actual = configProvider.GetConnectionString(Application.BandCamsStorage);

            // assert
            StringAssert.AreEqualIgnoringCase(expected, actual);
        }

        [Test]
        public void GetConnectionStringThrowsArgumentOutOfRangeExceptionIfInvalidEnumTest()
        {
            // arrange
            using var mock = AutoMock.GetStrict();
            var configProvider = mock.Create<ConfigProvider>();

            // act
            // assert
            Assert.Throws<ArgumentOutOfRangeException>(() => configProvider.GetConnectionString((Application) 100));
        }

        [Test]
        public void GetQueueNameEmailQueueTest()
        {
            // arrange
            const string expected = "TestQueueName";
            var configurationSectionStub = new Mock<IConfigurationSection>();
            configurationSectionStub.Setup(x => x[It.IsAny<string>()]).Returns(expected);
            var configurationStub = new Mock<IConfiguration>();
            configurationStub.Setup(x => x.GetSection(It.IsAny<string>())).Returns(configurationSectionStub.Object);
            var configProvider = new ConfigProvider(configurationStub.Object);

            // act
            var actual = configProvider.GetQueueName(Queue.EmailQueue);

            // assert
            StringAssert.AreEqualIgnoringCase(expected, actual);
        }

        [Test]
        public void GetQueueNameThrowsArgumentOutOfRangeExceptionIfInvalidEnumTest()
        {
            // arrange
            using var mock = AutoMock.GetStrict();
            var configProvider = mock.Create<ConfigProvider>();

            // act
            // assert
            Assert.Throws<ArgumentOutOfRangeException>(() => configProvider.GetQueueName((Queue) 100));
        }
    }
}
