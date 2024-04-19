using Microsoft.AspNetCore.Components;
using FilesSafeReserve.Data.ViewModels;

namespace FilesSafeReserve.Components.Pages.SafeDetailsPage;
public partial class SafeDetailsPage : ComponentBase
{
    [Parameter]
    public required string Id { get; set; }

    public SafeDetailsViewModel ViewModel { get; set; } = new();
}
