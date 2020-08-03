using System;
using System.Text.Json;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using DatabaseAccess.DataAccess;
using DatabaseAccess.DataAccess.Internal;
using Moq;
using NUnit.Framework;
using Shared.Configuration;

namespace DatabaseAccess.UnitTests.DataAccess
{
    [TestFixture]
    public class StoredProceduresDataTests
    {
        [Test]
        public async Task CloseStreamsCallsOneQueryTest()
        {
            // arrange
            using var mock = AutoMock.GetStrict();
            mock.Mock<ISqlDataAccess>()
                .Setup(x => x.ExecuteStoredProcedureAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<object>()))
                .Returns(Task.FromResult(new JsonElement()));
            mock.Mock<IConfigProvider>()
                .Setup(x => x.GetConnectionString(Application.BandCamsDb))
                .Returns("test");
            var storedProceduresData = mock.Create<StoredProceduresData>();

            // act
            await storedProceduresData.CloseOldStreams(DateTime.UtcNow, 120);

            // assert
            mock.Mock<ISqlDataAccess>().Verify(x => x.ExecuteStoredProcedureAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<object>()), Times.Once);
        }
    }
}
