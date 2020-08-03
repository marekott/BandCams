using System;
using System.Threading.Tasks;
using Microsoft.Azure.WebJobs;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Scheduler.Models;
using SendGrid;
using SendGrid.Helpers.Mail;

namespace Scheduler
{
    public static class SendEmail
    {
        [FunctionName("SendEmail")]
        public static async Task Run([QueueTrigger("emailqueue", Connection = "BandCamsStorage")] string myQueueItem, ILogger log)
        {
            var emailQueueMessage = JsonConvert.DeserializeObject<EmailQueueMessage>(myQueueItem);
            var msg = CreateEmail(emailQueueMessage);

            var client = new SendGridClient(Environment.GetEnvironmentVariable("SendGridKey"));
            await client.SendEmailAsync(msg);
        }

        private static SendGridMessage CreateEmail(EmailQueueMessage emailQueueMessage)
        {
            var msg = new SendGridMessage
            {
                From = new EmailAddress(emailQueueMessage.SenderEmail, emailQueueMessage.SenderEmailAlias),
                Subject = emailQueueMessage.Subject,
                PlainTextContent = emailQueueMessage.Body,
                HtmlContent = emailQueueMessage.Body,
            };
            msg.AddTo(new EmailAddress(emailQueueMessage.EmailTo));

            return msg;
        }
    }
}
