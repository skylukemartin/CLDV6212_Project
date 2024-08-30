// Sky Martin
// ST10286905
/// Group 2

using Azure.Data.Tables;
using WebApp.Models;

namespace WebApp.Services;

/// <summary> 
/// The table service, i.e. the service managing the Azure Storage Tables.
/// </summary>
/// <remarks>
/// This implementation is based on the Azure SDK for .NET.
/// For educational purposes, refer to:
/// <seealso cref="https://raw.githubusercontent.com/ByronMcCallLecturer/CLDV_SemesterTwo_Byron/536bb18a9f23471d139d74ef1871dea83312ed11/README.md"/>
/// </remarks>
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
