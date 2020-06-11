using System;
using System.Threading.Tasks;
using ApiHelper;
using Autofac.Extras.Moq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Moq;
using NUnit.Framework;
using WebUI.Library.Helpers;
using WebUI.Library.Validators.Files;
using WebUI.Models;
using WebUI.Pages.OnlineEvents;

namespace WebUI.Tests.Pages.OnlineEvents
{
    [TestFixture]
    public class AddModelTests
    {
        [Test]
        public async Task OnPostInvalidModelStateDoesNotCallPostAsJsonAsyncTest()
        {
            // arrange
            using var mock = AutoMock.GetLoose();
            var addModel = mock.Create<AddModel>();
            addModel.ModelState.AddModelError("","");

            // act
            await addModel.OnPost();

            // assert
            mock.Mock<IHttpHelper>().Verify(x => x.PostAsJsonAsync<It.IsAnyType, OnlineEvent>(It.IsAny<string>(), 
                It.IsAny<OnlineEvent>()), Times.Never);
        }

        [Test]
        public async Task OnPostInvalidModelStateDoesNotCallConvertToByteArrayAsyncTest()
        {
            // arrange
            using var mock = AutoMock.GetLoose();
            var addModel = mock.Create<AddModel>();
            addModel.ModelState.AddModelError("", "");

            // act
            await addModel.OnPost();

            // assert
            mock.Mock<IFileHelper>().Verify(x => x.ConvertToByteArrayAsync(It.IsAny<IFormFile>()), Times.Never);
        }

        [Test]
        public async Task OnPostModelStateAndFileAreValidCallsPostAsJsonAsyncTest()
        {
            using var mock = AutoMock.GetLoose();
            mock.Mock<IFileHelper>()
                .Setup(x => x.ConvertToByteArrayAsync(It.IsAny<IFormFile>()))
                .Returns(Task.FromResult(new[] {Byte.MinValue}));
            mock.Mock<IFileValidator>()
                .Setup(x => x.ValidateSize(It.IsAny<long>()))
                .Returns(true);
            mock.Mock<IFileValidator>()
                .Setup(x => x.ValidateExtension(It.IsAny<string>()))
                .Returns(true);
            mock.Mock<IFileValidator>()
                .Setup(x => x.ValidateSignature(It.IsAny<string>(), It.IsAny<byte[]>()))
                .Returns(true);
            var addModel = mock.Create<AddModel>();
            addModel.OnlineEventImage = new FormFile(null, 1, 1, "test", "test");
            addModel.OnlineEvent = new OnlineEvent();

            // act
            await addModel.OnPost();

            // assert
            mock.Mock<IHttpHelper>().Verify(x => x.PostAsJsonAsync<It.IsAnyType, OnlineEvent>(It.IsAny<string>(), 
                It.IsAny<OnlineEvent>()), Times.Once);
        }

        [Test]
        public async Task OnPostFileSizeIsInvalidDoesNotCallPostAsJsonAsyncTest()
        {
            using var mock = AutoMock.GetLoose();
            mock.Mock<IFileHelper>()
                .Setup(x => x.ConvertToByteArrayAsync(It.IsAny<IFormFile>()))
                .Returns(Task.FromResult(new[] { Byte.MinValue }));
            mock.Mock<IFileValidator>()
                .Setup(x => x.ValidateSize(It.IsAny<long>()))
                .Returns(false);
            mock.Mock<IFileValidator>()
                .Setup(x => x.ValidateExtension(It.IsAny<string>()))
                .Returns(true);
            mock.Mock<IFileValidator>()
                .Setup(x => x.ValidateSignature(It.IsAny<string>(), It.IsAny<byte[]>()))
                .Returns(true);
            var addModel = mock.Create<AddModel>();
            addModel.OnlineEventImage = new FormFile(null, 1, 1, "test", "test");
            addModel.OnlineEvent = new OnlineEvent();

            // act
            await addModel.OnPost();

            // assert
            mock.Mock<IHttpHelper>().Verify(x => x.PostAsJsonAsync<It.IsAnyType, OnlineEvent>(It.IsAny<string>(),
                It.IsAny<OnlineEvent>()), Times.Never);
        }

        [Test]
        public async Task OnPostFileExtensionIsInvalidDoesNotCallPostAsJsonAsyncTest()
        {
            using var mock = AutoMock.GetLoose();
            mock.Mock<IFileHelper>()
                .Setup(x => x.ConvertToByteArrayAsync(It.IsAny<IFormFile>()))
                .Returns(Task.FromResult(new[] { Byte.MinValue }));
            mock.Mock<IFileValidator>()
                .Setup(x => x.ValidateSize(It.IsAny<long>()))
                .Returns(true);
            mock.Mock<IFileValidator>()
                .Setup(x => x.ValidateExtension(It.IsAny<string>()))
                .Returns(false);
            mock.Mock<IFileValidator>()
                .Setup(x => x.ValidateSignature(It.IsAny<string>(), It.IsAny<byte[]>()))
                .Returns(true);
            var addModel = mock.Create<AddModel>();
            addModel.OnlineEventImage = new FormFile(null, 1, 1, "test", "test");
            addModel.OnlineEvent = new OnlineEvent();

            // act
            await addModel.OnPost();

            // assert
            mock.Mock<IHttpHelper>().Verify(x => x.PostAsJsonAsync<It.IsAnyType, OnlineEvent>(It.IsAny<string>(),
                It.IsAny<OnlineEvent>()), Times.Never);
        }

