using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers;

public class HomeController(
    BlobService blobService,
    TableService tableService,
    QueueService queueService,
    FileService fileService
) : Controller
{
    private readonly BlobService _blobService = blobService;
    private readonly TableService _tableService = tableService;
    private readonly QueueService _queueService = queueService;
    private readonly FileService _fileService = fileService;

    public IActionResult Index() => View();

    [HttpPost]
    public async Task<IActionResult> UploadImage(IFormFile file)
    {
        if (file != null)
        {
            using var stream = file.OpenReadStream();
            await _blobService.UploadBlobAsync("product-images", file.FileName, stream);
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> AddCustomerProfile(CustomerProfile profile)
    {
        if (ModelState.IsValid)
        {
            await _tableService.AddEntityAsync(profile);
        }
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> ProcessOrder(string orderId)
    {
        await _queueService.SendMessageAsync("order-processing", $"Processing order {orderId}");
        return RedirectToAction("Index");
    }

    [HttpPost]
    public async Task<IActionResult> UploadContract(IFormFile file)
    {
        if (file != null)
        {
            using var stream = file.OpenReadStream();
            await _fileService.UploadFileAsync("contracts-logs", file.FileName, stream);
        }
        return RedirectToAction("Index");
    }
}
