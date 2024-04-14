using ShyryiFileSystemLibrary.Interfaces;
using ShyryiFileSystemLibrary.Models;

namespace ShyryiFileSystemLibrary.Entities.Params.IFileSystemService;

/// <summary>
/// Represents the parameters for transferring items in a file system.
/// </summary>
public class TransferParams
{
    /// <summary>
    /// Gets or sets the destination directory where items will be transferred.
    /// </summary>
    /// <remarks>This parameter is required.</remarks>
    public DirectoryModel? DestinationDirectory { get; set; }

    /// <summary>
    /// Gets or sets the collection of items to be transferred.
    /// </summary>
    /// <remarks>Defaults to an empty collection if not set.</remarks>
    public IEnumerable<IPathed> TransferItems { get; set; } = [];
}
