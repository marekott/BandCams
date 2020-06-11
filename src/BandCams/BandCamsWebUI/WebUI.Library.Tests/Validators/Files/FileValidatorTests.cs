using NUnit.Framework;
using WebUI.Library.Validators.Files;

namespace WebUI.Library.Tests.Validators.Files
{
    [TestFixture]
    public class FileValidatorTests
    {
        [Test]
        public void ValidateExtensionFileNameIsNullReturnsFalseTest()
        {
            // arrange
            // act
            var actual = new FileValidator().ValidateExtension(null);

            // assert
            Assert.False(actual);
        }

        [Test]
        public void ValidateExtensionFileNameIsEmptyStringReturnsFalseTest()
        {
            // arrange
            // act
            var actual = new FileValidator().ValidateExtension("");

            // assert
            Assert.False(actual);
        }

        [Test]
        public void ValidateExtensionJpegReturnsTrueTestTest()
        {
            // arrange
            var fileName = "test.jpeg";

            // act
            var actual = new FileValidator().ValidateExtension(fileName);

            // assert
            Assert.True(actual);
        }

        [Test]
        public void ValidateExtensionJpgReturnsTrueTestTest()
        {
            // arrange
            var fileName = "test.jpg";

            // act
            var actual = new FileValidator().ValidateExtension(fileName);

            // assert
            Assert.True(actual);
        }

        [Test]
        public void ValidateSignatureValidJpeg1ReturnTrueTest()
        {
            // arrange
            var fileName = "test.jpeg";
            var binaryFile = new byte[] {0xFF, 0xD8, 0xFF, 0xE0};

            // act
            var actual = new FileValidator().ValidateSignature(fileName, binaryFile);

            // assert
            Assert.True(actual);
        }

        [Test]
        public void ValidateSignatureValidJpeg2ReturnTrueTest()
        {
            // arrange
            var fileName = "test.jpeg";
            var binaryFile = new byte[] { 0xFF, 0xD8, 0xFF, 0xE2 };

            // act
            var actual = new FileValidator().ValidateSignature(fileName, binaryFile);

            // assert
            Assert.True(actual);
        }

        [Test]
        public void ValidateSignatureValidJpeg3ReturnTrueTest()
        {
            // arrange
            var fileName = "test.jpeg";
            var binaryFile = new byte[] { 0xFF, 0xD8, 0xFF, 0xE3 };

            // act
            var actual = new FileValidator().ValidateSignature(fileName, binaryFile);

            // assert
            Assert.True(actual);
        }

        [Test]
        public void ValidateSignatureValidJpg1ReturnTrueTest()
        {
            // arrange
            var fileName = "test.jpg";
            var binaryFile = new byte[] { 0xFF, 0xD8, 0xFF, 0xE0 };

            // act
            var actual = new FileValidator().ValidateSignature(fileName, binaryFile);

            // assert
            Assert.True(actual);
        }

        [Test]
        public void ValidateSignatureValidJpg2ReturnTrueTest()
        {
            // arrange
            var fileName = "test.jpg";
            var binaryFile = new byte[] { 0xFF, 0xD8, 0xFF, 0xE1 };

            // act
            var actual = new FileValidator().ValidateSignature(fileName, binaryFile);

            // assert
            Assert.True(actual);
        }

        [Test]
        public void ValidateSignatureValidJpg3ReturnTrueTest()
        {
            // arrange
            var fileName = "test.jpg";
            var binaryFile = new byte[] { 0xFF, 0xD8, 0xFF, 0xE8 };

            // act
            var actual = new FileValidator().ValidateSignature(fileName, binaryFile);

            // assert
            Assert.True(actual);
        }

        [Test]
        public void ValidateSignatureValidPngReturnTrueTest()
        {
            // arrange
            var fileName = "test.png";
            var binaryFile = new byte[] {0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A};
            
            // act
            var actual = new FileValidator().ValidateSignature(fileName, binaryFile);

            // assert
            Assert.True(actual);
        }

        [Test]
        public void ValidateSignatureInvalidJpegReturnsFalseTest()
        {
            // arrange
            var fileName = "test.jpeg";
            var binaryFile = new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };

            // act
            var actual = new FileValidator().ValidateSignature(fileName, binaryFile);

            // assert
            Assert.False(actual);
        }

        [Test]
        public void ValidateSignatureInvalidJpgReturnsFalseTest()
        {
            // arrange
            var fileName = "test.jpg";
            var binaryFile = new byte[] { 0x89, 0x50, 0x4E, 0x47, 0x0D, 0x0A, 0x1A, 0x0A };

            // act
            var actual = new FileValidator().ValidateSignature(fileName, binaryFile);

            // assert
            Assert.False(actual);
        }

        [Test]
        public void ValidateSignatureInvalidPngReturnsFalseTest()
        {
            // arrange
            var fileName = "test.png";
            var binaryFile = new byte[] { 0xFF, 0xD8, 0xFF, 0xE0, 0xFF, 0xD8, 0xFF, 0xE0 };

            // act
            var actual = new FileValidator().ValidateSignature(fileName, binaryFile);

            // assert
            Assert.False(actual);
        }

        [Test]
        public void ValidateSignatureFileNameIsNullReturnsFalseTest()
        {
            // arrange
            var binaryFile = new byte[] { 0xFF, 0xD8, 0xFF, 0xE0, 0xFF, 0xD8, 0xFF, 0xE0 };

            // act
            var actual = new FileValidator().ValidateSignature(null, binaryFile);

            // assert
            Assert.False(actual);
        }

        [Test]
        public void ValidateSizeReturnTrueTest()
        {
            // arrange
            var fileSize = 1000;

            // act
            var actual = new FileValidator().ValidateSize(fileSize);

            // arrange
            Assert.True(actual);
        }

        [Test]
        public void ValidateSizeReturnFalseTest()
        {
            // arrange
            var fileSize = 2097153;

            // act
            var actual = new FileValidator().ValidateSize(fileSize);

            // arrange
            Assert.False(actual);
        }

        [Test]
        public void GetMaxFileSizeInMbTest()
        {
            // arrange
            var expected = "2MB";

            // act
            var actual = new FileValidator().GetMaxFileSizeInMb;

            // arrange
            StringAssert.AreEqualIgnoringCase(expected, actual);
        }

        [Test]
        public void GetPermittedExtensionsTest()
        {
            // arrange
            var expected = ".jpeg, .jpg, .png";

            // act
            var actual = new FileValidator().GetPermittedExtensions;

            // arrange
            StringAssert.AreEqualIgnoringCase(expected, actual);
        }
    }
}
