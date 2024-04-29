using BlazorBootstrap;
using FilesSafeReserve.Data.Models;

namespace FilesSafeReserve.Data.ViewModels;

public class SafeDetailsViewModel
{
    public Modal DeleteSucceededModal { get; set; } = default!;
    public Modal DeleteFailedModal { get; set; } = default!;
    public Modal DeleteModal { get; set; } = default!;
    public Modal NotFoundModal { get; set; } = default!;
    public Modal UnknownFileModal { get; set; } = default!;
    public Modal AlreadyInReservationModal { get; set; } = default!;
    public Modal IsInSafeDirectoryModal { get; set; } = default!;
    public Modal NoItemWasPickedModal { get; set; } = default!;
    public VirtualSafeModel? VirtualSafe { get; set; }
}
