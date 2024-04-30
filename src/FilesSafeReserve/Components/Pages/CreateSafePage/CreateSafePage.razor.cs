using FilesSafeReserve.Data.ViewModels;
using Microsoft.AspNetCore.Components;

namespace FilesSafeReserve.Components.Pages.CreateSafePage;
public partial class CreateSafePage : ComponentBase
{
    public CreateSafeViewModel ViewModel { get; set; } = new();
}
