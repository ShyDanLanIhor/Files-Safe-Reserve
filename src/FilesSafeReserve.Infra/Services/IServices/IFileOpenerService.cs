using FilesSafeReserve.App.Entities.Results.Basic;
using FilesSafeReserve.Domain.Entities;
using FilesSafeReserve.Domain.Interfaces;

namespace FilesSafeReserve.Infra.Services.IServices;

/// <summary>
/// The `IFileOpenerService` interface defines a contract for a service that opens files.
/// </summary>
public interface IFileOpenerService
{
    /// <summary>
    /// Opens a file or directory located at the specified path.
    /// </summary>
    /// <param name="fileSystemItemPath">The path of the file system item to open.</param>
    /// <returns>A `ResultEntity` representing the result of the operation.</returns>
    ResultEntity Open(string fileSystemItemPath);

    /// <summary>
    /// Opens a file or directory represented by the specified `IShyPathed` instance.
    /// </summary>
    /// <param name="pathed">The `IShyPathed` instance representing the file system item to open.</param>
    /// <returns>A `ResultEntity` representing the result of the operation.</returns>
    ResultEntity Open(IShyPathed pathed);

    /// <summary>
    /// Opens the specified `ShyFileEntity` instance.
    /// </summary>
    /// <param name="file">The `ShyFileEntity` instance to open.</param>
    /// <returns>A `ResultEntity` representing the result of the operation.</returns>
    ResultEntity Open(ShyFileEntity file);

    /// <summary>
    /// Opens the specified `ShyDirectoryEntity` instance.
    /// </summary>
    /// <param name="directory">The `ShyDirectoryEntity` instance to open.</param>
    /// <returns>A `ResultEntity` representing the result of the operation.</returns>
    ResultEntity Open(ShyDirectoryEntity directory);
}

