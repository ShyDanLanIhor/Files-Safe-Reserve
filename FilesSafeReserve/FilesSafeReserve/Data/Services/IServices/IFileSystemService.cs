using FilesSafeReserve.Data.Entities.Results.Basic;
using ShyryiFileSystemLibrary.Interfaces;
using ShyryiFileSystemLibrary.Models;

namespace FilesSafeReserve.Data.Services.IServices;

public interface IFileSystemService
{
    public ResultEntity Open(string fileSystemItemPath);
    public ResultEntity Open(IPathed pathed);
    public ResultEntity Open(FileModel file);
    public ResultEntity Open(DirectoryModel directory);

}
