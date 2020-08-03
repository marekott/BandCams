using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Threading.Tasks;
using ApiHelper.Tests.StubModels;
using Autofac.Extras.Moq;
using Moq;
using NUnit.Framework;

namespace ApiHelper.Tests
{
    [TestFixture]
    public class HttpHelperTests
    {
        [Test]
        public async Task GetAsyncCallsGetAsyncOnIHttpClientHelperTest()
        {
            // arrange
            using var mock = AutoMock.GetStrict();
            mock.Mock<IHttpClientHelper>()
                .Setup(x => x.GetAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new StringContent("")
                }));
            var httpHelper = mock.Create<HttpHelper>();

            // act
            await httpHelper.GetAsync<string>("");

            // assert
            mock.Mock<IHttpClientHelper>().Verify(x => x.GetAsync(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public void GetAsyncThrowsExceptionIfResponseIsNotSuccessStatusCodeTest()
        {
            // arrange
            using var mock = AutoMock.GetStrict();
            mock.Mock<IHttpClientHelper>()
                .Setup(x => x.GetAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError
                }));
            var httpHelper = mock.Create<HttpHelper>();

            // act
            // assert
            Assert.ThrowsAsync<Exception>(async () => await httpHelper.GetAsync<string>(""));
        }

        [Test]
        public async Task GetAsyncReturnsDeserializedObjectIfResponseIsSuccessStatusCodeTest()
        {
            // arrange
            var expectedName = "Test";
            using var mock = AutoMock.GetStrict();
            mock.Mock<IHttpClientHelper>()
                .Setup(x => x.GetAsync(It.IsAny<string>()))
                .Returns(Task.FromResult(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.OK,
                    Content = new ObjectContent<OnlineEvent>(new OnlineEvent { Name = expectedName }, new JsonMediaTypeFormatter())
                }));
            var httpHelper = mock.Create<HttpHelper>();

            // act
            var actual = await httpHelper.GetAsync<OnlineEvent>("");

            // assert
            Assert.Multiple(() =>
            {
                Assert.IsInstanceOf<OnlineEvent>(actual);
                StringAssert.AreEqualIgnoringCase(expectedName, actual.Name);
            });
        }

        [Test]
        public async Task PostAsJsonAsyncCallsPostAsJsonAsyncOnIHttpClientHelperTest()
        {
            // arrange
            using var mock = AutoMock.GetStrict();
            mock.Mock<IHttpClientHelper>()
                .Setup(x => x.PostAsJsonAsync(It.IsAny<string>(), It.IsAny<object>()))
                .Returns(Task.FromResult(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Created,
                    Content = new StringContent("")
                }));
            var httpHelper = mock.Create<HttpHelper>();

            // act
            await httpHelper.PostAsJsonAsync<string, object>("", new object());

            // assert
            mock.Mock<IHttpClientHelper>().Verify(x => x.PostAsJsonAsync(It.IsAny<string>(), It.IsAny<object>()), Times.Once);
        }

        [Test]
        public async Task PostAsJsonAsyncTaskCallsPostAsJsonAsyncOnIHttpClientHelperTest()
        {
            // arrange
            using var mock = AutoMock.GetStrict();
            mock.Mock<IHttpClientHelper>()
                .Setup(x => x.PostAsJsonAsync(It.IsAny<string>(), It.IsAny<object>()))
                .Returns(Task.FromResult(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Created,
                    Content = new StringContent("")
                }));
            var httpHelper = mock.Create<HttpHelper>();

            // act
            await httpHelper.PostAsJsonAsync("", new object());

            // assert
            mock.Mock<IHttpClientHelper>().Verify(x => x.PostAsJsonAsync(It.IsAny<string>(), It.IsAny<object>()), Times.Once);
        }

        [Test]
        public void PostAsJsonAsyncThrowsExceptionIfResponseIsNotSuccessStatusCodeTest()
        {
            // arrange
            using var mock = AutoMock.GetStrict();
            mock.Mock<IHttpClientHelper>()
                .Setup(x => x.PostAsJsonAsync(It.IsAny<string>(), It.IsAny<object>()))
                .Returns(Task.FromResult(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError
                }));
            var httpHelper = mock.Create<HttpHelper>();

            // act
            // assert
            Assert.ThrowsAsync<Exception>(async () => await httpHelper.PostAsJsonAsync<string, object>("", new object()));
        }

        [Test]
        public void PostAsJsonAsyncTaskThrowsExceptionIfResponseIsNotSuccessStatusCodeTest()
        {
            // arrange
            using var mock = AutoMock.GetStrict();
            mock.Mock<IHttpClientHelper>()
                .Setup(x => x.PostAsJsonAsync(It.IsAny<string>(), It.IsAny<object>()))
                .Returns(Task.FromResult(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError
                }));
            var httpHelper = mock.Create<HttpHelper>();

            // act
            // assert
            Assert.ThrowsAsync<Exception>(async () => await httpHelper.PostAsJsonAsync("", new object()));
        }

        [Test]
        public async Task PostAsJsonAsyncReturnsDeserializedObjectIfResponseIsSuccessStatusCodeTest()
        {
            // arrange
            var expectedName = "Test";
            using var mock = AutoMock.GetStrict();
            mock.Mock<IHttpClientHelper>()
                .Setup(x => x.PostAsJsonAsync(It.IsAny<string>(), It.IsAny<object>()))
                .Returns(Task.FromResult(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.Created,
                    Content = new ObjectContent<OnlineEvent>(new OnlineEvent { Name = expectedName }, new JsonMediaTypeFormatter())
                }));
            var httpHelper = mock.Create<HttpHelper>();

            // act
            var actual = await httpHelper.PostAsJsonAsync<OnlineEvent, object>("", new object());

            // assert
            Assert.Multiple(() =>
            {
                Assert.IsInstanceOf<OnlineEvent>(actual);
                StringAssert.AreEqualIgnoringCase(expectedName, actual.Name);
            });
        }

        [Test]
        public async Task PutAsJsonAsyncCallsPutAsJsonAsyncOnIHttpClientHelperTest()
        {
            // arrange
            using var mock = AutoMock.GetStrict();
            mock.Mock<IHttpClientHelper>()
                .Setup(x => x.PutAsJsonAsync(It.IsAny<string>(), It.IsAny<object>()))
                .Returns(Task.FromResult(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.NoContent
                }));
            var httpHelper = mock.Create<HttpHelper>();

            // act
            await httpHelper.PutAsJsonAsync("", new object());

            // assert
            mock.Mock<IHttpClientHelper>().Verify(x => x.PutAsJsonAsync(It.IsAny<string>(), It.IsAny<object>()), Times.Once);
        }

        [Test]
        public void PutAsJsonAsyncThrowsExceptionIfResponseIsNotSuccessStatusCodeTest()
        {
            // arrange
            using var mock = AutoMock.GetStrict();
            mock.Mock<IHttpClientHelper>()
                .Setup(x => x.PutAsJsonAsync(It.IsAny<string>(), It.IsAny<object>()))
                .Returns(Task.FromResult(new HttpResponseMessage
                {
                    StatusCode = HttpStatusCode.InternalServerError
                }));
            var httpHelper = mock.Create<HttpHelper>();

            // act
            // assert
            Assert.ThrowsAsync<Exception>(async () => await httpHelper.PutAsJsonAsync("", new object()));
        }
    }
}
