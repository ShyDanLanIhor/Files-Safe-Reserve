using ShyryiFileSystemLibrary.Entities;
using ShyryiFileSystemLibrary.Interfaces;

namespace ShyryiFileSystemLibrary.Mappers;

public static class ShyPathedMapper
{
    public static ShyDirectoryEntity ToShyDirectory(this IShyPathed pathed) => pathed.Path;
    public static ShyFileEntity ToShyFile(this IShyPathed pathed) => pathed.Path;
}
