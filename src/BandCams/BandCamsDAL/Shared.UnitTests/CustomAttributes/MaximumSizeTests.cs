using System;
using System.Collections.Generic;
using NUnit.Framework;
using Shared.CustomAttributes;

// ReSharper disable ObjectCreationAsStatement

namespace Shared.UnitTests.CustomAttributes
{
    [TestFixture]
    public class MaximumSizeTests
    {
        [Test]
        public void MaximumSizeThrowsExceptionIfMaxSizeIsLessThan1Test()
        {
            // arrange
            long maxSize = 0;

            // act
            // assert
            Assert.Throws<ArgumentOutOfRangeException>(() => new MaximumSize(maxSize));
        }

        [Test]
        public void MaximumSizeDoesNotThrowsExceptionIfMaxSizeIsMoreThan0Test()
        {
            // arrange
            long maxSize = 1;

            // act
            // assert
            Assert.DoesNotThrow(() => new MaximumSize(maxSize));
        }

        [Test]
        public void ErrorMessageTest()
        {
            // arrange
            long maxSize = new Random().Next(1,10);
            var expectedErrorMessage = $"{nameof(ErrorMessageTest)} can contain max {maxSize} elements.";

            // act
            var actual = new MaximumSize(maxSize);

            // assert
            StringAssert.AreEqualIgnoringCase(expectedErrorMessage, actual.ErrorMessage);
        }

        [Test]
        public void AttributeIsValidTest()
        {
            // arrange
            var list = new List<string> {"test"};
            var attribute = new MaximumSize(2);

            // act
            var actual = attribute.IsValid(list);

            // assert
            Assert.True(actual);
        }

        [Test]
        public void AttributeIsInvalidTest()
        {
            // arrange
            var list = new List<string> { "test", "test", "test" };
            var attribute = new MaximumSize(2);

            // act
            var actual = attribute.IsValid(list);

            // assert
            Assert.False(actual);
        }

        [Test]
        public void AttributeIsInvalidWhenCollectionIsNullTest()
        {
            // arrange
            var attribute = new MaximumSize(2);

            // act
            var actual = attribute.IsValid(null);

            // assert
            Assert.False(actual);
        }
    }
}