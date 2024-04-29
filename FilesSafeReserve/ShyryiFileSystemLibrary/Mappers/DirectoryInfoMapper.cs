using ShyryiFileSystemLibrary.Entities;
using ShyryiFileSystemLibrary.Interfaces;

namespace ShyryiFileSystemLibrary.Mappers;

public static class DirectoryInfoMapper
{
    public static ShyDirectoryEntity ToShyDirectory(this DirectoryInfo directory) => directory.FullName;

    public static IShyPathed ToShyPathed(this DirectoryInfo directory) => new ShyFileEntity { Path = directory.FullName };
}
