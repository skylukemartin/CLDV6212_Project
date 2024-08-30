// Sky Martin
// ST10286905
// Group 2

using Azure.Storage.Queues;

namespace WebApp.Services;

/// <summary> 
/// The queue service, i.e. the service managing the Azure Queues.
/// </summary>
/// <remarks>
/// This implementation is based on the Azure SDK for .NET.
/// For educational purposes, refer to:
/// <seealso cref="https://raw.githubusercontent.com/ByronMcCallLecturer/CLDV_SemesterTwo_Byron/536bb18a9f23471d139d74ef1871dea83312ed11/README.md"/>
/// </remarks>
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
