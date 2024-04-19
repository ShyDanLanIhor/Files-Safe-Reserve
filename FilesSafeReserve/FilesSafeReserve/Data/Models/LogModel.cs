using System.ComponentModel.DataAnnotations.Schema;

namespace FilesSafeReserve.Data.Models;

/// <summary>
/// Represents a log model.
/// </summary>
public class LogModel : ModelBase<Guid>
{
    /// <summary>
    /// Gets or sets the start timestamp of the log.
    /// </summary>
    public DateTime StartTimestamp { get; set; }

    /// <summary>
    /// Gets or sets the end timestamp of the log.
    /// </summary>
    public DateTime EndTimestamp { get; set; }

    /// <summary>
    /// Gets or sets the associated virtual safe.
    /// </summary>
    public VirtualSafeModel VirtualSafe { get; set; } = null!;

    /// <summary>
    /// Gets or sets the list of log operations associated with this log.
    /// </summary>
    public ICollection<LogOperationModel> LogOperations { get; set; } = [];

    /// <summary>
    /// Gets the message representing the log.
    /// </summary>
    [NotMapped]
    public string Message
    {
        get
        {
            string message = string.Empty;
            message += $@"
[
    Virtual safe path: {VirtualSafe.Name}
    Log start time: {StartTimestamp:dd/MM/yyyy HH:mm:ss}
    Log end time: {EndTimestamp:dd/MM/yyyy HH:mm:ss}
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

