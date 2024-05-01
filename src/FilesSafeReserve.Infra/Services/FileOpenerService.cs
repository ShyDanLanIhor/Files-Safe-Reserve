using FilesSafeReserve.App.Entities.Results.Basic;
using FilesSafeReserve.Domain.Entities;
using FilesSafeReserve.Domain.Interfaces;
using FilesSafeReserve.Infra.Services.IServices;
using System.Diagnostics;

namespace FilesSafeReserve.Infra.Services;

/// <summary>
/// The `FileOpenerService` class provides an implementation for the `IFileOpenerService` interface.
/// It defines methods to open files or directories using different types of inputs.
/// </summary>
public class FileOpenerService : IFileOpenerService
{
    /// <summary>
    /// Opens a file or directory located at the specified path.
    /// </summary>
    /// <param name="fileSystemItemPath">The path of the file system item to open.</param>
    /// <returns>A `ResultEntity` representing the result of the operation.</returns>
    public ResultEntity Open(string fileSystemItemPath)
    {
        Process.Start(new ProcessStartInfo() { FileName = fileSystemItemPath, UseShellExecute = true });
        return true;
    }

    /// <summary>
    /// Opens a file or directory represented by the specified `IShyPathed` instance.
    /// </summary>
    /// <param name="pathed">The `IShyPathed` instance representing the file system item to open.</param>
    /// <returns>A `ResultEntity` representing the result of the operation.</returns>
    public ResultEntity Open(IShyPathed pathed)
    {
        Process.Start(new ProcessStartInfo() { FileName = pathed.Path, UseShellExecute = true });
        return true;
    }

    /// <summary>
    /// Opens the specified `ShyFileEntity` instance.
    /// </summary>
    /// <param name="file">The `ShyFileEntity` instance to open.</param>
    /// <returns>A `ResultEntity` representing the result of the operation.</returns>
    public ResultEntity Open(ShyFileEntity file)
    {
        Process.Start(new ProcessStartInfo() { FileName = file.Path, UseShellExecute = true });
        return true;
    }

    /// <summary>
    /// Opens the specified `ShyDirectoryEntity` instance.
    /// </summary>
    /// <param name="directory">The `ShyDirectoryEntity` instance to open.</param>
    /// <returns>A `ResultEntity` representing the result of the operation.</returns>
    public ResultEntity Open(ShyDirectoryEntity directory)
    {
        Process.Start(new ProcessStartInfo() { FileName = directory.Path, UseShellExecute = true });
        return true;
    }
}

