using ShyryiFileSystemLibrary.Entities;
using ShyryiFileSystemLibrary.Interfaces;

namespace ShyryiFileSystemLibrary.Mappers;

public static class ShyDirectoryMapper
{
    public static IShyPathed ToShyPathed(this ShyDirectoryEntity directory) => directory;
}
