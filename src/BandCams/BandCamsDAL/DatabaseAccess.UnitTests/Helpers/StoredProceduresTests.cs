using DatabaseAccess.Helpers;
using NUnit.Framework;
// ReSharper disable InconsistentNaming

namespace DatabaseAccess.UnitTests.Helpers
{
    [TestFixture]
    public class StoredProceduresTests
    {
        [Test]
        public void SpBcParameterGetTest()
        {
            // arrange
            var expected = "spBCParameter_Get";

            // act
            var actual = StoredProcedures.SpBcParameterGet;

            // assert
            Assert.Multiple(() =>
            {
                StringAssert.AreEqualIgnoringCase(expected, actual);
                StringAssert.Contains(expected, actual);
            });
        }

        [Test]
        public void SpBcParameterGetAllTest()
        {
            // arrange
            var expected = "spBCParameter_GetAll";

            // act
            var actual = StoredProcedures.SpBcParameterGetAll;

            // assert
            Assert.Multiple(() =>
            {
                StringAssert.AreEqualIgnoringCase(expected, actual);
                StringAssert.Contains(expected, actual);
            });
        }

        [Test]
        public void SpBcParameterInsertTest()
        {
            // arrange
            var expected = "spBCParameter_Insert";

            // act
            var actual = StoredProcedures.SpBcParameterInsert;

            // assert
            Assert.Multiple(() =>
            {
                StringAssert.AreEqualIgnoringCase(expected, actual);
                StringAssert.Contains(expected, actual);
            });
        }

        [Test]
        public void SpBcParameterUpdateTest()
        {
            // arrange
            var expected = "spBCParameter_Update";

            // act
            var actual = StoredProcedures.SpBcParameterUpdate;

            // assert
            Assert.Multiple(() =>
            {
                StringAssert.AreEqualIgnoringCase(expected, actual);
                StringAssert.Contains(expected, actual);
            });
        }

        [Test]
        public void SpOnlineEventGetTest()
        {
            // arrange
            var expected = "spOnlineEvent_Get";

            // act
            var actual = StoredProcedures.SpOnlineEventGet;

            // assert
            Assert.Multiple(() =>
            {
                StringAssert.AreEqualIgnoringCase(expected, actual);
                StringAssert.Contains(expected, actual);
            });
        }

        [Test]
        public void SpOnlineEventGetAllTest()
        {
            // arrange
            var expected = "spOnlineEvent_GetAll";

            // act
            var actual = StoredProcedures.SpOnlineEventGetAll;

            // assert
            Assert.Multiple(() =>
            {
                StringAssert.AreEqualIgnoringCase(expected, actual);
                StringAssert.Contains(expected, actual);
            });
        }

        [Test]
        public void SpOnlineEventInsertTest()
        {
            // arrange
            var expected = "spOnlineEvent_Insert";

            // act
            var actual = StoredProcedures.SpOnlineEventInsert;

            // assert
            Assert.Multiple(() =>
            {
                StringAssert.AreEqualIgnoringCase(expected, actual);
                StringAssert.Contains(expected, actual);
            });
        }

        [Test]
        public void SpOnlineEventUpdateTest()
        {
            // arrange
            var expected = "spOnlineEvent_Update";

            // act
            var actual = StoredProcedures.SpOnlineEventUpdate;

            // assert
            Assert.Multiple(() =>
            {
                StringAssert.AreEqualIgnoringCase(expected, actual);
                StringAssert.Contains(expected, actual);
            });
        }

        [Test]
        public void SpStreamGetTest()
        {
            // arrange
            var expected = "spStream_Get";

            // act
            var actual = StoredProcedures.SpStreamGet;

            // assert
            Assert.Multiple(() =>
            {
                StringAssert.AreEqualIgnoringCase(expected, actual);
                StringAssert.Contains(expected, actual);
            });
        }

        [Test]
        public void SpStreamGetAllTest()
        {
            // arrange
            var expected = "spStream_GetAll";

            // act
            var actual = StoredProcedures.SpStreamGetAll;

            // assert
            Assert.Multiple(() =>
            {
                StringAssert.AreEqualIgnoringCase(expected, actual);
                StringAssert.Contains(expected, actual);
            });
        }

        [Test]
        public void SpStreamInsertTest()
        {
            // arrange
            var expected = "spStream_Insert";

            // act
            var actual = StoredProcedures.SpStreamInsert;

            // assert
            Assert.Multiple(() =>
            {
                StringAssert.AreEqualIgnoringCase(expected, actual);
                StringAssert.Contains(expected, actual);
            });
        }

        [Test]
        public void SpStreamUpdateTest()
        {
            // arrange
            var expected = "spStream_Update";

            // act
            var actual = StoredProcedures.SpStreamUpdate;

            // assert
            Assert.Multiple(() =>
            {
                StringAssert.AreEqualIgnoringCase(expected, actual);
                StringAssert.Contains(expected, actual);
            });
        }

        [Test]
        public void SpCloseStreamsTest()
        {
            // arrange
            var expected = "spCloseOldStreams";

            // act
            var actual = StoredProcedures.SpCloseOldStreams;

            // assert
            Assert.Multiple(() =>
            {
                StringAssert.AreEqualIgnoringCase(expected, actual);
                StringAssert.Contains(expected, actual);
            });
        }

        [Test]
        public void SpEmailTemplatesGetTest()
        {
            // arrange
            var expected = "spEmailTemplates_Get";

            // act
            var actual = StoredProcedures.SpEmailTemplatesGet;

            // assert
            Assert.Multiple(() =>
            {
                StringAssert.AreEqualIgnoringCase(expected, actual);
                StringAssert.Contains(expected, actual);
            });
        }
    }
}
