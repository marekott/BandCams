using System.ComponentModel.DataAnnotations;
using System.Linq;
using NUnit.Framework;
using Shared.Models;

namespace Shared.UnitTests.Models
{
    [TestFixture]
    public class StreamTest
    {
        [Test]
        public void LinkIsMarkedWithRequiredAttributeTest()
        {
            // arrange
            var propertyName = "Link";
            var propertyInfo = typeof(Stream).GetProperty(propertyName);

            // act
            var attribute = propertyInfo?.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            // assert
            Assert.IsNotNull(attribute, $"{propertyName} does not have RequiredAttribute.");
        }

        [Test]
        public void LinkIsMarkedWithMaxLengthAttributeTest()
        {
            // arrange
            var propertyName = "Link";
            var propertyInfo = typeof(Stream).GetProperty(propertyName);

            // act
            var attribute = propertyInfo?.GetCustomAttributes(typeof(MaxLengthAttribute), true)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // assert
            Assert.IsNotNull(attribute, $"{propertyName} does not have MaxLengthAttribute.");
        }

        [Test]
        public void IsActiveIsMarkedWithRequiredAttributeTest()
        {
            // arrange
            var propertyName = "IsActive";
            var propertyInfo = typeof(Stream).GetProperty(propertyName);

            // act
            var attribute = propertyInfo?.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            // assert
            Assert.IsNotNull(attribute, $"{propertyName} does not have RequiredAttribute.");
        }
    }
}
