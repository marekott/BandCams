using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ApiHelper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using WebUI.CustomHtmlTags;
using WebUI.Library.Endpoints;
using WebUI.Models;

namespace WebUI.Pages
{
    public class CalendarModel : PageModel
    {
        private readonly IHttpHelper _httpHelper;
        public List<OnlineEvent> OnlineEvents { get; private set; }

        public CalendarModel(IHttpHelper httpHelper)
        {
            _httpHelper = httpHelper;
        }

        public async Task OnGet()
        {
            var currentMonthDay1 = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);

            OnlineEvents = await GetEventsInMonth(currentMonthDay1);
        }

        public async Task<PartialViewResult> OnGetShowModal(int year, int month, int day)
        {
            var passedDate = new DateTime(year, month, day);

            OnlineEvents = await _httpHelper.GetAsync<List<OnlineEvent>>(BandCamsEndpoints.GetOnlineEvent(passedDate, passedDate.AddDays(1)));

            return new PartialViewResult
            {
                ViewName = "_OnlineEventsPartial",
                ViewData = new ViewDataDictionary<List<OnlineEvent>>(ViewData, OnlineEvents)
            };
        }

        public async Task<IActionResult> OnGetNextMonth(int year, int month)
        {
            var nextMonth = new DateTime(year, month, 1).AddMonths(1);

            var calendarHtml = await GetCalendarHtml(nextMonth);

            return Content(calendarHtml);
        }

        public async Task<IActionResult> OnGetPreviousMonth(int year, int month)
        {
            var previousMonth = new DateTime(year, month, 1).AddMonths(-1);

            var calendarHtml = await GetCalendarHtml(previousMonth);

            return Content(calendarHtml);
        }

        private async Task<string> GetCalendarHtml(DateTime date)
        {
            OnlineEvents = await GetEventsInMonth(date);

            return new CalendarTagHelper
            {
                Month = date.Month,
                Events = OnlineEvents,
                Year = date.Year
            }.GetHtml();
        }

        private Task<List<OnlineEvent>> GetEventsInMonth(DateTime date)
        {
            var fromDate = date.AddDays(-8); //ponieważ widoczna jest zmienna liczba dni z przeszłego i przyszłego miesiąca
            var toDate = date.AddDays(45);

            return _httpHelper.GetAsync<List<OnlineEvent>>(BandCamsEndpoints.GetOnlineEvent(fromDate, toDate));
        }
    }
}