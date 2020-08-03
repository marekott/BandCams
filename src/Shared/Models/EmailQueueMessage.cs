namespace Shared.Models
{
    public class EmailQueueMessage
    {
        public string EmailTo { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string SenderEmail { get; set; }
        public string SenderEmailAlias { get; set; }
    }
}
