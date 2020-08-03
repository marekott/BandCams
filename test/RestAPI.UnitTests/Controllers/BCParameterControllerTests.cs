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
    // ReSharper disable once InconsistentNaming
    public class BCParameterControllerTests
    {
        [Test]
        public async Task GetReturnsOkResultTest()
        {
            // arrange
            using var mock = AutoMock.GetLoose();
            mock.Mock<IBCParametersData>()
                .Setup(x => x.GetAll())
                .Returns(Task.FromResult(new JsonElement()));
            var bcParameterController = mock.Create<BCParameterController>();

            // act
            var actual = await bcParameterController.Get();

            // assert
            Assert.IsInstanceOf<OkObjectResult>(actual);
        }

        [Test]
        public async Task GetCallsGetAllQueryTest()
        {
            // arrange
            using var mock = AutoMock.GetLoose();
            var bcParameterController = mock.Create<BCParameterController>();

            // act
            await bcParameterController.Get();

            // assert
            mock.Mock<IBCParametersData>().Verify(x => x.GetAll(), Times.Once);
        }

        [Test]
        public async Task GetByIdReturnsOkResultTest()
        {
            // arrange
            using var mock = AutoMock.GetLoose();
            mock.Mock<IBCParametersData>()
                .Setup(x => x.Get(It.IsAny<int>()))
                .Returns(Task.FromResult(JsonDocument.Parse("{}").RootElement));
            var bcParameterController = mock.Create<BCParameterController>();

            // act
            var actual = await bcParameterController.Get(1);

            // assert
            Assert.IsInstanceOf<OkObjectResult>(actual);
        }

        [Test]
        public async Task GetByIdReturnsNotFoundResultTest()
        {
            // arrange
            using var mock = AutoMock.GetLoose();
            mock.Mock<IBCParametersData>()
                .Setup(x => x.Get(It.IsAny<int>()))
                .Returns(Task.FromResult(JsonDocument.Parse("[]").RootElement));
            var bcParameterController = mock.Create<BCParameterController>();

            // act
            var actual = await bcParameterController.Get(1);

            // assert
            Assert.IsInstanceOf<NotFoundResult>(actual);
        }

        [Test]
        public async Task GetByIdCallsGetQueryTest()
        {
            // arrange
            using var mock = AutoMock.GetLoose();
            var bcParameterController = mock.Create<BCParameterController>();

            // act
            await bcParameterController.Get(1);

            // assert
            mock.Mock<IBCParametersData>().Verify(x => x.Get(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public async Task PostReturnsCreatedResultTest()
        {
            // arrange
            using var mock = AutoMock.GetLoose();
            mock.Mock<IBCParametersData>()
                .Setup(x => x.Insert(It.IsAny<BCParameter>()))
                .Returns(Task.FromResult(new CreatedRow()));
            var bcParameterController = mock.Create<BCParameterController>();

            // act
            var actual = await bcParameterController.Post(new BCParameter());

            // assert
            Assert.IsInstanceOf<CreatedResult>(actual);
        }

        [Test]
        public async Task PostCallsInsertQueryTest()
        {
            // arrange
            using var mock = AutoMock.GetLoose();
            var bcParameterController = mock.Create<BCParameterController>();

            // act
            await bcParameterController.Post(new BCParameter());

            // assert
            mock.Mock<IBCParametersData>().Verify(x => x.Insert(It.IsAny<BCParameter>()), Times.Once);
        }

        [Test]
        public async Task PutReturnsNoContentResultTest()
        {
            // arrange
            using var mock = AutoMock.GetLoose();
            mock.Mock<IBCParametersData>()
                .Setup(x => x.Get(It.IsAny<int>()))
                .Returns(Task.FromResult(JsonDocument.Parse("{}").RootElement));
            var bcParameterController = mock.Create<BCParameterController>();

            // act
            var actual = await bcParameterController.Put(1, new BCParameter());

            // assert
            Assert.IsInstanceOf<NoContentResult>(actual);
        }

        [Test]
        public async Task PutReturnsNotFoundResultTest()
        {
            // arrange
            using var mock = AutoMock.GetLoose();
            mock.Mock<IBCParametersData>()
                .Setup(x => x.Get(It.IsAny<int>()))
                .Returns(Task.FromResult(JsonDocument.Parse("[]").RootElement));
            var bcParameterController = mock.Create<BCParameterController>();

            // act
            var actual = await bcParameterController.Put(1, new BCParameter());

            // assert
            Assert.IsInstanceOf<NotFoundResult>(actual);
        }

        [Test]
        public async Task PutCallsGetQueryTest()
        {
            // arrange
            using var mock = AutoMock.GetLoose();
            var bcParameterController = mock.Create<BCParameterController>();

            // act
            await bcParameterController.Put(1, new BCParameter());

            // assert
            mock.Mock<IBCParametersData>().Verify(x => x.Get(It.IsAny<int>()), Times.Once);
        }

        [Test]
        public async Task PutCallsUpdateQueryTest()
        {
            // arrange
            using var mock = AutoMock.GetLoose();
            mock.Mock<IBCParametersData>()
                .Setup(x => x.Get(It.IsAny<int>()))
                .Returns(Task.FromResult(JsonDocument.Parse("{}").RootElement));
            var bcParameterController = mock.Create<BCParameterController>();

            // act
            await bcParameterController.Put(1, new BCParameter());

            // assert
            mock.Mock<IBCParametersData>().Verify(x => x.Update(It.IsAny<int>(), It.IsAny<BCParameter>()), Times.Once);
        }
    }
}
