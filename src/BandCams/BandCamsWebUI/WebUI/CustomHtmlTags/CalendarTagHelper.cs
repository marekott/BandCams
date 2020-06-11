using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Xml.Linq;
using Microsoft.AspNetCore.Razor.TagHelpers;
using WebUI.Models;

namespace WebUI.CustomHtmlTags
{
    [HtmlTargetElement("calendar", TagStructure = TagStructure.NormalOrSelfClosing)]
    public class CalendarTagHelper : TagHelper
    {
        public int Month { get; set; }

        public int Year { get; set; }

        public List<OnlineEvent> Events { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            output.TagName = "section";
            output.Attributes.Add("class", "calendar");
            output.Content.SetHtmlContent(GetHtml());
            output.TagMode = TagMode.StartTagAndEndTag;
        }

        public string GetHtml()
        {
            var currentMonth = new DateTime(Year, Month, 1);
            var eventsByDate = Events?.GroupBy(e => e.StartDate.Date);

            var html = new XDocument(
                new XElement("div",
                    new XAttribute("class", "container-fluid"),
                    new XElement("header",
                        new XElement("div",
                            new XAttribute("class", "mb-3 text-center"),
                            new XElement("button",
                                            new XAttribute("class", "align-middle calendar-button btn"),
                                            new XAttribute("data-toggle", "prev-month"),
                                            new XAttribute("data-url", $"Calendar/?year={Year}&month={Month}&handler=PreviousMonth"),
                                            "<"),
                            new XElement("span",
                                new XAttribute("class", "h4 align-middle calendar-month btn-lg"),
                                currentMonth.ToString("MMMM yyyy")),
                            new XElement("button",
                                            new XAttribute("class", "align-middle calendar-button btn"),
                                            new XAttribute("data-toggle", "next-month"),
                                            new XAttribute("data-url", $"Calendar/?year={Year}&month={Month}&handler=NextMonth"),
                                            ">")

                        ),
                        new XElement("div",
                            new XAttribute("class", "row row-calendar d-none d-lg-flex p-1 text-white"),
                            Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>().Select(d =>
                                new XElement("h5",
                                    new XAttribute("class", "col-lg p-1 text-left"),
                                    new CultureInfo("pl-PL").DateTimeFormat.GetDayName(d)
                                )
                            )
                        )
                    ),
                    new XElement("div",
                        new XAttribute("class", "row row-calendar border border-right-0 border-bottom-0"),
                        GetDatesHtml(currentMonth, eventsByDate)
                    )
                )
            );

            return html.ToString();
        }

        private IEnumerable<XElement> GetDatesHtml(DateTime currentMonth, IEnumerable<IGrouping<DateTime, OnlineEvent>> eventsByDate)
        {
            var startDate = currentMonth.AddDays(-(int)currentMonth.DayOfWeek);
            var dates = Enumerable.Range(0, 42).Select(i => startDate.AddDays(i));
            var mutedClasses = "d-none d-lg-inline-block background-muted text-white";

            foreach (var date in dates)
            {
                if (date.DayOfWeek == DayOfWeek.Sunday && date != startDate)
                {
                    yield return new XElement("div",
                        new XAttribute("class", "w-100"),
                        String.Empty
                    );
                }

                // ReSharper disable once PossibleMultipleEnumeration
                var onlineEventsOn = GetEventsOnHtml(date, eventsByDate);

                yield return new XElement("div",
                    new XAttribute("class", $"{GetDayCss(onlineEventsOn.Count)} col-lg p-2 border border-left-0 border-top-0 text-truncate {(date.Month != currentMonth.Month ? mutedClasses : null)}"),
                    new XElement("h5",
                        new XAttribute("class", "row align-items-start"),
                        new XElement("span",
                            new XAttribute("class", "date col-1 text-white"),
                            date.Day
                        ),
                        new XElement("small",
                            new XAttribute("class", "hide col d-lg-none text-center text-muted"),
                            date.DayOfWeek.ToString()
                        ),
                        new XElement("span",
                            new XAttribute("class", "col-1"),
                            String.Empty
                        )
                    ),
                    GetCellWithEventsHtml(onlineEventsOn)
                );
            }
        }

        private static List<XElement> GetEventsOnHtml(DateTime date, IEnumerable<IGrouping<DateTime, OnlineEvent>> eventsByDate)
        {
            var eventsOn = eventsByDate?.SingleOrDefault(e => e.Key.Date == date.Date)?.ToList();

            if (eventsOn == null)
            {
                return new List<XElement>();
            }

            return eventsOn.Count > 2 ? GetCellWithSummaryHtml(eventsOn) : GetCellWithEventsHtml(eventsOn);
        }

        private static List<XElement> GetCellWithSummaryHtml(List<OnlineEvent> events)
        {
            return new List<XElement>
            {
                new XElement("a",
                    new XAttribute("class",
                        "event d-block p-1 pl-2 pr-2 mb-1 rounded text-truncate small text-white"),
                    new XAttribute("data-toggle", "ajax-modal"),
                    new XAttribute("type", "button"),
                    new XAttribute("data-url",
                        $"Calendar/?year={events.First().StartDate.Year}&month={events.First().StartDate.Month}&day={events.First().StartDate.Day}&handler=ShowModal"),
                    $"+{events.Count} wydarzeń"
                )
            };
        }

        private static List<XElement> GetCellWithEventsHtml(List<OnlineEvent> events)
        {
            return events.Select(e =>
                new XElement("a",
                    new XAttribute("class",
                        "event d-block p-1 pl-1 pr-2 mb-2 rounded text-truncate small text-white"),
                    new XAttribute("type", "button"),
                    new XAttribute("data-toggle", "ajax-modal"),
                    new XAttribute("data-url",
                        $"Calendar/?year={e.StartDate.Year}&month={e.StartDate.Month}&day={e.StartDate.Day}&handler=ShowModal"),
                    e.Name
                )
            ).ToList();
        }

        private static string GetDayCss(int onlineEventsNumber)
        {
            return onlineEventsNumber > 0 ? "day" : "day-empty day";
        }

        private static XElement GetCellWithEventsHtml(List<XElement> onlineEvents)
        {
            if (onlineEvents.Count > 0)
            {
                return new XElement("div",
                    new XAttribute("class",
                        "xs-display-block"),
                    onlineEvents
                );
            }
            else
            {
                return null;
            }
        }
    }
}
