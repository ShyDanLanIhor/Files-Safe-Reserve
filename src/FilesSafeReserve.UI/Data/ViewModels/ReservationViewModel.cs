using BlazorBootstrap;
using FilesSafeReserve.App.Models;
using FilesSafeReserve.Domain.Interfaces;

namespace FilesSafeReserve.UI.Data.ViewModels;

public class ReservationViewModel
{
    public Modal UnknownFileModal { get; set; } = default!;
    public Modal NotFoundModal { get; set; } = default!;
    public Modal AlreadyInReservationModal { get; set; } = default!;
    public Modal IsInSafeDirectoryModal { get; set; } = default!;
    public Modal NoItemWasPickedModal { get; set; } = default!;
    public Modal ReservationProgress { get; set; } = default!;
    public Modal FilterProgress { get; set; } = default!;
    public Modal EmptySearchFieldModal { get; set; } = default!;

    public bool IncludeFiles { get; set; } = true;
    public bool IncludeDirectories { get; set; } = true;

    public bool IsSearched { get; set; }
    public string SearchText { get; set; } = string.Empty;

    public ICollection<KeyValuePair<Guid, IShyPathed>> ItemsList = [];

    public ShortcutModel? OpenSafeShortcut { get; set; }
    public ShortcutModel? ReserveSafeShortcut { get; set; }

    public VirtualSafeModel? VirtualSafe { get; set; }
}
