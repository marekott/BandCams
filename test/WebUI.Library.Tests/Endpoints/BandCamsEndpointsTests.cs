using System;
using NUnit.Framework;
using WebUI.Library.Endpoints;

namespace WebUI.Library.Tests.Endpoints
{
    [TestFixture]
    public class BandCamsEndpointsTests
    {
        [Test]
        public void GetOnlineEventInDatesTest()
        {
            // arrange
            var now = DateTime.Now;
            var tomorrow = now.AddDays(1);
            var expected = $"/api/OnlineEvent?fromDate={now.Year}-{now.Month}-{now.Day}&toDate={tomorrow.Year}-{tomorrow.Month}-{tomorrow.Day}";

            // act
            var actual = BandCamsEndpoints.GetOnlineEvent(now, tomorrow);

            // assert
            StringAssert.AreEqualIgnoringCase(expected, actual);
        }

        [Test]
        public void GetOnlineEventByIdTest()
        {
            // arrange
            var randomId = new Random().Next(1, 20);
            var expected = $"/api/OnlineEvent/{randomId}";

            // act
            var actual = BandCamsEndpoints.GetOnlineEvent(randomId);

            // assert
            StringAssert.AreEqualIgnoringCase(expected, actual);
        }

        [Test]
        public void OnlineEventTest()
        {
            // arrange
            const string expected = "/api/OnlineEvent";

            // act
            var actual = BandCamsEndpoints.OnlineEvent;

            // assert
            StringAssert.AreEqualIgnoringCase(expected, actual);
        }

        [Test]
        public void GetStreamIsActiveTrueTest()
        {
            // arrange
            const string excepted = "/api/Stream?isActive=true";

            // act
            var actual = BandCamsEndpoints.GetStream(true);

            // assert
            StringAssert.AreEqualIgnoringCase(excepted, actual);
        }

        [Test]
        public void GetStreamIsActiveFalseTest()
        {
            // arrange
            const string excepted = "/api/Stream?isActive=false";

            // act
            var actual = BandCamsEndpoints.GetStream(false);

            // assert
            StringAssert.AreEqualIgnoringCase(excepted, actual);
        }

        [Test]
        public void GetStreamTest()
        {
            // arrange
            var randomId = new Random().Next(1, 20);
            var expected = $"/api/Stream/{randomId}";

            // act
            var actual = BandCamsEndpoints.GetStream(randomId);

            // assert
            StringAssert.AreEqualIgnoringCase(expected, actual);
        }

        [Test]
        public void StreamTest()
        {
            // arrange
            const string expected = "/api/Stream";

            // act
            var actual = BandCamsEndpoints.Stream;

            // assert
            StringAssert.AreEqualIgnoringCase(expected, actual);
        }
    }
}
