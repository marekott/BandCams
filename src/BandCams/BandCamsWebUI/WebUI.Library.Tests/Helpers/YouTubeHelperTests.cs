using System;
using NUnit.Framework;
using WebUI.Library.Helpers;

namespace WebUI.Library.Tests.Helpers
{
    [TestFixture]
    public class YouTubeHelperTests
    {
        [Test]
        public void GetEmbedVideoLinkTest()
        {
            // arrange
            var startingLink = "https://www.youtube.com/watch?v=4LJ1MCFbuIo";
            var expected = "https://www.youtube.com/embed/4LJ1MCFbuIo";

            // act
            var actual = new YouTubeHelper().GetEmbedVideoLink(startingLink);

            // assert
            StringAssert.AreEqualIgnoringCase(expected, actual);
        }

        [Test]
        public void GetEmbedVideoLinkThrowsExceptionWhenInvalidLink()
        {
            // arrange
            var startingLink = "https://www.youtube.com/embed/4LJ1MCFbuIo";

            // act
            // assert
            Assert.Throws<Exception>(() => new YouTubeHelper().GetEmbedVideoLink(startingLink));
        }

        [Test]
        public void GetThumbnailLinkTest()
        {
            // arrange
            var startingLink = "https://www.youtube.com/embed/z9Ul9ccDOqE";
            var expected = "https://img.youtube.com/vi/z9Ul9ccDOqE/0.jpg";

            // act
            var actual = new YouTubeHelper().GetThumbnailLink(startingLink);

            // assert
            StringAssert.AreEqualIgnoringCase(expected, actual);
        }
    }
}
