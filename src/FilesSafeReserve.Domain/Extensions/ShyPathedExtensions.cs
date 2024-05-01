using FilesSafeReserve.Domain.Entities;
using FilesSafeReserve.Domain.Interfaces;
using FilesSafeReserve.Domain.Mappers;
using Microsoft.VisualBasic.FileIO;

namespace FilesSafeReserve.Domain.Extensions;

public static class ShyPathedExtensions
{
    public static void Create(this IShyPathed shyPathed)
    {
        if (shyPathed.Type is ShyFsType.File)
            shyPathed.ToShyFile().Info.Create();
        else if (shyPathed.Type is ShyFsType.Directory)
            shyPathed.ToShyDirectory().Info.Create();
    }

    public static void Delete(this IShyPathed shyPathed)
    {
        if (shyPathed.Type is ShyFsType.File)
            shyPathed.ToShyFile().Info.Delete();
        else if (shyPathed.Type is ShyFsType.Directory)
            FileSystem.DeleteDirectory(shyPathed.Path, DeleteDirectoryOption.DeleteAllContents);
    }

    public static void CopyTo(this IShyPathed sourceShyPathed, IShyPathed destShyPathed)
    {
        if (sourceShyPathed.Type is ShyFsType.File && destShyPathed.Type is ShyFsType.File or ShyFsType.NonExistent)
            sourceShyPathed.ToShyFile().Info.CopyTo(destShyPathed.Path);
        else if (sourceShyPathed.Type is ShyFsType.Directory && destShyPathed.Type is ShyFsType.Directory or ShyFsType.NonExistent)
            FileSystem.CopyDirectory(sourceShyPathed.Path, destShyPathed.Path);
    }

    public static void CopyTo(this IShyPathed sourceShyPathed, string destShyPathedPath)
    {
        if (sourceShyPathed.Type is ShyFsType.File && Directory.Exists(destShyPathedPath) is false)
            sourceShyPathed.ToShyFile().Info.CopyTo(destShyPathedPath);
        else if (sourceShyPathed.Type is ShyFsType.Directory && File.Exists(destShyPathedPath) is false)
            FileSystem.CopyDirectory(sourceShyPathed.Path, destShyPathedPath);
    }

    public static void CopyToAsSub(this IShyPathed sourceShyPathed, ShyDirectoryEntity destDir)
    {
        if (sourceShyPathed.Type is ShyFsType.File)
            sourceShyPathed.ToShyFile().Info.CopyTo(Path.Combine(destDir.Path, sourceShyPathed.Name));
        else if (sourceShyPathed.Type is ShyFsType.Directory)
            FileSystem.CopyDirectory(sourceShyPathed.Path, Path.Combine(destDir.Path, sourceShyPathed.Name));
    }

    public static void CopyToAsSub(this IShyPathed sourceShyPathed, string destDirPath)
    {
        if (sourceShyPathed.Type is ShyFsType.File)
            sourceShyPathed.ToShyFile().Info.CopyTo(Path.Combine(destDirPath, sourceShyPathed.Name));
        else if (sourceShyPathed.Type is ShyFsType.Directory)
            FileSystem.CopyDirectory(sourceShyPathed.Path, Path.Combine(destDirPath, sourceShyPathed.Name));
    }

    public static void MoveTo(this IShyPathed sourceShyPathed, IShyPathed destShyPathed)
    {
        if (sourceShyPathed.Type is ShyFsType.File && destShyPathed.Type is ShyFsType.File or ShyFsType.NonExistent)
            sourceShyPathed.ToShyFile().Info.MoveTo(destShyPathed.Path);
        else if (sourceShyPathed.Type is ShyFsType.Directory && destShyPathed.Type is ShyFsType.Directory or ShyFsType.NonExistent)
            sourceShyPathed.ToShyDirectory().Info.MoveTo(destShyPathed.Path);
        sourceShyPathed.Delete();
    }

    public static void MoveTo(this IShyPathed sourceShyPathed, string destShyPathedPath)
    {
        if (sourceShyPathed.Type is ShyFsType.File && Directory.Exists(destShyPathedPath) is false)
            sourceShyPathed.ToShyFile().Info.MoveTo(destShyPathedPath);
        else if (sourceShyPathed.Type is ShyFsType.Directory && File.Exists(destShyPathedPath) is false)
            sourceShyPathed.ToShyDirectory().Info.MoveTo(destShyPathedPath);
        sourceShyPathed.Delete();
    }

    public static void MoveToAsSub(this IShyPathed sourceShyPathed, ShyDirectoryEntity destDir)
    {
        if (sourceShyPathed.Type is ShyFsType.File)
            sourceShyPathed.ToShyFile().Info.MoveTo(Path.Combine(destDir.Path, sourceShyPathed.Name));
        else if (sourceShyPathed.Type is ShyFsType.Directory)
            sourceShyPathed.ToShyDirectory().Info.MoveTo(Path.Combine(destDir.Path, sourceShyPathed.Name));
        sourceShyPathed.Delete();
    }

    public static void MoveToAsSub(this IShyPathed sourceShyPathed, string destDirPath)
    {
        if (sourceShyPathed.Type is ShyFsType.File)
            sourceShyPathed.ToShyFile().Info.MoveTo(Path.Combine(destDirPath, sourceShyPathed.Name));
        else if (sourceShyPathed.Type is ShyFsType.Directory)
            sourceShyPathed.ToShyDirectory().Info.MoveTo(Path.Combine(destDirPath, sourceShyPathed.Name));
        sourceShyPathed.Delete();
    }
}
