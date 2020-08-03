using System.ComponentModel.DataAnnotations;
using System.Linq;
using NUnit.Framework;
using Shared.CustomAttributes;
using Shared.Models;

namespace Shared.UnitTests.Models
{
    [TestFixture]
    public class OnlineEventTests
    {
        [Test]
        public void NameIsMarkedWithRequiredAttributeTest()
        {
            // arrange
            var propertyName = "Name";
            var propertyInfo = typeof(OnlineEvent).GetProperty(propertyName);

            // act
            var attribute = propertyInfo?.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            // assert
            Assert.IsNotNull(attribute, $"{propertyName} does not have RequiredAttribute.");
        }

        [Test]
        public void NameIsMarkedWithMaxLengthAttributeTest()
        {
            // arrange
            var propertyName = "Name";
            var propertyInfo = typeof(OnlineEvent).GetProperty(propertyName);

            // act
            var attribute = propertyInfo?.GetCustomAttributes(typeof(MaxLengthAttribute), true)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // assert
            Assert.IsNotNull(attribute, $"{propertyName} does not have MaxLengthAttribute.");
        }

        [Test]
        public void DescriptionIsMarkedWithRequiredAttributeTest()
        {
            // arrange
            var propertyName = "Description";
            var propertyInfo = typeof(OnlineEvent).GetProperty(propertyName);

            // act
            var attribute = propertyInfo?.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            // assert
            Assert.IsNotNull(attribute, $"{propertyName} does not have RequiredAttribute.");
        }

        [Test]
        public void DescriptionIsMarkedWithMaxLengthAttributeTest()
        {
            // arrange
            var propertyName = "Description";
            var propertyInfo = typeof(OnlineEvent).GetProperty(propertyName);

            // act
            var attribute = propertyInfo?.GetCustomAttributes(typeof(MaxLengthAttribute), true)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // assert
            Assert.IsNotNull(attribute, $"{propertyName} does not have MaxLengthAttribute.");
        }

        [Test]
        public void StartDateIsMarkedWithRequiredAttributeTest()
        {
            // arrange
            var propertyName = "StartDate";
            var propertyInfo = typeof(OnlineEvent).GetProperty(propertyName);

            // act
            var attribute = propertyInfo?.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            // assert
            Assert.IsNotNull(attribute, $"{propertyName} does not have RequiredAttribute.");
        }

        [Test]
        public void OrganizerIsMarkedWithRequiredAttributeTest()
        {
            // arrange
            var propertyName = "Organizer";
            var propertyInfo = typeof(OnlineEvent).GetProperty(propertyName);

            // act
            var attribute = propertyInfo?.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            // assert
            Assert.IsNotNull(attribute, $"{propertyName} does not have RequiredAttribute.");
        }

        [Test]
        public void OrganizerIsMarkedWithMaxLengthAttributeTest()
        {
            // arrange
            var propertyName = "Organizer";
            var propertyInfo = typeof(OnlineEvent).GetProperty(propertyName);

            // act
            var attribute = propertyInfo?.GetCustomAttributes(typeof(MaxLengthAttribute), true)
                .Cast<MaxLengthAttribute>()
                .FirstOrDefault();

            // assert
            Assert.IsNotNull(attribute, $"{propertyName} does not have MaxLengthAttribute.");
        }

        [Test]
        public void ImageContentIsMarkedWithRequiredAttributeTest()
        {
            // arrange
            var propertyName = "ImageContent";
            var propertyInfo = typeof(OnlineEvent).GetProperty(propertyName);

            // act
            var attribute = propertyInfo?.GetCustomAttributes(typeof(RequiredAttribute), true)
                .Cast<RequiredAttribute>()
                .FirstOrDefault();

            // assert
            Assert.IsNotNull(attribute, $"{propertyName} does not have RequiredAttribute.");
        }

        [Test]
        public void ImageContentIsMarkedWithMaximumSizeAttributeTest()
        {
            // arrange
            var propertyName = "ImageContent";
            var propertyInfo = typeof(OnlineEvent).GetProperty(propertyName);

            // act
            var attribute = propertyInfo?.GetCustomAttributes(typeof(MaximumSize), true)
                .Cast<MaximumSize>()
                .FirstOrDefault();

            // assert
            Assert.IsNotNull(attribute, $"{propertyName} does not have MaximumSize attribute.");
        }
    }
}
