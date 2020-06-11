using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Shared.Models;
using Xunit;

namespace RestAPI.IntegrationTests.Controllers
{
    public class StoredProceduresControllerTests : BaseController
    {
        public StoredProceduresControllerTests(RestAPIFactory<Startup> factory) : base(factory)
        { }

        [Fact]
        public async Task CloseStreamsReturns200StatusCodeTest()
        {
            // arrange
            var expected = HttpStatusCode.OK;
            var client = GetFactory().CreateClient();
            var closeStream = new CloseOldStream
            {
                DateTimeNowUtc = DateTime.UtcNow.AddYears(-10),
                OlderThanInMinutes = 120
            };

            // act
            var actual = await client.PostAsJsonAsync("/api/StoredProcedures/CloseOldStreams", closeStream);

            // assert
            Assert.True(actual.StatusCode == expected, $"{actual.StatusCode} was returned instead of {expected}");
        }

        [Fact]
        public async Task CloseStreamsMissingDateReturns400StatusCodeTest()
        {
            // arrange
            var expected = HttpStatusCode.BadRequest;
            var client = GetFactory().CreateClient();
            var closeStream = new CloseOldStream
            {
                OlderThanInMinutes = 120
            };

            // act
            var actual = await client.PostAsJsonAsync("/api/StoredProcedures/CloseOldStreams", closeStream);

            // assert
            Assert.True(actual.StatusCode == expected, $"{actual.StatusCode} was returned instead of {expected}");
        }

        [Fact]
        public async Task CloseStreamsMissingMinutesReturns400StatusCodeTest()
        {
            // arrange
            var expected = HttpStatusCode.BadRequest;
            var client = GetFactory().CreateClient();
            var closeStream = new CloseOldStream
            {
                DateTimeNowUtc = DateTime.UtcNow.AddYears(10)
            };

            // act
            var actual = await client.PostAsJsonAsync("/api/StoredProcedures/CloseOldStreams", closeStream);

            // assert
            Assert.True(actual.StatusCode == expected, $"{actual.StatusCode} was returned instead of {expected}");
        }
    }
}
