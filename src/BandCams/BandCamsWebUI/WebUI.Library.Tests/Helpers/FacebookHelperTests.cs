using System;
using NUnit.Framework;
using WebUI.Library.Helpers;

namespace WebUI.Library.Tests.Helpers
{
    [TestFixture]
    public class FacebookHelperTests
    {
        [Test]
        public void GetEmbedVideoLinkTest()
        {
            // arrange
            var startingLink = "https://www.facebook.com/NBCNews/videos/213248396772223/";
            var expected = "https://www.facebook.com/video/embed?video_id=213248396772223";

            // act
            var actual = new FacebookHelper().GetEmbedVideoLink(startingLink);

            // assert
            StringAssert.AreEqualIgnoringCase(expected, actual);
        }

        [Test]
        public void GetEmbedVideoLinkThrowsExceptionWhenInvalidLink()
        {
            // arrange
            var startingLink = "https://www.facebook.com/NBCNews/videos/213248396772223"; //without last slash

            // act
            // assert
            Assert.Throws<Exception>(() => new FacebookHelper().GetEmbedVideoLink(startingLink));
        }
    }
}
