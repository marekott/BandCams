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
    public class StreamDataTests
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
            var streamData = mock.Create<StreamData>();

            // act
            var actual = await streamData.GetAll(true);

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
            var streamData = mock.Create<StreamData>();

            // act
            await streamData.GetAll(true);

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
            var streamData = mock.Create<StreamData>();

            // act
            var actual = await streamData.Get(1);

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
            var streamData = mock.Create<StreamData>();

            // act
            await streamData.Get(1);

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
            var streamData = mock.Create<StreamData>();

            // act
            await streamData.Update(1, new Stream {Link = ""});

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
            var streamData = mock.Create<StreamData>();

            // act
            await streamData.Insert(new Stream { Link = "" });

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
            var streamData = mock.Create<StreamData>();

            // act
            var actual = await streamData.Insert(new Stream { Link = "" });

            // assert
            Assert.IsNotNull(actual.Id, "Returned id is null");
        }
    }
}
