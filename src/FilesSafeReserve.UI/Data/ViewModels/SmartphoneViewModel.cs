using BlazorBootstrap;
using FilesSafeReserve.App.Models;
using FilesSafeReserve.App.Watchers;

namespace FilesSafeReserve.UI.Data.ViewModels;

public class SmartphoneViewModel : IDisposable
{
    public List<FileSystemWatcher> FileSystemWatchers = [];
    public DriveWatcher DriveWatcher = new();

    public Modal ReservationProgress { get; set; } = default!;
    public Modal ConfirmReservation { get; set; } = default!;
    public Modal ReservationSucceeded { get; set; } = default!;
    public Modal ReservationFailed { get; set; } = default!;
    public Modal SafeIsNotSelected { get; set; } = default!;
    public VirtualSafeModel? SelectedVirtualSafe { get; set; }
    public List<VirtualSafeModel> VirtualSafes { get; set; } = [];
    public List<string> SmartphonesNames { get; set; } = [];
    public string SelectedSmartphoneName { get; set; } = string.Empty;

    public void Dispose()
    {
        FileSystemWatchers.ForEach(watcher => watcher.Dispose());
        FileSystemWatchers.Clear();
        DriveWatcher.Dispose();
    }
}
