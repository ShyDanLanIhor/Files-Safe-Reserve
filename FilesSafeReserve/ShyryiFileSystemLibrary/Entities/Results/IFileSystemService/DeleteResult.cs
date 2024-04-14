using ShyryiFileSystemLibrary.Interfaces;

namespace ShyryiFileSystemLibrary.Entities.Results.IFileSystemService;

/// <summary>
/// Represents the result of a deletion operation in a file system.
/// </summary>
public class DeleteResult
{
    /// <summary>
    /// Gets a value indicating whether all items were successfully deleted.
    /// </summary>
    /// <remarks>Returns true if all items were deleted successfully; otherwise, false.</remarks>
    public bool IsAllDeleted
    {
        get => FailedItems?.Count() is 0 or null;
    }

    /// <summary>
    /// Gets or sets the error message encountered during the deletion operation.
    /// </summary>
    public string Error { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the date and time when the deletion operation was executed.
    /// </summary>
    public DateTime ExecutionDateTime { get; } = DateTime.Now;

    /// <summary>
    /// Gets or sets the collection of items that were successfully deleted.
    /// </summary>
    public ICollection<IPathed>? DeletedItems { get; set; }

    /// <summary>
    /// Gets or sets the collection of items that failed to be deleted.
    /// </summary>
    public ICollection<IPathed>? FailedItems { get; set; }
}

