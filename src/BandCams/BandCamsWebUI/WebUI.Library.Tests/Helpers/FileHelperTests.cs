using System.IO;
using System.Text;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using Microsoft.AspNetCore.Http;
using NUnit.Framework;
using WebUI.Library.Helpers;

namespace WebUI.Library.Tests.Helpers
{
    [TestFixture]
    public class FileHelperTests
    {
        [Test]
        public async Task ConvertToByteArrayAsyncReturnsNotEmptyArrayTest()
        {
            // arrange
            using var mock = AutoMock.GetLoose();
            var fileHelper = mock.Create<FileHelper>();
            var file = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("This is a dummy file")), 0, 10, "Data", "dummy.txt");

            // act
            var actual = await fileHelper.ConvertToByteArrayAsync(file);

            // assert
            Assert.True(actual.Length > 0, "Returned array is empty.");
        }
    }
}
