using FilesSafeReserve.UI.Data.ViewModels;
using Microsoft.AspNetCore.Components;

namespace FilesSafeReserve.UI.Components.Pages.LogsPage;
public partial class LogsPage : ComponentBase
{
    [Parameter]
    public required string Id { get; set; }

    public LogsViewModel ViewModel { get; set; } = new();
}
