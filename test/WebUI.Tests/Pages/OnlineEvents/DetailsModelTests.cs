using System;
using System.Threading.Tasks;
using ApiHelper;
using Autofac.Extras.Moq;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using WebUI.Models;
using WebUI.Pages.OnlineEvents;

namespace WebUI.Tests.Pages.OnlineEvents
{
    [TestFixture]
    public class DetailsModelTests
    {
        [Test]
        public async Task OnGetCallGetEndpointTest()
        {
            // arrange
            using var mock = AutoMock.GetStrict();
            mock.Mock<IHttpHelper>()
                .Setup(x => x.GetAsync<OnlineEvent>(It.IsAny<string>()))
                .Returns(Task.FromResult(new OnlineEvent()));
            var detailsModel = mock.Create<DetailsModel>();

            // act
            await detailsModel.OnGet(1);

            // assert
            mock.Mock<IHttpHelper>().Verify(x => x.GetAsync<OnlineEvent>(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public async Task OnGetReturnsNotFoundIfIHttpHelperThrowsException()
        {
            // arrange
            using var mock = AutoMock.GetStrict();
            mock.Mock<IHttpHelper>()
                .Setup(x => x.GetAsync<OnlineEvent>(It.IsAny<string>()))
                .Throws<Exception>();
            var detailsModel = mock.Create<DetailsModel>();

            // act
            var actual = await detailsModel.OnGet(1);

            // assert
            Assert.IsInstanceOf<NotFoundResult>(actual);
        }
    }
}
