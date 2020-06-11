using ApiHelper;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using NUnit.Framework;
using WebUI.Library.Helpers;
using WebUI.Library.Validators.Files;

namespace WebUI.Tests
{
    [TestFixture]
    public class StartupTests
    {
        [Test]
        public void StartupRegistersIHttpClientHelperTest()
        {
            // arrange
            var configurationSectionStub = new Mock<IConfigurationSection>();
            configurationSectionStub.Setup(x => x[It.IsAny<string>()]).Returns("https://localhost:0000/");
            var configurationStub = new Mock<IConfiguration>();
            configurationStub.Setup(x => x.GetSection(It.IsAny<string>())).Returns(configurationSectionStub.Object);
            var services = new ServiceCollection();
            var startup = new Startup(configurationStub.Object);

            // act
            startup.ConfigureServices(services);
            var actual = services.BuildServiceProvider().GetService<IHttpClientHelper>();

            // assert
            Assert.IsNotNull(actual);
        }

        [Test]
        public void StartupRegistersIHttpHelperTest()
        {
            // arrange
            var configurationSectionStub = new Mock<IConfigurationSection>();
            configurationSectionStub.Setup(x => x[It.IsAny<string>()]).Returns("https://localhost:0000/");
            var configurationStub = new Mock<IConfiguration>();
            configurationStub.Setup(x => x.GetSection(It.IsAny<string>())).Returns(configurationSectionStub.Object);
            var services = new ServiceCollection();
            var startup = new Startup(configurationStub.Object);

            // act
            startup.ConfigureServices(services);
            var actual = services.BuildServiceProvider().GetService<IHttpHelper>();

            // assert
            Assert.IsNotNull(actual);
        }

        [Test]
        public void StartupRegistersIYouTubeHelperTest()
        {
            // arrange
            var configurationSectionStub = new Mock<IConfigurationSection>();
            configurationSectionStub.Setup(x => x[It.IsAny<string>()]).Returns("https://localhost:0000/");
            var configurationStub = new Mock<IConfiguration>();
            configurationStub.Setup(x => x.GetSection(It.IsAny<string>())).Returns(configurationSectionStub.Object);
            var services = new ServiceCollection();
            var startup = new Startup(configurationStub.Object);

            // act
            startup.ConfigureServices(services);
            var actual = services.BuildServiceProvider().GetService<IYouTubeHelper>();

            // assert
            Assert.IsNotNull(actual);
        }

        [Test]
        public void StartupRegistersIFacebookHelperTest()
        {
            // arrange
            var configurationSectionStub = new Mock<IConfigurationSection>();
            configurationSectionStub.Setup(x => x[It.IsAny<string>()]).Returns("https://localhost:0000/");
            var configurationStub = new Mock<IConfiguration>();
            configurationStub.Setup(x => x.GetSection(It.IsAny<string>())).Returns(configurationSectionStub.Object);
            var services = new ServiceCollection();
            var startup = new Startup(configurationStub.Object);

            // act
            startup.ConfigureServices(services);
            var actual = services.BuildServiceProvider().GetService<IFacebookHelper>();

            // assert
            Assert.IsNotNull(actual);
        }

        [Test]
        public void StartupRegistersIFileHelperTest()
        {
            // arrange
            var configurationSectionStub = new Mock<IConfigurationSection>();
            configurationSectionStub.Setup(x => x[It.IsAny<string>()]).Returns("https://localhost:0000/");
            var configurationStub = new Mock<IConfiguration>();
            configurationStub.Setup(x => x.GetSection(It.IsAny<string>())).Returns(configurationSectionStub.Object);
            var services = new ServiceCollection();
            var startup = new Startup(configurationStub.Object);

            // act
            startup.ConfigureServices(services);
            var actual = services.BuildServiceProvider().GetService<IFileHelper>();

            // assert
            Assert.IsNotNull(actual);
        }

        [Test]
        public void StartupRegistersIFileValidatorTest()
        {
            // arrange
            var configurationSectionStub = new Mock<IConfigurationSection>();
            configurationSectionStub.Setup(x => x[It.IsAny<string>()]).Returns("https://localhost:0000/");
            var configurationStub = new Mock<IConfiguration>();
            configurationStub.Setup(x => x.GetSection(It.IsAny<string>())).Returns(configurationSectionStub.Object);
            var services = new ServiceCollection();
            var startup = new Startup(configurationStub.Object);

            // act
            startup.ConfigureServices(services);
            var actual = services.BuildServiceProvider().GetService<IFileValidator>();

            // assert
            Assert.IsNotNull(actual);
        }
    }
}
