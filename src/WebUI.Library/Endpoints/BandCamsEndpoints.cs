using System;

namespace WebUI.Library.Endpoints
{
    public static class BandCamsEndpoints
    {
        public static string GetOnlineEvent(DateTime fromDate, DateTime toDateTime)
        {
            return $"{OnlineEvent}?fromDate={fromDate.Year}-{fromDate.Month}-{fromDate.Day}&toDate={toDateTime.Year}-{toDateTime.Month}-{toDateTime.Day}";
        }

        public static string GetOnlineEvent(int id)
        {
            return $"{OnlineEvent}/{id}";
        }

        public static string OnlineEvent => "/api/OnlineEvent";

        public static string GetStream(bool isActive)
        {
            return $"{Stream}?isActive={isActive}";
        }

        public static string GetStream(int id)
        {
            return $"{Stream}/{id}";
        }

        public static string Stream => "/api/Stream";
    }
}
