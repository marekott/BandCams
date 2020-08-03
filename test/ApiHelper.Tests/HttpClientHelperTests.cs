using System;
using NUnit.Framework;

namespace ApiHelper.Tests
{
    [TestFixture]
    public class HttpClientHelperTests
    {
        [Test]
        public void ConstructorValidUriTest()
        {
            // arrange
            // act
            // assert
            Assert.DoesNotThrow(() =>
            {
                // ReSharper disable once UnusedVariable
                var httpClientHelper = new HttpClientHelper("https://localhost:0000/", "key");
            });
        }

        [Test]
        public void ConstructorInvalidUriTest()
        {
            // arrange
            // act
            // assert
            Assert.Throws<UriFormatException>(() =>
            {
                // ReSharper disable once UnusedVariable
                var httpClientHelper = new HttpClientHelper("test", "key");
            });
        }
    }
}