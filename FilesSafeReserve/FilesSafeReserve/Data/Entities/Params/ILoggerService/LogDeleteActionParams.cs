using FilesSafeReserve.Data.Models;
using ShyryiFileSystemLibrary.Entities.Results.IFileSystemService;

namespace FilesSafeReserve.Data.Entities.Params.ILoggerService;

/// <summary>
/// Represents the parameters for logging delete actions.
/// </summary>
public class LogDeleteActionParams
{
    /// <summary>
    /// Gets or sets the virtual safe model associated with the delete action.
    /// </summary>
    public required VirtualSafeModel VirtualSafe { get; set; }

    /// <summary>
    /// Gets or sets the delete result obtained after performing the delete action.
    /// </summary>
    public required DeleteResult TransferResult { get; set; }
}

