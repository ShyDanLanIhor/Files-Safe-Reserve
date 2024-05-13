using FilesSafeReserve.UI.Data.ViewModels;
using Microsoft.AspNetCore.Components;

namespace FilesSafeReserve.UI.Components.Pages.SettingsPage;
public partial class SettingsPage : ComponentBase
{
    public SettingsViewModel ViewModel { get; set; } = new();
}
