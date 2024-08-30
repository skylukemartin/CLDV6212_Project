// Sky Martin
// ST404
// Group 2

using Azure.Storage.Files.Shares;

namespace WebApp.Services;

/// <summary> 
/// The file service, i.e. the service managing the Azure Storage Files.
/// </summary>
/// <remarks>
/// This implementation is based on the Azure SDK for .NET.
/// For educational purposes, refer to:
/// <seealso cref="https://raw.githubusercontent.com/ByronMcCallLecturer/CLDV_SemesterTwo_Byron/536bb18a9f23471d139d74ef1871dea83312ed11/README.md"/>
/// </remarks>
public class FileService(IConfiguration configuration)
{
    private readonly ShareServiceClient _shareServiceClient = new ShareServiceClient(
        configuration["AzureStorage:ConnectionString"]
    );

    public async Task UploadFileAsync(string shareName, string fileName, Stream content)
    {
        var shareClient = _shareServiceClient.GetShareClient(shareName);
        await shareClient.CreateIfNotExistsAsync();
        var directoryClient = shareClient.GetRootDirectoryClient();
        var fileClient = directoryClient.GetFileClient(fileName);
        await fileClient.CreateAsync(content.Length);
        await fileClient.UploadAsync(content);
    }
}
