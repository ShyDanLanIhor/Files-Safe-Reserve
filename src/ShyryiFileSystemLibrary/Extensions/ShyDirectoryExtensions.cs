using Microsoft.VisualBasic.FileIO;
using ShyryiFileSystemLibrary.Entities;
using ShyryiFileSystemLibrary.Interfaces;
using ShyryiFileSystemLibrary.Mappers;

namespace ShyryiFileSystemLibrary.Extensions;

public static class ShyDirectoryExtensions
{
    public static void Create(this ShyDirectoryEntity dir)
    => dir.Info.Create();

    public static void Delete(this ShyDirectoryEntity dir)
        => FileSystem.DeleteDirectory(dir.Path, DeleteDirectoryOption.DeleteAllContents);

    public static void CopyTo(this ShyDirectoryEntity sourceDir, ShyDirectoryEntity destDir)
        => FileSystem.CopyDirectory(sourceDir.Path, destDir.Path);

    public static void CopyTo(this ShyDirectoryEntity sourceDir, string destDirPath)
        => FileSystem.CopyDirectory(sourceDir.Path, destDirPath);

    public static void CopyToAsSub(this ShyDirectoryEntity sourceDir, ShyDirectoryEntity destDir)
        => FileSystem.CopyDirectory(sourceDir.Path, Path.Combine(destDir.Path, sourceDir.Name));

    public static void CopyToAsSub(this ShyDirectoryEntity sourceDir, string destDirPath)
        => FileSystem.CopyDirectory(sourceDir.Path, Path.Combine(destDirPath, sourceDir.Name));

    public static void MoveTo(this ShyDirectoryEntity sourceDir, ShyDirectoryEntity destDir)
        => sourceDir.Info.MoveTo(destDir.Path);

    public static void MoveTo(this ShyDirectoryEntity sourceDir, string destDirPath)
        => sourceDir.Info.MoveTo(destDirPath);

    public static void MoveToAsSub(this ShyDirectoryEntity sourceDir, ShyDirectoryEntity destDir)
        => sourceDir.Info.MoveTo(Path.Combine(destDir.Path, sourceDir.Name));

    public static void MoveToAsSub(this ShyDirectoryEntity sourceDir, string destDirPath)
        => sourceDir.Info.MoveTo(Path.Combine(destDirPath, sourceDir.Name));
}
