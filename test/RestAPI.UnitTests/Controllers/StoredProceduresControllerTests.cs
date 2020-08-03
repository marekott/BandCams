using System;
using System.Threading.Tasks;
using Autofac.Extras.Moq;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using RestAPI.Controllers;
using Shared.Models;

namespace RestAPI.UnitTests.Controllers
{
    [TestFixture]
    public class StoredProceduresControllerTests
    {
        [Test]
        public async Task CloseStreamsReturnsOkResultTest()
        {
            // arrange
            using var mock = AutoMock.GetLoose();
            var storedProceduresController = mock.Create<StoredProceduresController>();

            // act
            var actual = await storedProceduresController.CloseOldStreams(new CloseOldStream{OlderThanInMinutes = 120, DateTimeNowUtc = DateTime.UtcNow });

            // assert
            Assert.IsInstanceOf<OkResult>(actual);
        }
    }
}
