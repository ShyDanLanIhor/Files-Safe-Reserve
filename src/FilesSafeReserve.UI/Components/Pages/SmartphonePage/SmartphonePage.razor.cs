using FilesSafeReserve.UI.Data.ViewModels;
using Microsoft.AspNetCore.Components;

namespace FilesSafeReserve.UI.Components.Pages.SmartphonePage;
public partial class SmartphonePage : ComponentBase
{
    public SmartphoneViewModel ViewModel { get; set; } = new();
}
