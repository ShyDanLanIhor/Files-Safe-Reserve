using FilesSafeReserve.UI.Data.ViewModels;
using Microsoft.AspNetCore.Components;

namespace FilesSafeReserve.UI.Components.Pages.SafeDetailsPage;

public partial class SafeDetailsPage : ComponentBase
{
    [Parameter]
    public required string Id { get; set; }

    public SafeDetailsViewModel ViewModel { get; set; } = new();
}
