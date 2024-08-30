// Author: Sky Martin
// ST404
// Group 2

/// <remarks>
// This project is for educational purposes only.
// It is part of the Cloud Development course at VC.
// While based on real-world scenarios, it is not intended for production use without further review and modification.
/// <seealso cref="https://learn.microsoft.com/en-us/search/?terms=ErrorViewModel"/>
/// </remarks>

namespace WebApp.Models;

/// <summary>
/// The View Model for the error view model.
/// </summary>

public class ErrorViewModel
{
    public string? RequestId { get; set; }

    public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
}
