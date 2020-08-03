using System.Text.Json;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using DatabaseAccess.DataAccess.Interfaces;
using Shared.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using RestAPI.Controllers;

namespace RestAPI.UnitTests.Controllers
{
    [TestFixture]
    public class StreamControllerTests
    {
        [Test]
        public async Task GetReturnsOkResultTest()
        {
            // arrange
            using var mock = AutoMock.GetLoose();
            mock.Mock<IStreamData>()
                .Setup(x => x.GetAll(It.IsAny<bool>()))
                .Returns(Task.FromResult(new JsonElement()));
            var streamController = mock.Create<StreamController>();

            // act
            var actual = await streamController.Get(true);

            // assert
            Assert.IsInstanceOf<OkObjectResult>(actual);
        }

        [Test]
        public async Task GetCallsGetAllQueryTest()
        {
            // arrange
            using var mock = AutoMock.GetLoose();
            var streamController = mock.Create<StreamController>();

            // act
            await streamController.Get(false);

            // assert
            mock.Mock<IStreamData>().Verify(x => x.GetAll(It.IsAny<bool>()), Times.Once);
        }

        [Test]
        public async Task GetByIdReturnsOkResultTest()
        {
            // arrange
            using var mock = AutoMock.GetLoose();
            mock.Mock<IStreamData>()
                .Setup(x => x.Get(It.IsAny<int>()))
                .Returns(Task.FromResult(JsonDocument.Parse("{}").RootElement));
            var streamController = mock.Create<StreamController>();

            // act
            var actual = await streamController.Get(1);

            // assert
            Assert.IsInstanceOf<OkObjectResult>(actual);
        }

        [Test]
        public async Task GetByIdReturnsNotFoundResultTest()
        {
            // arrange
            using var mock = AutoMock.GetLoose();
            mock.Mock<IStreamData>()
                .Setup(x => x.Get(It.IsAny<int>()))
                .Returns(Task.FromResult(JsonDocument.Parse("[]").RootElement));
            var streamController = mock.Create<StreamController>();

            // act
            var actual = await streamController.Get(1);

            // assert
            Assert.IsInstanceOf<NotFoundResult>(actual);
        }

        [Test]
        public async Task GetByIdCallsGetQueryTest()
        {
            // arrange
            using var mock = AutoMock.GetLoose();
            var streamController = mock.Create<StreamController>();

            // act
            await streamController.Get(1);

            // assert
            mock.Mock<IStreamData>().Verify(x => x.Get(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public async Task PostReturnsCreatedResultTest()
        {
            // arrange
            using var mock = AutoMock.GetLoose();
            mock.Mock<IStreamData>()
                .Setup(x => x.Insert(It.IsAny<Stream>()))
                .Returns(Task.FromResult(new CreatedRow()));
            mock.Mock<IEmailTemplatesData>()
                .Setup(x => x.Get<EmailQueueMessage>(It.IsAny<string>()))
                .Returns(Task.FromResult(new EmailQueueMessage { Body = "test" }));
            var streamController = mock.Create<StreamController>();

            // act
            var actual = await streamController.Post(new Stream());

            // assert
            Assert.IsInstanceOf<CreatedResult>(actual);
        }

        [Test]
        public async Task PostCallsInsertQueryTest()
        {
            // arrange
            using var mock = AutoMock.GetLoose();
            mock.Mock<IEmailTemplatesData>()
                .Setup(x => x.Get<EmailQueueMessage>(It.IsAny<string>()))
                .Returns(Task.FromResult(new EmailQueueMessage {Body = "test"}));
            var streamController = mock.Create<StreamController>();

            // act
            await streamController.Post(new Stream());

            // assert
            mock.Mock<IStreamData>().Verify(x => x.Insert(It.IsAny<Stream>()), Times.Once);
        }

        [Test]
        public async Task PutReturnsNoContentResultTest()
        {
            // arrange
            using var mock = AutoMock.GetLoose();
            mock.Mock<IStreamData>()
                .Setup(x => x.Get(It.IsAny<int>()))
                .Returns(Task.FromResult(JsonDocument.Parse("{}").RootElement));
            var streamController = mock.Create<StreamController>();

            // act
            var actual = await streamController.Put(1, new Stream());

            // assert
            Assert.IsInstanceOf<NoContentResult>(actual);
        }

        [Test]
        public async Task PutReturnsNotFoundResultTest()
        {
            // arrange
            using var mock = AutoMock.GetLoose();
            mock.Mock<IStreamData>()
                .Setup(x => x.Get(It.IsAny<int>()))
                .Returns(Task.FromResult(JsonDocument.Parse("[]").RootElement));
            var streamController = mock.Create<StreamController>();

            // act
            var actual = await streamController.Put(1, new Stream());

            // assert
            Assert.IsInstanceOf<NotFoundResult>(actual);
        }

        [Test]
        public async Task PutCallsGetQueryTest()
        {
            // arrange
            using var mock = AutoMock.GetLoose();
            var streamController = mock.Create<StreamController>();

            // act
            await streamController.Put(1, new Stream());

            // assert
            mock.Mock<IStreamData>().Verify(x => x.Get(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public async Task PutCallsUpdateQueryTest()
        {
            // arrange
            using var mock = AutoMock.GetLoose();
            mock.Mock<IStreamData>()
                .Setup(x => x.Get(It.IsAny<int>()))
                .Returns(Task.FromResult(JsonDocument.Parse("{}").RootElement));
            var streamController = mock.Create<StreamController>();

            // act
            await streamController.Put(1, new Stream());

            // assert
            mock.Mock<IStreamData>().Verify(x => x.Update(It.IsAny<int>(), It.IsAny<Stream>()), Times.Once);
        }
    }
}
