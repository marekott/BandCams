using System.Text.Json;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using Shared.Configuration;
using DatabaseAccess.DataAccess;
using DatabaseAccess.DataAccess.Internal;
using Moq;
using NUnit.Framework;
using Shared.Models;

// ReSharper disable InconsistentNaming

namespace DatabaseAccess.UnitTests.DataAccess
{
    [TestFixture]
    public class BCParametersDataTests
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
            var bcParametersData = mock.Create<BCParametersData>();

            // act
            var actual = await bcParametersData.GetAll();

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
            var bcParametersData = mock.Create<BCParametersData>();

            // act
            await bcParametersData.GetAll();

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
            var bcParametersData = mock.Create<BCParametersData>();

            // act
            var actual = await bcParametersData.Get(1);

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
            var bcParametersData = mock.Create<BCParametersData>();

            // act
            await bcParametersData.Get(1);

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
            var bcParametersData = mock.Create<BCParametersData>();

            // act
            await bcParametersData.Update(1, new BCParameter{Key = "Key", Value = "Value"});

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
            var bcParametersData = mock.Create<BCParametersData>();

            // act
            await bcParametersData.Insert(new BCParameter { Key = "Key", Value = "Value" });

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
            var bcParametersData = mock.Create<BCParametersData>();

            // act
            var actual = await bcParametersData.Insert(new BCParameter { Key = "Key", Value = "Value" });

            // assert
            Assert.IsNotNull(actual.Id, "Returned id is null");
        }
    }
}
