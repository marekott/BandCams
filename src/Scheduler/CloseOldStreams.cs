using System;
using System.Threading.Tasks;
using ApiHelper;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;

namespace Scheduler
{
    public static class CloseOldStreams
    {
        [FunctionName("CloseOldStreams")]
        public static async Task Run([TimerTrigger("0 0 */2 * * *")]TimerInfo myTimer, ILogger log)
        {
            var httpHelper = CreateHttpHelper();

            await httpHelper.PostAsJsonAsync("/api/StoredProcedures/CloseOldStreams",
                new { dateTimeNowUtc = DateTime.UtcNow, olderThanInMinutes = 120});
        }

        private static HttpHelper CreateHttpHelper()
        {
            var bandCamsDalUrl = Environment.GetEnvironmentVariable("BandCamsDAL");
            var apiManagementServiceKey = Environment.GetEnvironmentVariable("APIManagementServiceKey");
            var httpClientHelper = new HttpClientHelper(bandCamsDalUrl, apiManagementServiceKey);
            return new HttpHelper(httpClientHelper);
        }
    }
}
