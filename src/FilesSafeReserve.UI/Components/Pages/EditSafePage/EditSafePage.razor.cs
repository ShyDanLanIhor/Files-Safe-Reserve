using FilesSafeReserve.UI.Data.ViewModels;
using Microsoft.AspNetCore.Components;

namespace FilesSafeReserve.UI.Components.Pages.EditSafePage;

public partial class EditSafePage : ComponentBase
{
    [Parameter]
    public required string Id { get; set; }

    public EditSafeViewModel ViewModel { get; set; } = new();
}
