using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Shared.Models;
using Xunit;

namespace RestAPI.IntegrationTests.Controllers
{
    public class StreamControllerTests : BaseController
    {
        public StreamControllerTests(RestAPIFactory<Startup> factory) : base(factory)
        { }

        [Fact]
        public async Task GetReturns200StatusCodeTest()
        {
            // arrange
            var expected = HttpStatusCode.OK;
            var client = GetFactory().CreateClient();

            // act
            var actual = await client.GetAsync("/api/Stream?isActive=true");

            // assert
            Assert.True(actual.StatusCode == expected, $"{actual.StatusCode} was returned instead of {expected}");
        }

        [Fact]
        public async Task GetReturns400StatusCodeTest()
        {
            // arrange
            var expected = HttpStatusCode.BadRequest;
            var client = GetFactory().CreateClient();

            // act
            var actual = await client.GetAsync("/api/Stream");

            // assert
            Assert.True(actual.StatusCode == expected, $"{actual.StatusCode} was returned instead of {expected}");
        }

        [Fact]
        public async Task GetIsActiveTrueReturnsOnlyActiveStreamsTest()
        {
            // arrange
            var client = GetFactory().CreateClient();

            // act
            var response = await client.GetAsync("/api/Stream?isActive=true");
            var actual = await response.Content.ReadAsAsync<List<Stream>>();

            // assert
            Assert.True(actual.All(x => x.IsActive), "Not all returned Streams are active");
        }

        [Fact]
        public async Task GetIsActiveFalseReturnsOnlyInactiveStreamsTest()
        {
            // arrange
            var client = GetFactory().CreateClient();

            // act
            var response = await client.GetAsync("/api/Stream?isActive=false");
            var actual = await response.Content.ReadAsAsync<List<Stream>>();

            // assert
            Assert.True(actual.All(x => x.IsActive == false), "Not all returned Streams are inactive");
        }

        [Fact]
        public async Task GetByIdReturns200StatusCodeTest()
        {
            // arrange
            var expected = HttpStatusCode.OK;
            var client = GetFactory().CreateClient();

            // act
            var actual = await client.GetAsync("/api/Stream/1");

            // assert
            Assert.True(actual.StatusCode == expected, $"{actual.StatusCode} was returned instead of {expected}");
        }

        [Fact]
        public async Task GetByIdReturns404StatusCodeTest()
        {
            // arrange
            var expected = HttpStatusCode.NotFound;
            var client = GetFactory().CreateClient();

            // act
            var actual = await client.GetAsync("/api/Stream/0");

            // assert
            Assert.True(actual.StatusCode == expected, $"{actual.StatusCode} was returned instead of {expected}");
        }

        [Fact(Skip = "Test returns HTTP 500 status code because of lack of the Azure Queue.")]
        public async Task PostReturns201ResponseTest() //TODO transakcja żeby nie śmiecić?
        {
            // arrange
            var expected = HttpStatusCode.Created;
            var client = GetFactory().CreateClient();
            var stream = new Stream()
            {
                Link = "integrationTestLink",
                IsActive = false
            };

            // act
            var actual = await client.PostAsJsonAsync("/api/Stream", stream);

            // assert
            Assert.True(actual.StatusCode == expected, $"{actual.StatusCode} was returned instead of {expected}");
        }

        [Fact]
        public async Task PostReturns400ResponseTest()
        {
            // arrange
            var expected = HttpStatusCode.BadRequest;
            var client = GetFactory().CreateClient();
            var stream = new Stream();

            // act
            var actual = await client.PostAsJsonAsync("/api/Stream", stream);

            // assert
            Assert.True(actual.StatusCode == expected, $"{actual.StatusCode} was returned instead of {expected}");
        }

        [Fact]
        public async Task PutReturns204ResponseTest() //TODO transakcja żeby nie śmiecić?
        {
            // arrange
            var expected = HttpStatusCode.NoContent;
            var client = GetFactory().CreateClient();
            var stream = new Stream
            {
                Link = "integrationTestLink",
                IsActive = false
            };

            // act
            var actual = await client.PutAsJsonAsync("/api/Stream/1", stream);

            // assert
            Assert.True(actual.StatusCode == expected, $"{actual.StatusCode} was returned instead of {expected}");
        }

        [Fact]
        public async Task PutReturns404ResponseTest()
        {
            // arrange
            var expected = HttpStatusCode.NotFound;
            var client = GetFactory().CreateClient();
            var stream = new Stream
            {
                Link = "integrationTestLink",
                IsActive = false
            };

            // act
            var actual = await client.PutAsJsonAsync("/api/Stream/0", stream);

            // assert
            Assert.True(actual.StatusCode == expected, $"{actual.StatusCode} was returned instead of {expected}");
        }

        [Fact]
        public async Task PutReturns400ResponseTest()
        {
            // arrange
            var expected = HttpStatusCode.BadRequest;
            var client = GetFactory().CreateClient();
            var stream = new Stream();

            // act
            var actual = await client.PutAsJsonAsync("/api/Stream/1", stream);

            // assert
            Assert.True(actual.StatusCode == expected, $"{actual.StatusCode} was returned instead of {expected}");
        }
    }
}
