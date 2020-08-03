using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using NUnit.Framework;
using WebUI.Models;

namespace WebUI.Tests.Models
{
    [TestFixture]
    public class StreamTests
    {
        [Test]
        public void LinkValidYoutubeLinkTest()
        {
            // arrange
            var stream = new Stream
            {
                Link = "https://www.youtube.com/watch?v=C7ZSSOJbe68"
            };
            var vc = new ValidationContext(stream, null, null)
            {
                MemberName = "Link"
            };

            // act
            var actual = Validator.TryValidateProperty(stream.Link, vc, new List<ValidationResult>());

            // assert
            Assert.True(actual);
        }

        [Test]
        public void LinkInvalidYoutubeLinkMissingEqualSignTest()
        {
            // arrange
            var stream = new Stream
            {
                Link = "https://www.youtube.com/watch?vC7ZSSOJbe68"
            };
            var vc = new ValidationContext(stream, null, null)
            {
                MemberName = "Link"
            };

            // act
            var actual = Validator.TryValidateProperty(stream.Link, vc, new List<ValidationResult>());

            // assert
            Assert.False(actual);
        }

        [Test]
        public void LinkValidFacebookLinkTest()
        {
            // arrange
            var stream = new Stream
            {
                Link = "https://www.facebook.com/HRejterzy/videos/2540920826201381/"
            };
            var vc = new ValidationContext(stream, null, null)
            {
                MemberName = "Link"
            };

            // act
            var actual = Validator.TryValidateProperty(stream.Link, vc, new List<ValidationResult>());

            // assert
            Assert.True(actual);
        }

        [Test]
        public void LinkInvalidFacebookLinkMissingLastSlashTest()
        {
            // arrange
            var stream = new Stream
            {
                Link = "https://www.facebook.com/HRejterzy/videos/2540920826201381"
            };
            var vc = new ValidationContext(stream, null, null)
            {
                MemberName = "Link"
            };

            // act
            var actual = Validator.TryValidateProperty(stream.Link, vc, new List<ValidationResult>());

            // assert
            Assert.False(actual);
        }

        [Test]
        public void LinkDomainDifferentThanFacebookOrYouTubeTest()
        {
            // arrange
            var stream = new Stream
            {
                Link = "https://www.fake.com/HRejterzy/videos/2540920826201381"
            };
            var vc = new ValidationContext(stream, null, null)
            {
                MemberName = "Link"
            };

            // act
            var actual = Validator.TryValidateProperty(stream.Link, vc, new List<ValidationResult>());

            // assert
            Assert.False(actual);
        }
    }
}
