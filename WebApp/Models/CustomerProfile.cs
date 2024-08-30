// Sky Martin
// ST404
// Group 2

using Azure;
using Azure.Data.Tables;

namespace WebApp.Models;

/// <summary>
/// The customer profile table entity.
/// </summary>
/// <remarks>
/// This implementation is based on the Azure SDK for .NET.
/// For educational purposes, refer to:
/// <seealso cref="https://raw.githubusercontent.com/ByronMcCallLecturer/CLDV_SemesterTwo_Byron/536bb18a9f23471d139d74ef1871dea83312ed11/README.md"/>
/// </remarks>
public class CustomerProfile : ITableEntity
{
    public string PartitionKey { get; set; }
    public string RowKey { get; set; }
    public DateTimeOffset? Timestamp { get; set; }
    public ETag ETag { get; set; }

    // Custom properties
    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public required string Email { get; set; }
    public required string PhoneNumber { get; set; }

    public CustomerProfile()
    {
        PartitionKey = "CustomerProfile";
        RowKey = Guid.NewGuid().ToString();
    }
}
