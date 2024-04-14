using System.ComponentModel.DataAnnotations.Schema;

namespace FilesSafeReserve.Data.Models;

public class LogOperationModel : ModelBase<Guid>
{
    public bool IsSucceeded { get; set; }

    public OperationsTypes Type { get; set; }

    public string VirtualSafeFilePath { get; set; } = string.Empty;

    public string ExternalFilePath { get; set; } = string.Empty;

    public DateTime PerformTimestamp { get; set; }

    public LogModel AssociatedLog { get; set; } = new();

    [NotMapped]
    public bool IsFailed
    {
        get => IsSucceeded is false;
        set => IsSucceeded = !value;
    }

    [NotMapped]
    public string Message
    {
        get => Type switch
        {
            OperationsTypes.CreateVirtualSafe => $@"Creation of virtual safe in '{AssociatedLog.AssociatedVirtualSafe.Path}' {(IsSucceeded ? "succeeded" : "failed")} at {PerformTimestamp.ToString("dd/MM/yyyy HH:mm:ss")}",
            OperationsTypes.DeleteVirtualSafe => $@"Deletion of virtual safe in '{AssociatedLog.AssociatedVirtualSafe.Path}' {(IsSucceeded ? "succeeded" : "failed")} at {PerformTimestamp.ToString("dd/MM/yyyy HH:mm:ss")}",
            OperationsTypes.TransferFile => $@"Transfer from '{ExternalFilePath}' to '{VirtualSafeFilePath}' {(IsSucceeded ? "succeeded" : "failed")} at {PerformTimestamp.ToString("dd/MM/yyyy HH:mm:ss")}",
            OperationsTypes.DeleteFile => $@"Deletion of '{VirtualSafeFilePath}' {(IsSucceeded ? "succeeded" : "failed")} at {PerformTimestamp.ToString("dd/MM/yyyy HH:mm:ss")}",
            _ => $"Unknown operation {(IsSucceeded ? "was performed" : "tried to be performed")} at {PerformTimestamp.ToString("dd/MM/yyyy HH:mm:ss")}"
        };
    }

    public enum OperationsTypes
    {
        CreateVirtualSafe,
        DeleteVirtualSafe,
        TransferFile,
        DeleteFile
    }
}
