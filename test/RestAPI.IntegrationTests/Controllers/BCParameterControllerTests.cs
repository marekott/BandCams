using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Shared.Models;
using Xunit;

namespace RestAPI.IntegrationTests.Controllers
{
    // ReSharper disable once InconsistentNaming
    public class BCParameterControllerTests : BaseController
    {
        public BCParameterControllerTests(RestAPIFactory<Startup> factory) : base(factory)
        { }

        [Fact]
        public async Task GetReturns200StatusCodeTest()
        {
            // arrange
            var expected = HttpStatusCode.OK;
            var client = GetFactory().CreateClient();

            // act
            var actual = await client.GetAsync("/api/BCParameter");

            // assert
            Assert.True(actual.StatusCode == expected, $"{actual.StatusCode} was returned instead of {expected}");
        }

        [Fact]
        public async Task GetByIdReturns200StatusCodeTest()
        {
            // arrange
            var expected = HttpStatusCode.OK;
            var client = GetFactory().CreateClient();

            // act
            var actual = await client.GetAsync("/api/BCParameter/1");

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
            var actual = await client.GetAsync("/api/BCParameter/0");

            // assert
            Assert.True(actual.StatusCode == expected, $"{actual.StatusCode} was returned instead of {expected}");
        }

        [Fact]
        public async Task PostReturns201ResponseTest() //TODO transakcja żeby nie śmiecić?
        {
            // arrange
            var expected = HttpStatusCode.Created;
            var client = GetFactory().CreateClient();
            var bcParameter = new BCParameter
            {
                Key = "integrationTestKey",
                Value = "integrationTestValue"
            };

            // act
            var actual = await client.PostAsJsonAsync("/api/BCParameter", bcParameter);

            // assert
            Assert.True(actual.StatusCode == expected, $"{actual.StatusCode} was returned instead of {expected}");
        }

        [Fact]
        public async Task PostReturns400ResponseTest()
        {
            // arrange
            var expected = HttpStatusCode.BadRequest;
            var client = GetFactory().CreateClient();
            var bcParameter = new BCParameter();

            // act
            var actual = await client.PostAsJsonAsync("/api/BCParameter", bcParameter);
            
            // assert
            Assert.True(actual.StatusCode == expected, $"{actual.StatusCode} was returned instead of {expected}");
        }

        [Fact]
        public async Task PutReturns204ResponseTest() //TODO transakcja żeby nie śmiecić?
        {
            // arrange
            var expected = HttpStatusCode.NoContent;
            var client = GetFactory().CreateClient();
            var bcParameter = new BCParameter
            {
                Key = "newIntegrationTestKey",
                Value = "newIntegrationTestValue"
            };

            // act
            var actual = await client.PutAsJsonAsync("/api/BCParameter/1", bcParameter);

            // assert
            Assert.True(actual.StatusCode == expected, $"{actual.StatusCode} was returned instead of {expected}");
        }

        [Fact]
        public async Task PutReturns404ResponseTest()
        {
            // arrange
            var expected = HttpStatusCode.NotFound;
            var client = GetFactory().CreateClient();
            var bcParameter = new BCParameter
            {
                Key = "newIntegrationTestKey",
                Value = "newIntegrationTestValue"
            };

            // act
            var actual = await client.PutAsJsonAsync("/api/BCParameter/0", bcParameter);

            // assert
            Assert.True(actual.StatusCode == expected, $"{actual.StatusCode} was returned instead of {expected}");
        }

        [Fact]
        public async Task PutReturns400ResponseTest() 
        {
            // arrange
            var expected = HttpStatusCode.BadRequest;
            var client = GetFactory().CreateClient();
            var bcParameter = new BCParameter();

                // act
            var actual = await client.PutAsJsonAsync("/api/BCParameter/1", bcParameter);

            // assert
            Assert.True(actual.StatusCode == expected, $"{actual.StatusCode} was returned instead of {expected}");
        }
    }
}
