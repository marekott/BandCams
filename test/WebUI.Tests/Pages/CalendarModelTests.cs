using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiHelper;
using Autofac.Extras.Moq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Routing;
using Moq;
using NUnit.Framework;
using WebUI.Models;
using WebUI.Pages;

namespace WebUI.Tests.Pages
{
    [TestFixture]
    public class CalendarModelTests
    {
        [Test]
        public async Task OnGetCallsGetEndpointOnceTest()
        {
            // arrange
            using var mock = AutoMock.GetLoose();
            mock.Mock<IHttpHelper>()
                .Setup(x => x.GetAsync<It.IsAnyType>(It.IsAny<string>()));
            var calendarModel = mock.Create<CalendarModel>();

            // act
            await calendarModel.OnGet();

            // assert
            mock.Mock<IHttpHelper>().Verify(x => x.GetAsync<It.IsAnyType>(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public async Task OnGetShowModalCallsGetEndpointOnceTest()
        {
            // arrange
            using var mock = AutoMock.GetStrict();
            mock.Mock<IHttpHelper>()
                .Setup(x => x.GetAsync<List<OnlineEvent>>(It.IsAny<string>()))
                .Returns(Task.FromResult(new List<OnlineEvent>
                {
                    new OnlineEvent
                    {
                        StartDate = DateTime.Now
                    }
                }));
            var httpContext = new DefaultHttpContext();
            var modelState = new ModelStateDictionary();
            var actionContext = new ActionContext(httpContext, new RouteData(), new PageActionDescriptor(), modelState);
            var modelMetadataProvider = new EmptyModelMetadataProvider();
            var viewData = new ViewDataDictionary(modelMetadataProvider, modelState);
            var pageContext = new PageContext(actionContext)
            {
                ViewData = viewData
            };
            var calendarModel = mock.Create<CalendarModel>();
            calendarModel.PageContext = pageContext;

            // act
            await calendarModel.OnGetShowModal(200, 10, 1);

            // assert
            mock.Mock<IHttpHelper>().Verify(x => x.GetAsync<It.IsAnyType>(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public async Task OnGetShowModalReturnsOnlyEventsOnPassedDateTest()
        {
            // arrange
            var expected = new DateTime(2020, 04, 10);
            using var mock = AutoMock.GetStrict();
            mock.Mock<IHttpHelper>()
                .Setup(x => x.GetAsync<List<OnlineEvent>>(It.IsAny<string>()))
                .Returns(Task.FromResult(new List<OnlineEvent>
                {
                    new OnlineEvent
                    {
                        StartDate = expected
                    },
                    new OnlineEvent
                    {
                        StartDate = expected
                    }
                }));
            var httpContext = new DefaultHttpContext();
            var modelState = new ModelStateDictionary();
            var actionContext = new ActionContext(httpContext, new RouteData(), new PageActionDescriptor(), modelState);
            var modelMetadataProvider = new EmptyModelMetadataProvider();
            var viewData = new ViewDataDictionary(modelMetadataProvider, modelState);
            var pageContext = new PageContext(actionContext)
            {
                ViewData = viewData
            };
            var calendarModel = mock.Create<CalendarModel>();
            calendarModel.PageContext = pageContext;

            // act
            var result = await calendarModel.OnGetShowModal(expected.Year, expected.Month, expected.Day);
            var actual = result.ViewData.Model as List<OnlineEvent>;

            // assert
            Assert.True(actual != null && actual.All(x => x.StartDate.Date == expected.Date));
        }

        [Test]
        public async Task OnGetShowModalReturnsOnlineEventsPartialTest()
        {
            // arrange
            const string expected = "_OnlineEventsPartial";
            using var mock = AutoMock.GetStrict();
            mock.Mock<IHttpHelper>()
                .Setup(x => x.GetAsync<List<OnlineEvent>>(It.IsAny<string>()))
                .Returns(Task.FromResult(new List<OnlineEvent>
                {
                    new OnlineEvent
                    {
                        StartDate = DateTime.Now
                    }
                }));
            var httpContext = new DefaultHttpContext();
            var modelState = new ModelStateDictionary();
            var actionContext = new ActionContext(httpContext, new RouteData(), new PageActionDescriptor(), modelState);
            var modelMetadataProvider = new EmptyModelMetadataProvider();
            var viewData = new ViewDataDictionary(modelMetadataProvider, modelState);
            var pageContext = new PageContext(actionContext)
            {
                ViewData = viewData
            };
            var calendarModel = mock.Create<CalendarModel>();
            calendarModel.PageContext = pageContext;

            // act
            var actual = await calendarModel.OnGetShowModal(200, 10, 1);

            // assert
            StringAssert.AreEqualIgnoringCase(expected, actual.ViewName);
        }

        [Test]
        public async Task OnGetNextMonthCallGetEndpointTest()
        {
            // arrange
            using var mock = AutoMock.GetStrict();
            mock.Mock<IHttpHelper>()
                .Setup(x => x.GetAsync<List<OnlineEvent>>(It.IsAny<string>()))
                .Returns(Task.FromResult(new List<OnlineEvent>
                {
                    new OnlineEvent
                    {
                        StartDate = DateTime.Now
                    }
                }));
            var calendarModel = mock.Create<CalendarModel>();

            // act
            await calendarModel.OnGetNextMonth(2000, 1);

            // assert
            mock.Mock<IHttpHelper>().Verify(x => x.GetAsync<List<OnlineEvent>>(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public async Task OnGetNextMonthReturnsCalendarTagHtmlTest()
        {
            // arrange
            var expected = "<div class=\"container-fluid\">";
            using var mock = AutoMock.GetStrict();
            mock.Mock<IHttpHelper>()
                .Setup(x => x.GetAsync<List<OnlineEvent>>(It.IsAny<string>()))
                .Returns(Task.FromResult(new List<OnlineEvent>()));
            var calendarModel = mock.Create<CalendarModel>();

            // act
            var result = await calendarModel.OnGetNextMonth(2000, 1);
            var actual = result as ContentResult;

            // assert
            StringAssert.StartsWith(expected, actual?.Content);
        }

        [Test]
        public async Task OnGetPreviousMonthCallGetEndpointTest()
        {
            // arrange
            using var mock = AutoMock.GetStrict();
            mock.Mock<IHttpHelper>()
                .Setup(x => x.GetAsync<List<OnlineEvent>>(It.IsAny<string>()))
                .Returns(Task.FromResult(new List<OnlineEvent>
                {
                    new OnlineEvent
                    {
                        StartDate = DateTime.Now
                    }
                }));
            var calendarModel = mock.Create<CalendarModel>();

            // act
            await calendarModel.OnGetPreviousMonth(2000, 1);

            // assert
            mock.Mock<IHttpHelper>().Verify(x => x.GetAsync<List<OnlineEvent>>(It.IsAny<string>()), Times.Once);
        }

        [Test]
        public async Task OnGetPreviousMonthReturnsCalendarTagHtmlTest()
        {
            // arrange
            var expected = "<div class=\"container-fluid\">";
            using var mock = AutoMock.GetStrict();
            mock.Mock<IHttpHelper>()
                .Setup(x => x.GetAsync<List<OnlineEvent>>(It.IsAny<string>()))
                .Returns(Task.FromResult(new List<OnlineEvent>()));
            var calendarModel = mock.Create<CalendarModel>();

            // act
            var result = await calendarModel.OnGetPreviousMonth(2000, 1);
            var actual = result as ContentResult;

            // assert
            StringAssert.StartsWith(expected, actual?.Content);
        }
    }
}
