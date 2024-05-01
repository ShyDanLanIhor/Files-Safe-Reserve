using FilesSafeReserve.UI.Data.ViewModels;
using Microsoft.AspNetCore.Components;

namespace FilesSafeReserve.UI.Components.Pages.CreateSafePage;

public partial class CreateSafePage : ComponentBase
{
    public CreateSafeViewModel ViewModel { get; set; } = new();
}
