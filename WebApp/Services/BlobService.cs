using Azure.Storage.Blobs;

namespace WebApp.Services;

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
