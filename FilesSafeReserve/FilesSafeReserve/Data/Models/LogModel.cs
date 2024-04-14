using System.ComponentModel.DataAnnotations.Schema;

namespace FilesSafeReserve.Data.Models;

public class LogModel : ModelBase<Guid>
{ 
    public DateTime StartTimestamp { get; set; }

    public DateTime EndTimestamp { get; set; }

    public VirtualSafeModel AssociatedVirtualSafe { get; set; } = new();

    public List<LogOperationModel> LogOperations { get; set; } = new();

    [NotMapped]
    public string Message
    {
        get
        {
            string message = string.Empty;
            message += 
$@"
[
    Virtual safe path: {AssociatedVirtualSafe.Name}
    Log start time: {StartTimestamp.ToString("dd/MM/yyyy HH:mm:ss")}
    Log end time: {EndTimestamp.ToString("dd/MM/yyyy HH:mm:ss")}
    Action performed:
";
            foreach (var op in LogOperations)
            {
                message += $"   {op.Message}\n";
            }
            message += "]";
            return message;
        }
    }
}
