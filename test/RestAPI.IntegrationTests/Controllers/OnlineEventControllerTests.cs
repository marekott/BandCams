using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Shared.Models;
using Xunit;

namespace RestAPI.IntegrationTests.Controllers
{
    public class OnlineEventControllerTests : BaseController
    {
        public OnlineEventControllerTests(RestAPIFactory<Startup> factory) : base(factory)
        { }

        [Fact]
        public async Task GetWithoutParametersReturns200StatusCodeTest()
        {
            // arrange
            var expected = HttpStatusCode.OK;
            var client = GetFactory().CreateClient();

            // act
            var actual = await client.GetAsync("/api/OnlineEvent");

            // assert
            Assert.True(actual.StatusCode == expected, $"{actual.StatusCode} was returned instead of {expected}");
        }

        [Fact]
        public async Task GetWithFirstParameterReturns200StatusCodeTest()
        {
            // arrange
            var expected = HttpStatusCode.OK;
            var client = GetFactory().CreateClient();

            // act
            var actual = await client.GetAsync("/api/OnlineEvent?fromDate=2019-01-01");

            // assert
            Assert.True(actual.StatusCode == expected, $"{actual.StatusCode} was returned instead of {expected}");
        }

        [Fact]
        public async Task GetWithSecondParameterReturns200StatusCodeTest()
        {
            // arrange
            var expected = HttpStatusCode.OK;
            var client = GetFactory().CreateClient();

            // act
            var actual = await client.GetAsync("/api/OnlineEvent?toDate=2019-01-01");

            // assert
            Assert.True(actual.StatusCode == expected, $"{actual.StatusCode} was returned instead of {expected}");
        }

        [Fact]
        public async Task GetWitBothParametersReturns200StatusCodeTest()
        {
            // arrange
            var expected = HttpStatusCode.OK;
            var client = GetFactory().CreateClient();

            // act
            var actual = await client.GetAsync("/api/OnlineEvent?fromDate=2019-01-01&toDate=2019-01-01");

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
            var actual = await client.GetAsync("/api/OnlineEvent?fromDate=notDate&toDate=66666666");

            // assert
            Assert.True(actual.StatusCode == expected, $"{actual.StatusCode} was returned instead of {expected}");
        }

        [Fact]
        public async Task GetReturnsOnlineEventsWithStartDateInRangeOfParametersTest()
        {
            // arrange
            var expectedFromDate = new DateTime(2020, 4, 1);
            var expectedToDate = new DateTime(2020, 4, 30);
            var client = GetFactory().CreateClient();

            // act
            var response = await client.GetAsync($"/api/OnlineEvent?fromDate={expectedFromDate.Year}-{expectedFromDate.Month}-{expectedFromDate.Day}&toDate={expectedToDate.Year}-{expectedToDate.Month}-{expectedToDate.Day}");
            var actual = await response.Content.ReadAsAsync<List<OnlineEvent>>();

            // assert
            Assert.True(actual.All(x => x.StartDate >= expectedFromDate && x.StartDate <= expectedToDate), $"Not all online events are in range from {expectedFromDate} to {expectedToDate}");
        }

        [Fact]
        public async Task GetWithoutParametersReturnsAllOnlineEventsTest()
        {
            // arrange
            var client = GetFactory().CreateClient();
            var allEventsResponse = await client.GetAsync($"/api/OnlineEvent?fromDate=2000-01-01&toDate=5000-01-01");
            var allEvents = await allEventsResponse.Content.ReadAsAsync<List<OnlineEvent>>();
            var expected = allEvents.Count;

            // act
            var response = await client.GetAsync("/api/OnlineEvent");
            var actual = await response.Content.ReadAsAsync<List<OnlineEvent>>();

            // assert
            Assert.Equal(expected, actual.Count);
        }

        [Fact]
        public async Task GetByIdReturns200StatusCodeTest()
        {
            // arrange
            var expected = HttpStatusCode.OK;
            var client = GetFactory().CreateClient();

            // act
            var actual = await client.GetAsync("/api/OnlineEvent/1");

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
            var actual = await client.GetAsync("/api/OnlineEvent/0");

            // assert
            Assert.True(actual.StatusCode == expected, $"{actual.StatusCode} was returned instead of {expected}");
        }

        [Fact]
        public async Task PostReturns201ResponseTest() //TODO transakcja żeby nie śmiecić?
        {
            // arrange
            var expected = HttpStatusCode.Created;
            var client = GetFactory().CreateClient();
            var onlineEvent = new OnlineEvent
            {
                Name = "integrationTestName",
                Description = "integrationTestDescription",
                StartDate = DateTime.Now,
                Organizer = "integrationTestOrganizer",
                ImageContent = GetTestImage()
            };

            // act
            var actual = await client.PostAsJsonAsync("/api/OnlineEvent", onlineEvent);

            // assert
            Assert.True(actual.StatusCode == expected, $"{actual.StatusCode} was returned instead of {expected}");
        }

        [Fact]
        public async Task PostReturns400ResponseTest()
        {
            // arrange
            var expected = HttpStatusCode.BadRequest;
            var client = GetFactory().CreateClient();
            var onlineEvent = new OnlineEvent();

            // act
            var actual = await client.PostAsJsonAsync("/api/OnlineEvent", onlineEvent);

            // assert
            Assert.True(actual.StatusCode == expected, $"{actual.StatusCode} was returned instead of {expected}");
        }

        [Fact]
        public async Task PutReturns204ResponseTest() //TODO transakcja żeby nie śmiecić?
        {
            // arrange
            var expected = HttpStatusCode.NoContent;
            var client = GetFactory().CreateClient();
            var onlineEvent = new OnlineEvent
            {
                Name = "integrationTestName",
                Description = "integrationTestDescription",
                StartDate = DateTime.Now,
                Organizer = "integrationTestOrganizer",
                ImageContent = GetTestImage()
            };

            // act
            var actual = await client.PutAsJsonAsync("/api/OnlineEvent/1", onlineEvent);

            // assert
            Assert.True(actual.StatusCode == expected, $"{actual.StatusCode} was returned instead of {expected}");
        }

        [Fact]
        public async Task PutReturns404ResponseTest()
        {
            // arrange
            var expected = HttpStatusCode.NotFound;
            var client = GetFactory().CreateClient();
            var onlineEvent = new OnlineEvent
            {
                Name = "integrationTestName",
                Description = "integrationTestDescription",
                StartDate = DateTime.Now,
                Organizer = "integrationTestOrganizer",
                ImageContent = GetTestImage()
            };

            // act
            var actual = await client.PutAsJsonAsync("/api/OnlineEvent/0", onlineEvent);

            // assert
            Assert.True(actual.StatusCode == expected, $"{actual.StatusCode} was returned instead of {expected}");
        }

        [Fact]
        public async Task PutReturns400ResponseTest()
        {
            // arrange
            var expected = HttpStatusCode.BadRequest;
            var client = GetFactory().CreateClient();
            var onlineEvent = new OnlineEvent();

            // act
            var actual = await client.PutAsJsonAsync("/api/OnlineEvent/1", onlineEvent);

            // assert
            Assert.True(actual.StatusCode == expected, $"{actual.StatusCode} was returned instead of {expected}");
        }

        private byte[] GetTestImage()
        {
            return Convert.FromBase64String("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");
        }
    }
}
