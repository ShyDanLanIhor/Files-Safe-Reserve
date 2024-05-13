using FilesSafeReserve.App.Interfaces.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilesSafeReserve.App.Models;

[Table("Shortcut")]
public class ShortcutModel : IModelBase<Guid>
{
    public Guid Id { get; set; }

    public Types Type { get; set; }

    public int KeyCode { get; set; }
    public string KeyValue { get; set; } = string.Empty;

    public bool ShiftPressed { get; set; }
    public bool ControlPressed { get; set; }
    public bool MetaPressed { get; set; }
    public bool AltPressed { get; set; }

    public enum Types
    {
        None,
        ReserveVirtualSafe,
        ReserveVirtualSafes,
        OpenVirtualSafe,
    }

    [NotMapped]
    public string Name
    {
        get => Type switch
        {
            Types.None => "None",
            Types.ReserveVirtualSafes => "Reserve Virtual Safes",
            Types.ReserveVirtualSafe => "Reserve Virtual Safe",
            Types.OpenVirtualSafe => "Open Virtual Safe",
            _ => "Unknown",
        };
    }

    [NotMapped]
    public string Description
    {
        get => Type switch
        {
            Types.None => "This shortcut don't have description",
            Types.ReserveVirtualSafes => "This shortcut is used to reserve virtual safes in page \"Safes List Page\"",
            Types.ReserveVirtualSafe => "This shortcut is used to reserve virtual safe in pages \"Safe Details Page\" and \"Reservation Page\"",
            Types.OpenVirtualSafe => "This shortcut is used to open virtual safe in file explorer in pages \"Safe Details Page\" and \"Reservation Page\"",
            _ => "This shortcut is unknown",
        };
    }
}
