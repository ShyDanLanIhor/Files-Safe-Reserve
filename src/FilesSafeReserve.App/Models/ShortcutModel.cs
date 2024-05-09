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
}
