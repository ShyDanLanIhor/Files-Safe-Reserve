using BlazorBootstrap;
using FilesSafeReserve.App.Models;

namespace FilesSafeReserve.UI.Data.ViewModels;

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
    private string _reservationTimeOfDay = string.Empty;
    public string ReservationTimeOfDay
    {
        get => _reservationTimeOfDay;
        set
        {
            TimeSpan timeSpan;
            if (TimeSpan.TryParse(value, out timeSpan) && value != string.Empty)
            {
                _reservationTimeOfDay += value;
                TimeOfDayErrorMessage = string.Empty;
            }
            else
            {
                TimeOfDayErrorMessage = "Invalid value was entered in the input field";
            }
        }
    }
    public string TimeOfDayErrorMessage { get; set; } = string.Empty;
    public VirtualSafeModel? VirtualSafe { get; set; }
}
