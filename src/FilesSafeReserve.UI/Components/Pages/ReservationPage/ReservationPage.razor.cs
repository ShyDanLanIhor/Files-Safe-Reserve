using FilesSafeReserve.UI.Data.ViewModels;
using Microsoft.AspNetCore.Components;

namespace FilesSafeReserve.UI.Components.Pages.ReservationPage;
public partial class ReservationPage : ComponentBase
{
    [Parameter]
    public required string Id { get; set; }

    public ReservationViewModel ViewModel { get; set; } = new();
}
