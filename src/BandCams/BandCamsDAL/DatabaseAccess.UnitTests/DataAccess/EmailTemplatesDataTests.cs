using System.Text.Json;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using DatabaseAccess.DataAccess;
using DatabaseAccess.DataAccess.Internal;
using Moq;
using NUnit.Framework;
using Shared.Configuration;
using Shared.Models;

namespace DatabaseAccess.UnitTests.DataAccess
{
    [TestFixture]
    public class EmailTemplatesDataTests
    {
        [Test]
        public async Task GetCallsOneQueryTest()
        {
            // arrange
            using var mock = AutoMock.GetStrict();
            mock.Mock<ISqlDataAccess>()
                .Setup(x => x.ExecuteStoredProcedureAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<object>()))
                .Returns(Task.FromResult(JsonDocument.Parse(JsonSerializer.Serialize(CreateEmailQueueMessage())).RootElement));
            mock.Mock<IConfigProvider>()
                .Setup(x => x.GetConnectionString(Application.BandCamsDb))
                .Returns("test");
            var emailTemplatesData = mock.Create<EmailTemplatesData>();

            // act
            await emailTemplatesData.Get<EmailQueueMessage>("testTemplate");

            // assert
            mock.Mock<ISqlDataAccess>().Verify(x => x.ExecuteStoredProcedureAsync(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<object>()), Times.Once);
        }

        private static EmailQueueMessage CreateEmailQueueMessage()
        {
            return new EmailQueueMessage
            {
                Body = "test",
                Subject = "test",
                EmailTo = "test",
                SenderEmail = "test",
                SenderEmailAlias = "test"
            };
        }
    }
}
