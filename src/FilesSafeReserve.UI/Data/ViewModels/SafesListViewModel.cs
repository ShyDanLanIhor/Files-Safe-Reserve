using BlazorBootstrap;
using FilesSafeReserve.App.Models;

namespace FilesSafeReserve.UI.Data.ViewModels;

public class SafesListViewModel
{
    public Modal DeleteSucceededModal { get; set; } = default!;
    public Modal DeleteFailedModal { get; set; } = default!;
    public Modal DeleteModal { get; set; } = default!;
    public Modal ReservationProgress { get; set; } = default!;

    public VirtualSafeModel? SelectedToDeleteVirtualSafe { get; set; }
    public ShortcutModel? ReserveSafesShortcut { get; set; }

    public List<VirtualSafeModel> VirtualSafes { get; set; } = [];
}
