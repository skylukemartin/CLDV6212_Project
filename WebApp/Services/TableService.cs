using Azure.Data.Tables;
using WebApp.Models;

namespace WebApp.Services;

public class TableService
{
    private readonly TableClient _tableClient;

    public TableService(IConfiguration configuration)
    {
        var connectionString = configuration["AzureStorage:ConnectionString"];
        var serviceClient = new TableServiceClient(connectionString);
        _tableClient = serviceClient.GetTableClient("CustomerProfiles");
        _tableClient.CreateIfNotExists();
    }

    public async Task AddEntityAsync(CustomerProfile profile) =>
        await _tableClient.AddEntityAsync(profile);
}
