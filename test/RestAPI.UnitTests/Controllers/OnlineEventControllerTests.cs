using System;
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
    public class OnlineEventControllerTests
    {
        [Test]
        public async Task GetReturnsOkResultTest()
        {
            // arrange
            using var mock = AutoMock.GetLoose();
            mock.Mock<IOnlineEventData>()
                .Setup(x => x.GetAll(It.IsAny<DateTime>(), It.IsAny<DateTime>()))
                .Returns(Task.FromResult(new JsonElement()));
            var onlineEventController = mock.Create<OnlineEventController>();

            // act
            var actual = await onlineEventController.Get(null, null);

            // assert
            Assert.IsInstanceOf<OkObjectResult>(actual);
        }

        [Test]
        public async Task GetCallsGetAllQueryTest()
        {
            // arrange
            using var mock = AutoMock.GetLoose();
            var onlineEventController = mock.Create<OnlineEventController>();

            // act
            await onlineEventController.Get(null, null);

            // assert
            mock.Mock<IOnlineEventData>().Verify(x => x.GetAll(It.IsAny<DateTime>(), It.IsAny<DateTime>()), Times.Once);
        }

        [Test]
        public async Task GetByIdReturnsOkResultTest()
        {
            // arrange
            using var mock = AutoMock.GetLoose();
            mock.Mock<IOnlineEventData>()
                .Setup(x => x.Get(It.IsAny<int>()))
                .Returns(Task.FromResult(JsonDocument.Parse("{}").RootElement));
            var onlineEventController = mock.Create<OnlineEventController>();

            // act
            var actual = await onlineEventController.Get(1);

            // assert
            Assert.IsInstanceOf<OkObjectResult>(actual);
        }

        [Test]
        public async Task GetByIdReturnsNotFoundResultTest()
        {
            // arrange
            using var mock = AutoMock.GetLoose();
            mock.Mock<IOnlineEventData>()
                .Setup(x => x.Get(It.IsAny<int>()))
                .Returns(Task.FromResult(JsonDocument.Parse("[]").RootElement));
            var onlineEventController = mock.Create<OnlineEventController>();

            // act
            var actual = await onlineEventController.Get(1);

            // assert
            Assert.IsInstanceOf<NotFoundResult>(actual);
        }

        [Test]
        public async Task GetByIdCallsGetQueryTest()
        {
            // arrange
            using var mock = AutoMock.GetLoose();
            var onlineEventController = mock.Create<OnlineEventController>();

            // act
            await onlineEventController.Get(1);

            // assert
            mock.Mock<IOnlineEventData>().Verify(x => x.Get(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public async Task PostReturnsCreatedResultTest()
        {
            // arrange
            using var mock = AutoMock.GetLoose();
            mock.Mock<IOnlineEventData>()
                .Setup(x => x.Insert(It.IsAny<OnlineEvent>()))
                .Returns(Task.FromResult(new CreatedRow()));
            var onlineEventController = mock.Create<OnlineEventController>();

            // act
            var actual = await onlineEventController.Post(new OnlineEvent());

            // assert
            Assert.IsInstanceOf<CreatedResult>(actual);
        }

        [Test]
        public async Task PostCallsInsertQueryTest()
        {
            // arrange
            using var mock = AutoMock.GetLoose();
            var onlineEventController = mock.Create<OnlineEventController>();

            // act
            await onlineEventController.Post(new OnlineEvent());

            // assert
            mock.Mock<IOnlineEventData>().Verify(x => x.Insert(It.IsAny<OnlineEvent>()), Times.Once);
        }

        [Test]
        public async Task PutReturnsNoContentResultTest()
        {
            // arrange
            using var mock = AutoMock.GetLoose();
            mock.Mock<IOnlineEventData>()
                .Setup(x => x.Get(It.IsAny<int>()))
                .Returns(Task.FromResult(JsonDocument.Parse("{}").RootElement));
            var onlineEventController = mock.Create<OnlineEventController>();

            // act
            var actual = await onlineEventController.Put(1, new OnlineEvent());

            // assert
            Assert.IsInstanceOf<NoContentResult>(actual);
        }

        [Test]
        public async Task PutReturnsNotFoundResultTest()
        {
            // arrange
            using var mock = AutoMock.GetLoose();
            mock.Mock<IOnlineEventData>()
                .Setup(x => x.Get(It.IsAny<int>()))
                .Returns(Task.FromResult(JsonDocument.Parse("[]").RootElement));
            var onlineEventController = mock.Create<OnlineEventController>();

            // act
            var actual = await onlineEventController.Put(1, new OnlineEvent());

            // assert
            Assert.IsInstanceOf<NotFoundResult>(actual);
        }

        [Test]
        public async Task PutCallsGetQueryTest()
        {
            // arrange
            using var mock = AutoMock.GetLoose();
            var onlineEventController = mock.Create<OnlineEventController>();

            // act
            await onlineEventController.Put(1, new OnlineEvent());

            // assert
            mock.Mock<IOnlineEventData>().Verify(x => x.Get(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public async Task PutCallsUpdateQueryTest()
        {
            // arrange
            using var mock = AutoMock.GetLoose();
            mock.Mock<IOnlineEventData>()
                .Setup(x => x.Get(It.IsAny<int>()))
                .Returns(Task.FromResult(JsonDocument.Parse("{}").RootElement));
            var onlineEventController = mock.Create<OnlineEventController>();

            // act
            await onlineEventController.Put(1, new OnlineEvent());

            // assert
            mock.Mock<IOnlineEventData>().Verify(x => x.Update(It.IsAny<int>(), It.IsAny<OnlineEvent>()), Times.Once);
        }
    }
}
