using FilesSafeReserve.Domain.Entities;

namespace FilesSafeReserve.Domain.Extensions;

public static class ShyFileExtensions
{
    public static void Create(this ShyFileEntity file)
        => file.Info.Create();

    public static void Delete(this ShyFileEntity file)
        => file.Info.Delete();

    public static void CopyTo(this ShyFileEntity sourceFile, ShyFileEntity destFile)
        => sourceFile.Info.CopyTo(destFile.Path);

    public static void CopyTo(this ShyFileEntity sourceFile, string destFilePath)
        => sourceFile.Info.CopyTo(destFilePath);

    public static void CopyToAsSub(this ShyFileEntity sourceFile, ShyDirectoryEntity destDir)
        => sourceFile.Info.CopyTo(Path.Combine(destDir.Path, sourceFile.Name));

    public static void CopyToAsSub(this ShyFileEntity sourceFile, string destDirPath)
        => sourceFile.Info.CopyTo(Path.Combine(destDirPath, sourceFile.Name));

    public static void MoveTo(this ShyFileEntity sourceFile, ShyFileEntity destFile)
        => sourceFile.Info.MoveTo(destFile.Path);

    public static void MoveTo(this ShyFileEntity sourceFile, string destFilePath)
        => sourceFile.Info.MoveTo(destFilePath);

    public static void MoveToAsSub(this ShyFileEntity sourceFile, ShyDirectoryEntity destDir)
        => sourceFile.Info.MoveTo(Path.Combine(destDir.Path, sourceFile.Name));

    public static void MoveToAsSub(this ShyFileEntity sourceFile, string destDirPath)
        => sourceFile.Info.MoveTo(Path.Combine(destDirPath, sourceFile.Name));
}
