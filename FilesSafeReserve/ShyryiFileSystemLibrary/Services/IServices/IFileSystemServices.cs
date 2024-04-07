using ShyryiFileSystemLibrary.Entities.Params.IFileSystemService;
using ShyryiFileSystemLibrary.Entities.Results.IFileSystemService;
using ShyryiFileSystemLibrary.Interfaces;

namespace ShyryiFileSystemLibrary.Services.IServices;

/// <summary>
/// Defines the contract for file system services.
/// </summary>
public interface IFileSystemServices
{
    /// <summary>
    /// Transfers items according to the specified parameters.
    /// </summary>
    /// <param name="parameters">The parameters specifying the transfer operation.</param>
    /// <returns>A <see cref="TransferResult"/> representing the result of the transfer operation.</returns>
    TransferResult TransferItems(TransferParams parameters);

    /// <summary>
    /// Deletes items specified by the collection of paths.
    /// </summary>
    /// <param name="toDeleteParam">The collection of paths specifying the items to be deleted.</param>
    /// <returns>A <see cref="DeleteResult"/> representing the result of the deletion operation.</returns>
    DeleteResult DeleteItems(IEnumerable<IPathable> toDeleteParam);
}

