using FilesSafeReserve.Data.Models;
using ShyryiFileSystemLibrary.Entities.Results.IFileSystemService;

namespace FilesSafeReserve.Data.Entities.Params.ILoggerService;

/// <summary>
/// Represents the parameters for logging transfer actions.
/// </summary>
public class LogTransferActionParams
{
    /// <summary>
    /// Gets or sets the virtual safe model associated with the transfer action.
    /// </summary>
    public required VirtualSafeModel VirtualSafe { get; set; }

    /// <summary>
    /// Gets or sets the transfer result obtained after performing the transfer action.
    /// </summary>
    public required TransferResult TransferResult { get; set; }
}

