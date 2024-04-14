using ShyryiFileSystemLibrary.Interfaces;

namespace ShyryiFileSystemLibrary.Entities.Results.IFileSystemService;

/// <summary>
/// Represents the result of a transfer operation in a file system.
/// </summary>
public class TransferResult
{
    /// <summary>
    /// Gets a value indicating whether all items were successfully transferred.
    /// </summary>
    /// <remarks>Returns true if all items were transferred successfully; otherwise, false.</remarks>
    public bool IsAllTransferred
    {
        get => FailedItems?.Count() is 0 or null;
    }

    /// <summary>
    /// Gets or sets the error message encountered during the transfer operation.
    /// </summary>
    public string Error { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the date and time when the transfer operation was executed.
    /// </summary>
    public DateTime ExecutionDateTime { get; } = DateTime.Now;

    /// <summary>
    /// Gets or sets the collection of items that were successfully transferred.
    /// </summary>
    public ICollection<IPathed>? TransferredItems { get; set; }

    /// <summary>
    /// Gets or sets the collection of items that failed to be transferred.
    /// </summary>
    public ICollection<IPathed>? FailedItems { get; set; }
}