        [Test]
        public async Task OnPostFileSignatureIsInvalidDoesNotCallPostAsJsonAsyncTest()
        {
            using var mock = AutoMock.GetLoose();
            mock.Mock<IFileHelper>()
                .Setup(x => x.ConvertToByteArrayAsync(It.IsAny<IFormFile>()))
                .Returns(Task.FromResult(new[] { Byte.MinValue }));
            mock.Mock<IFileValidator>()
                .Setup(x => x.ValidateSize(It.IsAny<long>()))
                .Returns(true);
            mock.Mock<IFileValidator>()
                .Setup(x => x.ValidateExtension(It.IsAny<string>()))
                .Returns(true);
            mock.Mock<IFileValidator>()
                .Setup(x => x.ValidateSignature(It.IsAny<string>(), It.IsAny<byte[]>()))
                .Returns(false);
            var addModel = mock.Create<AddModel>();
            addModel.OnlineEventImage = new FormFile(null, 1, 1, "test", "test");
            addModel.OnlineEvent = new OnlineEvent();

            // act
            await addModel.OnPost();

            // assert
            mock.Mock<IHttpHelper>().Verify(x => x.PostAsJsonAsync<It.IsAnyType, OnlineEvent>(It.IsAny<string>(),
                It.IsAny<OnlineEvent>()), Times.Never);
        }

        [Test]
        public async Task OnPostFileIsInvalidAddsModelErrorTest()
        {
            using var mock = AutoMock.GetLoose();
            mock.Mock<IFileHelper>()
                .Setup(x => x.ConvertToByteArrayAsync(It.IsAny<IFormFile>()))
                .Returns(Task.FromResult(new[] { Byte.MinValue }));
            mock.Mock<IFileValidator>()
                .Setup(x => x.ValidateSize(It.IsAny<long>()))
                .Returns(true);
            mock.Mock<IFileValidator>()
                .Setup(x => x.ValidateExtension(It.IsAny<string>()))
                .Returns(true);
            mock.Mock<IFileValidator>()
                .Setup(x => x.ValidateSignature(It.IsAny<string>(), It.IsAny<byte[]>()))
                .Returns(false);
            var addModel = mock.Create<AddModel>();
            addModel.OnlineEventImage = new FormFile(null, 1, 1, "test", "test");
            addModel.OnlineEvent = new OnlineEvent();

            // act
            await addModel.OnPost();

            // assert
            Assert.False(addModel.ModelState.IsValid);
        }

        [Test]
        public async Task OnPostSuccessReturnsRedirectResultTest()
        {
            using var mock = AutoMock.GetLoose();
            mock.Mock<IFileHelper>()
                .Setup(x => x.ConvertToByteArrayAsync(It.IsAny<IFormFile>()))
                .Returns(Task.FromResult(new[] { Byte.MinValue }));
            mock.Mock<IFileValidator>()
                .Setup(x => x.ValidateSize(It.IsAny<long>()))
                .Returns(true);
            mock.Mock<IFileValidator>()
                .Setup(x => x.ValidateExtension(It.IsAny<string>()))
                .Returns(true);
            mock.Mock<IFileValidator>()
                .Setup(x => x.ValidateSignature(It.IsAny<string>(), It.IsAny<byte[]>()))
                .Returns(true);
            var addModel = mock.Create<AddModel>();
            addModel.OnlineEventImage = new FormFile(null, 1, 1, "test", "test");
            addModel.OnlineEvent = new OnlineEvent();

            // act
            var actual = await addModel.OnPost();

            // assert
            Assert.IsInstanceOf<RedirectResult>(actual);
        }

        [Test]
        public async Task OnPostInvalidFileReturnsPageResultTest()
        {
            using var mock = AutoMock.GetLoose();
            mock.Mock<IFileHelper>()
                .Setup(x => x.ConvertToByteArrayAsync(It.IsAny<IFormFile>()))
                .Returns(Task.FromResult(new[] { Byte.MinValue }));
            mock.Mock<IFileValidator>()
                .Setup(x => x.ValidateSize(It.IsAny<long>()))
                .Returns(true);
            mock.Mock<IFileValidator>()
                .Setup(x => x.ValidateExtension(It.IsAny<string>()))
                .Returns(true);
            mock.Mock<IFileValidator>()
                .Setup(x => x.ValidateSignature(It.IsAny<string>(), It.IsAny<byte[]>()))
                .Returns(false);
            var addModel = mock.Create<AddModel>();
            addModel.OnlineEventImage = new FormFile(null, 1, 1, "test", "test");
            addModel.OnlineEvent = new OnlineEvent();

            // act
            var actual = await addModel.OnPost();

            // assert
            Assert.IsInstanceOf<PageResult>(actual);
        }

        [Test]
        public async Task OnPostModelStateInvalidReturnsPageResultTest()
        {
            using var mock = AutoMock.GetLoose();
            var addModel = mock.Create<AddModel>();
            addModel.ModelState.AddModelError("key", "error");

            // act
            var actual = await addModel.OnPost();

            // assert
            Assert.IsInstanceOf<PageResult>(actual);
        }
    }
}
