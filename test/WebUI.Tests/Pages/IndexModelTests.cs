using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiHelper;
using Autofac.Extras.Moq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Moq;
using NUnit.Framework;
using WebUI.Library.Helpers;
using WebUI.Models;
using WebUI.Pages;

namespace WebUI.Tests.Pages
{
    [TestFixture]
    public class IndexModelTests
    {
        [Test]
        public async Task OnGetCallsTwoGetEndPointsTest()
        {
            // arrange
            using var mock = AutoMock.GetLoose();
            mock.Mock<IHttpHelper>()
                .Setup(x => x.GetAsync<It.IsAnyType>(It.IsAny<string>()));
            var indexModel = mock.Create<IndexModel>();

            // act
            await indexModel.OnGet();

            // assert
            mock.Mock<IHttpHelper>().Verify(x => x.GetAsync<It.IsAnyType>(It.IsAny<string>()), Times.Exactly(2));
        }

        [Test]
        public async Task StreamsGetterTest()
        {
            // arrange
            var expected = 1;
            using var mock = AutoMock.GetStrict();
            mock.Mock<IHttpHelper>()
                .Setup(x => x.GetAsync<List<Stream>>(It.IsAny<string>()))
                .Returns(Task.FromResult(new List<Stream>
                {
                    new Stream
                    {
                        Id = expected
                    }
                }));
            mock.Mock<IHttpHelper>()
                .Setup(x => x.GetAsync<List<OnlineEvent>>(It.IsAny<string>()))
                .Returns(Task.FromResult(new List<OnlineEvent>()));
            var indexModel = mock.Create<IndexModel>();

            // act
            await indexModel.OnGet();

            // assert
            Assert.AreEqual(expected, indexModel.Streams?.FirstOrDefault()?.Id);
        }

        [Test]
        public async Task OnlineEventsGetterTest()
        {
            // arrange
            var expected = 1;
            using var mock = AutoMock.GetStrict();
            mock.Mock<IHttpHelper>()
                .Setup(x => x.GetAsync<List<OnlineEvent>>(It.IsAny<string>()))
                .Returns(Task.FromResult(new List<OnlineEvent>
                {
                    new OnlineEvent
                    {
                        Id = expected
                    }
                }));
            mock.Mock<IHttpHelper>()
                .Setup(x => x.GetAsync<List<Stream>>(It.IsAny<string>()))
                .Returns(Task.FromResult(new List<Stream>()));
            var indexModel = mock.Create<IndexModel>();

            // act
            await indexModel.OnGet();

            // assert
            Assert.AreEqual(expected, indexModel.OnlineEvents?.FirstOrDefault()?.Id);
        }

        [Test]
        public void GetVideoImageLinkYoutubeVideoCallsYoutubeHelperOnceTest()
        {
            // arrange
            var ytVideoLink = "https://www.youtube.com/embed/z9Ul9ccDOqE";
            using var mock = AutoMock.GetLoose();
            mock.Mock<IYouTubeHelper>()
                .Setup(x => x.GetThumbnailLink(It.IsAny<string>()));
            var indexModel = mock.Create<IndexModel>();

            // act
            indexModel.GetVideoImageLink(ytVideoLink);

            // assert
            mock.Mock<IYouTubeHelper>().Verify(x => x.GetThumbnailLink(It.IsAny<string>()), Times.Exactly(1));
        }

        [Test]
        public void GetVideoImageLinkFacebookVideoReturnsPlaceholderTest()
        {
            // arrange
            var fbVideoLink = "https://www.facebook.com/video/embed?video_id=662795397855755";
            var expected = "img/fb_stream_img.jpg";
            using var mock = AutoMock.GetLoose();
            var indexModel = mock.Create<IndexModel>();

            // act
            var actual = indexModel.GetVideoImageLink(fbVideoLink);

            // assert
            StringAssert.AreEqualIgnoringCase(expected, actual);
        }

        [Test]
        public async Task OnGetShowModalCallsGetEndpointOnceTest()
        {
            // arrange
            using var mock = AutoMock.GetStrict();
            mock.Mock<IHttpHelper>()
                .Setup(x => x.GetAsync<Stream>(It.IsAny<string>()))
                .Returns(Task.FromResult(new Stream()));
            var httpContext = new DefaultHttpContext();
            var modelState = new ModelStateDictionary();
            var actionContext = new ActionContext(httpContext, new RouteData(), new PageActionDescriptor(), modelState);
            var modelMetadataProvider = new EmptyModelMetadataProvider();
            var viewData = new ViewDataDictionary(modelMetadataProvider, modelState);
            var pageContext = new PageContext(actionContext)
            {
                ViewData = viewData
            };
            var indexModel = mock.Create<IndexModel>();
            indexModel.PageContext = pageContext;

            // act
            await indexModel.OnGetShowModal(1);

            // assert
            mock.Mock<IHttpHelper>().Verify(x => x.GetAsync<Stream>(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public async Task OnGetShowModalReturnsStreamVideoPartialTest()
        {
            // arrange
            const string expected = "_StreamVideoPartial";
            using var mock = AutoMock.GetStrict();
            mock.Mock<IHttpHelper>()
                .Setup(x => x.GetAsync<Stream>(It.IsAny<string>()))
                .Returns(Task.FromResult(new Stream()));
            var httpContext = new DefaultHttpContext();
            var modelState = new ModelStateDictionary();
            var actionContext = new ActionContext(httpContext, new RouteData(), new PageActionDescriptor(), modelState);
            var modelMetadataProvider = new EmptyModelMetadataProvider();
            var viewData = new ViewDataDictionary(modelMetadataProvider, modelState);
            var pageContext = new PageContext(actionContext)
            {
                ViewData = viewData
            };
            var indexModel = mock.Create<IndexModel>();
            indexModel.PageContext = pageContext;

            // act
            var actual = await indexModel.OnGetShowModal(1);

            // assert
            StringAssert.AreEqualIgnoringCase(expected, actual.ViewName);
        }
    }
}
