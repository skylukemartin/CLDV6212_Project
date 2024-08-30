// Sky Martin
// ST404
// Group 2

using Azure.Storage.Blobs;

namespace WebApp.Services;

/// <summary> 
/// The blob service, i.e. the service managing the Azure Storage Blobs.
/// </summary>
/// <remarks>
/// This implementation is based on the Azure SDK for .NET.
/// For educational purposes, refer to:
/// <seealso cref="https://raw.githubusercontent.com/ByronMcCallLecturer/CLDV_SemesterTwo_Byron/536bb18a9f23471d139d74ef1871dea83312ed11/README.md"/>
/// </remarks>
public class BlobService(IConfiguration configuration)
{
    private readonly BlobServiceClient _blobServiceClient = new BlobServiceClient(
        configuration["AzureStorage:ConnectionString"]
    );

    public async Task UploadBlobAsync(string containerName, string blobName, Stream content)
    {
        var containerClient = _blobServiceClient.GetBlobContainerClient(containerName);
        await containerClient.CreateIfNotExistsAsync();
        var blobClient = containerClient.GetBlobClient(blobName);
        await blobClient.UploadAsync(content, true);
    }
}
