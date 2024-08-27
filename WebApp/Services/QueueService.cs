using Azure.Storage.Queues;

namespace WebApp.Services;

public class QueueService(IConfiguration configuration)
{
    private readonly QueueServiceClient _queueServiceClient = new QueueServiceClient(
        configuration["AzureStorage:ConnectionString"]
    );

    public async Task SendMessageAsync(string queueName, string message)
    {
        var queueClient = _queueServiceClient.GetQueueClient(queueName);
        await queueClient.CreateIfNotExistsAsync();
        await queueClient.SendMessageAsync(message);
    }
}
