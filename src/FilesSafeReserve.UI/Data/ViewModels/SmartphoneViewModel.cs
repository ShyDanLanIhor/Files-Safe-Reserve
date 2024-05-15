using BlazorBootstrap;
using FilesSafeReserve.App.Models;

namespace FilesSafeReserve.UI.Data.ViewModels;

public class SmartphoneViewModel
{
    public Modal ReservationProgress { get; set; } = default!;
    public Modal ConfirmReservation { get; set; } = default!;
    public Modal ReservationSucceeded { get; set; } = default!;
    public Modal ReservationFailed { get; set; } = default!;
    public VirtualSafeModel SelectedVirtualSafe { get; set; } = null!;
    public List<VirtualSafeModel> VirtualSafes { get; set; } = [];
    public List<string> SmartphonesNames { get; set; } = [];
    public string SelectedSmartphoneName { get; set; } = string.Empty;
}
