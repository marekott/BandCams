using System;
using System.Text.Json;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using Shared.Configuration;
using DatabaseAccess.DataAccess;
using DatabaseAccess.DataAccess.Internal;
using Moq;
using NUnit.Framework;
using Shared.Models;

namespace DatabaseAccess.UnitTests.DataAccess
{
    [TestFixture]
    public class OnlineEventDataTests
    {
        [Test]
        public async Task GetAllReturnsJsonElementTest()
        {
            // arrange
            using var mock = AutoMock.GetStrict();
            mock.Mock<ISqlDataAccess>()
                .Setup(x => x.ExecuteStoredProcedureAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<object>()))
                .Returns(Task.FromResult(new JsonElement()));
            mock.Mock<IConfigProvider>()
                .Setup(x => x.GetConnectionString(Application.BandCamsDb))
                .Returns("test");
            var onlineEventData = mock.Create<OnlineEventData>();

            // act
            var actual = await onlineEventData.GetAll(new DateTime(), new DateTime());

            // assert
            Assert.IsInstanceOf<JsonElement>(actual);
        }

        [Test]
        public async Task GetAllCallsOneQueryTest()
        {
            // arrange
            using var mock = AutoMock.GetStrict();
            mock.Mock<ISqlDataAccess>()
                .Setup(x => x.ExecuteStoredProcedureAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<object>()))
                .Returns(Task.FromResult(new JsonElement()));
            mock.Mock<IConfigProvider>()
                .Setup(x => x.GetConnectionString(Application.BandCamsDb))
                .Returns("test");
            var onlineEventData = mock.Create<OnlineEventData>();

            // act
            await onlineEventData.GetAll(new DateTime(), new DateTime());

            // assert
            mock.Mock<ISqlDataAccess>().Verify(x => x.ExecuteStoredProcedureAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<object>()), Times.Once);
        }

        [Test]
        public async Task GetReturnsJsonElementTest()
        {
            // arrange
            using var mock = AutoMock.GetStrict();
            mock.Mock<ISqlDataAccess>()
                .Setup(x => x.ExecuteStoredProcedureAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<object>()))
                .Returns(Task.FromResult(new JsonElement()));
            mock.Mock<IConfigProvider>()
                .Setup(x => x.GetConnectionString(Application.BandCamsDb))
                .Returns("test");
            var onlineEventData = mock.Create<OnlineEventData>();

            // act
            var actual = await onlineEventData.Get(1);

            // assert
            Assert.IsInstanceOf<JsonElement>(actual);
        }

        [Test]
        public async Task GetCallsOneQueryTest()
        {
            // arrange
            using var mock = AutoMock.GetStrict();
            mock.Mock<ISqlDataAccess>()
                .Setup(x => x.ExecuteStoredProcedureAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<object>()))
                .Returns(Task.FromResult(new JsonElement()));
            mock.Mock<IConfigProvider>()
                .Setup(x => x.GetConnectionString(Application.BandCamsDb))
                .Returns("test");
            var onlineEventData = mock.Create<OnlineEventData>();

            // act
            await onlineEventData.Get(1);

            // assert
            mock.Mock<ISqlDataAccess>().Verify(x => x.ExecuteStoredProcedureAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<object>()), Times.Once);
        }

        [Test]
        public async Task UpdateCallOneQueryTest()
        {
            // arrange
            using var mock = AutoMock.GetStrict();
            mock.Mock<ISqlDataAccess>()
                .Setup(x => x.ExecuteStoredProcedureAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<object>()))
                .Returns(Task.FromResult(new JsonElement()));
            mock.Mock<IConfigProvider>()
                .Setup(x => x.GetConnectionString(Application.BandCamsDb))
                .Returns("test");
            var onlineEventData = mock.Create<OnlineEventData>();

            // act
            await onlineEventData.Update(1, new OnlineEvent{Name = "", Description = "", ImageContent = new byte[1], Organizer = ""});

            // assert
            mock.Mock<ISqlDataAccess>().Verify(x => x.ExecuteStoredProcedureAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<object>()), Times.Once);
        }

        [Test]
        public async Task InsertCallOneQueryTest()
        {
            // arrange
            using var mock = AutoMock.GetStrict();
            mock.Mock<ISqlDataAccess>()
                .Setup(x => x.ExecuteStoredProcedureAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<object>()))
                .Returns(Task.FromResult(new JsonElement()));
            mock.Mock<IConfigProvider>()
                .Setup(x => x.GetConnectionString(Application.BandCamsDb))
                .Returns("test");
            var onlineEventData = mock.Create<OnlineEventData>();

            // act
            await onlineEventData.Insert(new OnlineEvent { Name = "", Description = "", ImageContent = new byte[1], Organizer = "" });

            // assert
            mock.Mock<ISqlDataAccess>().Verify(x => x.ExecuteStoredProcedureAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<object>()), Times.Once);
        }

        [Test]
        public async Task InsertReturnsIdTest()
        {
            // arrange
            using var mock = AutoMock.GetStrict();
            mock.Mock<ISqlDataAccess>()
                .Setup(x => x.ExecuteStoredProcedureAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<object>()))
                .Returns(Task.FromResult(new JsonElement()));
            mock.Mock<IConfigProvider>()
                .Setup(x => x.GetConnectionString(Application.BandCamsDb))
                .Returns("test");
            var onlineEventData = mock.Create<OnlineEventData>();

            // act
            var actual = await onlineEventData.Insert(new OnlineEvent { Name = "", Description = "", ImageContent = new byte[1], Organizer = "" });

            // assert
            Assert.IsNotNull(actual.Id, "Returned id is null");
        }
    }
}
