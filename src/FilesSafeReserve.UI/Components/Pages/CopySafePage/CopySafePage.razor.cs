using FilesSafeReserve.UI.Data.ViewModels;
using Microsoft.AspNetCore.Components;

namespace FilesSafeReserve.UI.Components.Pages.CopySafePage;
public partial class CopySafePage : ComponentBase
{
    [Parameter]
    public required string Id { get; set; }
    public CopySafeViewModel ViewModel { get; set; } = new();
}
