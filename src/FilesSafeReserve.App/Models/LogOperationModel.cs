﻿using FilesSafeReserve.App.Interfaces.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilesSafeReserve.App.Models;

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
            Types.ReserveSmartphone => $@"Smartphone reservation to virtual safe '{ItemPath}' {(IsSucceeded ? "succeeded" : "failed")} at {PerformTimestamp:dd/MM/yyyy HH:mm:ss}",
            Types.CopyVirtualSafe => $@"Copying of virtual safe '{ItemPath}' in current '{Log.VirtualSafeDetails.Safe.Path}' {(IsSucceeded ? "succeeded" : "failed")} at {PerformTimestamp:dd/MM/yyyy HH:mm:ss}",
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
        ReserveSmartphone,
        CopyVirtualSafe
    }
}