using BlazorBootstrap;
using FilesSafeReserve.App.Models;

namespace FilesSafeReserve.UI.Data.ViewModels;

public class SettingsViewModel
{
    public Modal ReserveTimeChangingSucceededModal { get; set; } = default!;
    public Modal ReserveTimeClearingConfirmModal { get; set; } = default!;
    public Modal ReserveTimeChangingConfirmModal { get; set; } = default!;
    public Modal NotEnteredReserveTimeModal { get; set; } = default!;
    public Modal ShortcutSavingSucceededModal { get; set; } = default!;
    public Modal ShortcutInputAwaiterModal { get; set; } = default!;

    public bool ChangeExistingReservationTime { get; set; } = true;
    public TimeOnly? ReservationTimeOnly { get; set; }

    public ICollection<ReservationModel> Reservations { get; set; } = [];
    public ICollection<ShortcutModel> Shortcuts { get; set; } = [];
}
