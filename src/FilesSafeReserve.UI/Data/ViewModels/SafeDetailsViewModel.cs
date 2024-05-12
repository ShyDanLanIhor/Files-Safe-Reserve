using BlazorBootstrap;
using FilesSafeReserve.App.Models;

namespace FilesSafeReserve.UI.Data.ViewModels;

public class SafeDetailsViewModel
{
    public Modal DeleteSucceededModal { get; set; } = default!;
    public Modal DeleteFailedModal { get; set; } = default!;
    public Modal DeleteModal { get; set; } = default!;
    public Modal NotFoundModal { get; set; } = default!;
    public Modal ReservationProgress { get; set; } = default!;

    public ShortcutModel? OpenSafeShortcut { get; set; }
    public ShortcutModel? ReserveSafeShortcut { get; set; }

    public TimeOnly? ReservationTimeOnly { get; set; }

    public VirtualSafeModel? VirtualSafe { get; set; }
}
