using System.ComponentModel.DataAnnotations.Schema;

namespace FilesSafeReserve.Data.Models;

/// <summary>
/// Represents a log operation model.
/// </summary>
public class LogOperationModel : ModelBase<Guid>
{
    /// <summary>
    /// Gets or sets a value indicating whether the operation succeeded.
    /// </summary>
    public bool IsSucceeded { get; set; }

    /// <summary>
    /// Gets or sets the type of the operation.
    /// </summary>
    public OperationsTypes Type { get; set; }

    /// <summary>
    /// Gets or sets the file path of the virtual safe involved in the operation.
    /// </summary>
    public string VirtualSafeFilePath { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the file path of the external file involved in the operation.
    /// </summary>
    public string ExternalFilePath { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the timestamp when the operation was performed.
    /// </summary>
    public DateTime PerformTimestamp { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the associated log.
    /// </summary>
    public Guid LogId { get; set; }

    /// <summary>
    /// Gets or sets the associated log.
    /// </summary>
    public LogModel Log { get; set; } = null!;

    /// <summary>
    /// Gets a value indicating whether the operation failed.
    /// </summary>
    [NotMapped]
    public bool IsFailed
    {
        get => IsSucceeded is false;
        set => IsSucceeded = !value;
    }

    /// <summary>
    /// Gets the message representing the log operation.
    /// </summary>
    [NotMapped]
    public string Message
    {
        get => Type switch
        {
            OperationsTypes.CreateVirtualSafe => $@"Creation of virtual safe in '{Log.VirtualSafe.Path}' {(IsSucceeded ? "succeeded" : "failed")} at {PerformTimestamp:dd/MM/yyyy HH:mm:ss}",
            OperationsTypes.DeleteVirtualSafe => $@"Deletion of virtual safe in '{Log.VirtualSafe.Path}' {(IsSucceeded ? "succeeded" : "failed")} at {PerformTimestamp:dd/MM/yyyy HH:mm:ss}",
            OperationsTypes.TransferFile => $@"Transfer from '{ExternalFilePath}' to '{VirtualSafeFilePath}' {(IsSucceeded ? "succeeded" : "failed")} at {PerformTimestamp:dd/MM/yyyy HH:mm:ss}",
            OperationsTypes.DeleteFile => $@"Deletion of '{VirtualSafeFilePath}' {(IsSucceeded ? "succeeded" : "failed")} at {PerformTimestamp:dd/MM/yyyy HH:mm:ss}",
            _ => $"Unknown operation {(IsSucceeded ? "was performed" : "tried to be performed")} at {PerformTimestamp:dd/MM/yyyy HH:mm:ss}"
        };
    }

    /// <summary>
    /// Enumeration representing the types of operations.
    /// </summary>
    public enum OperationsTypes
    {
        CreateVirtualSafe,
        DeleteVirtualSafe,
        TransferFile,
        DeleteFile
    }
}

