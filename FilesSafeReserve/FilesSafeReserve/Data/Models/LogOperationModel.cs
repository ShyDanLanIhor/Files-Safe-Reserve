using FilesSafeReserve.Data.Interfaces.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilesSafeReserve.Data.Models;

/// <summary>
/// Represents a log operation entity.
/// </summary>
[Table("LogOperation")]
public class LogOperationModel : IModelBase<Guid>
{
    /// <summary>
    /// Gets or sets the identifier for the log operation.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets a value indicating whether the operation succeeded.
    /// </summary>
    public bool IsSucceeded { get; set; }

    /// <summary>
    /// Gets or sets the type of the operation.
    /// </summary>
    public Types Type { get; set; }

    /// <summary>
    /// Gets or sets the path of the item involved in the operation.
    /// </summary>
    public string ItemPath { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the timestamp when the operation was performed.
    /// </summary>
    public DateTime PerformTimestamp { get; set; }

    /// <summary>
    /// Gets or sets the identifier for the associated log.
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
    /// Gets a message describing the operation.
    /// </summary>
    [NotMapped]
    public string Message
    {
        get => Type switch
        {
            Types.CreateVirtualSafe => $@"Creation of virtual safe in '{ItemPath}' {(IsSucceeded ? "succeeded" : "failed")} at {PerformTimestamp:dd/MM/yyyy HH:mm:ss}",
            Types.UpdateVirtualSafe => $@"Updating of virtual safe in '{ItemPath}' {(IsSucceeded ? "succeeded" : "failed")} at {PerformTimestamp:dd/MM/yyyy HH:mm:ss}",
            Types.DeleteVirtualSafe => $@"Deletion of virtual safe in '{ItemPath}' {(IsSucceeded ? "succeeded" : "failed")} at {PerformTimestamp:dd/MM/yyyy HH:mm:ss}",
            Types.TransferToVirtualSafe => $@"Transferring item '{ItemPath}' to '{Log.VirtualSafeDetails.Safe.Path}' {(IsSucceeded ? "succeeded" : "failed")} at {PerformTimestamp:dd/MM/yyyy HH:mm:ss}",
            Types.RemoveFromReservation => $@"Removing item '{ItemPath}' from virtual safe '{Log.VirtualSafeDetails.Safe.Path}' reservation list {(IsSucceeded ? "succeeded" : "failed")} at {PerformTimestamp:dd/MM/yyyy HH:mm:ss}",
            Types.DeleteFromVirtualSafe => $@"Deleting item '{ItemPath}' from virtual safe '{Log.VirtualSafeDetails.Safe.Path}' directory {(IsSucceeded ? "succeeded" : "failed")} at {PerformTimestamp:dd/MM/yyyy HH:mm:ss}",
            _ => $"Unknown operation {(IsSucceeded ? "was performed" : "tried to be performed")} at {PerformTimestamp:dd/MM/yyyy HH:mm:ss}"
        };
    }

    /// <summary>
    /// Enumeration representing types of log operations.
    /// </summary>
    public enum Types
    {
        CreateVirtualSafe,
        UpdateVirtualSafe,
        DeleteVirtualSafe,
        TransferToVirtualSafe,
        AddToReservation,
        RemoveFromReservation,
        DeleteFromVirtualSafe
    }
}