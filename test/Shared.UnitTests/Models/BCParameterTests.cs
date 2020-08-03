using System.ComponentModel.DataAnnotations;
using System.Linq;
using NUnit.Framework;
using Shared.Models;

// ReSharper disable InconsistentNaming

namespace Shared.UnitTests.Models
{
    [TestFixture]
    public class BCParameterTests
    {
        [Test]
        public void KeyIsMarkedWithRequiredAttributeTest()
        {
            // arrange
            var propertyName = "Key";
            var propertyInfo = typeof(BCParameter).GetProperty(propertyName);

            // act
            var attribute = propertyInfo?.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            // assert
            Assert.IsNotNull(attribute, $"{propertyName} does not have RequiredAttribute.");
        }

        [Test]
        public void KeyIsMarkedWithMaxLengthAttributeTest()
        {
            // arrange
            var propertyName = "Key";
            var propertyInfo = typeof(BCParameter).GetProperty(propertyName);

            // act
            var attribute = propertyInfo?.GetCustomAttributes(typeof(MaxLengthAttribute), true)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // assert
            Assert.IsNotNull(attribute, $"{propertyName} does not have MaxLengthAttribute.");
        }

        [Test]
        public void ValueIsMarkedWithRequiredAttributeTest()
        {
            // arrange
            var propertyName = "Value";
            var propertyInfo = typeof(BCParameter).GetProperty(propertyName);

            // act
            var attribute = propertyInfo?.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            // assert
            Assert.IsNotNull(attribute, $"{propertyName} does not have RequiredAttribute.");
        }

        [Test]
        public void ValueIsMarkedWithMaxLengthAttributeTest()
        {
            // arrange
            var propertyName = "Value";
            var propertyInfo = typeof(BCParameter).GetProperty(propertyName);

            // act
            var attribute = propertyInfo?.GetCustomAttributes(typeof(MaxLengthAttribute), true)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // assert
            Assert.IsNotNull(attribute, $"{propertyName} does not have MaxLengthAttribute.");
        }
    }
}
