using System.Threading.Tasks;
using ApiHelper;
using Autofac.Extras.Moq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Moq;
using NUnit.Framework;
using WebUI.Models;
using WebUI.Pages.Streams;

namespace WebUI.Tests.Pages.Streams
{
    [TestFixture]
    public class AddModelTests
    {
        [Test]
        public async Task OnPostInvalidModelStateDoesNotCallPostAsJsonAsyncTest()
        {
            // arrange
            using var mock = AutoMock.GetLoose();
            var addModel = mock.Create<AddModel>();
            addModel.ModelState.AddModelError("", "");

            // act
            await addModel.OnPost();

            // assert
            mock.Mock<IHttpHelper>().Verify(x => x.PostAsJsonAsync<It.IsAnyType, Stream>(It.IsAny<string>(),
                It.IsAny<Stream>()), Times.Never);
        }

        [Test]
        public async Task OnPostModelStateIsValidCallsPostAsJsonAsyncTest()
        {
            using var mock = AutoMock.GetLoose();
            var addModel = mock.Create<AddModel>();
            addModel.Stream = new Stream
            {
                Link = "https://www.facebook.com/NBCNews/videos/213248396772223/"
            };

            // act
            await addModel.OnPost();

            // assert
            mock.Mock<IHttpHelper>().Verify(x => x.PostAsJsonAsync<It.IsAnyType, Stream>(It.IsAny<string>(),
                It.IsAny<Stream>()), Times.Once);
        }

        [Test]
        public async Task OnPostInvalidModelStateReturnsPageResultTest()
        {
            // arrange
            using var mock = AutoMock.GetLoose();
            var addModel = mock.Create<AddModel>();
            addModel.ModelState.AddModelError("", "");

            // act
            var actual = await addModel.OnPost();

            // assert
            Assert.IsInstanceOf<PageResult>(actual);
        }

        [Test]
        public async Task OnPostModelStateIsValidReturnsRedirectResultTest()
        {
            using var mock = AutoMock.GetLoose();
            var addModel = mock.Create<AddModel>();
            addModel.Stream = new Stream
            {
                Link = "https://www.facebook.com/NBCNews/videos/213248396772223/"
            };

            // act
            var actual = await addModel.OnPost();

            // assert
            Assert.IsInstanceOf<RedirectResult>(actual);
        }
    }
}
