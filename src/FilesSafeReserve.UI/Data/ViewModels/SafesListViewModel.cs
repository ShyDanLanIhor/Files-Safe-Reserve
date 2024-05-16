using BlazorBootstrap;
using FilesSafeReserve.App.Models;
using FilesSafeReserve.App.Watchers;

namespace FilesSafeReserve.UI.Data.ViewModels;

public class SafesListViewModel : IDisposable
{
    public List<FileSystemWatcher> FileSystemWatchers = [];
    public DriveWatcher DriveWatcher = new();

    public Modal DeleteSucceededModal { get; set; } = default!;
    public Modal DeleteFailedModal { get; set; } = default!;
    public Modal DeleteModal { get; set; } = default!;
    public Modal ReservationProgress { get; set; } = default!;

    public VirtualSafeModel? SelectedToDeleteVirtualSafe { get; set; }
    public ShortcutModel? ReserveSafesShortcut { get; set; }

    public ICollection<VirtualSafeModel> VirtualSafes { get; set; } = [];

    public void Dispose()
    {
        FileSystemWatchers.ForEach(watcher => watcher.Dispose());
        FileSystemWatchers.Clear();
        DriveWatcher.Dispose();
    }
}
