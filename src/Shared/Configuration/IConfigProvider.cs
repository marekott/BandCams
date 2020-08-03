namespace Shared.Configuration
{
    public interface IConfigProvider
    {
        string GetConnectionString(Application application);
        string GetQueueName(Queue queue);
    }
}
