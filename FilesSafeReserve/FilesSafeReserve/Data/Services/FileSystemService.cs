using FilesSafeReserve.Data.Entities.Results.Basic;
using FilesSafeReserve.Data.Services.IServices;
using ShyryiFileSystemLibrary.Interfaces;
using ShyryiFileSystemLibrary.Models;
using System.Diagnostics;

namespace FilesSafeReserve.Data.Services;

public class FileSystemService : IFileSystemService
{
    public ResultEntity Open(string fileSystemItemPath)
    {
        Process.Start(new ProcessStartInfo() { FileName = fileSystemItemPath, UseShellExecute = true });
        return true;
    }

    public ResultEntity Open(IPathed pathed)
    {
        Process.Start(new ProcessStartInfo() { FileName = pathed.Path, UseShellExecute = true });
        return true;
    }

    public ResultEntity Open(FileModel file)
    {
        Process.Start(new ProcessStartInfo() { FileName = file.Path, UseShellExecute = true });
        return true;
    }

    public ResultEntity Open(DirectoryModel directory)
    {
        Process.Start(new ProcessStartInfo() { FileName = directory.Path, UseShellExecute = true });
        return true;
    }
}
