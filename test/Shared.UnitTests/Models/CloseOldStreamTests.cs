using System.ComponentModel.DataAnnotations;
using System.Linq;
using NUnit.Framework;
using Shared.Models;

namespace Shared.UnitTests.Models
{
    [TestFixture]
    public class CloseOldStreamTests
    {
        [Test]
        public void DateTimeNowUtcIsMarkedWithRequiredAttributeTest()
        {
            // arrange
            var propertyName = "DateTimeNowUtc";
            var propertyInfo = typeof(CloseOldStream).GetProperty(propertyName);

            // act
            var attribute = propertyInfo?.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            // assert
            Assert.IsNotNull(attribute, $"{propertyName} does not have RequiredAttribute.");
        }

        [Test]
        public void OlderThanInMinutesIsMarkedWithRequiredAttributeTest()
        {
            // arrange
            var propertyName = "OlderThanInMinutes";
            var propertyInfo = typeof(CloseOldStream).GetProperty(propertyName);

            // act
            var attribute = propertyInfo?.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            // assert
            Assert.IsNotNull(attribute, $"{propertyName} does not have RequiredAttribute.");
        }
    }
}
