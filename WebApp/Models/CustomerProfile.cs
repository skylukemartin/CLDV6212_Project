using Azure;
using Azure.Data.Tables;

namespace WebApp.Models;

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
