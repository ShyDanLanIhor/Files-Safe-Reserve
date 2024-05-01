using FilesSafeReserve.Domain.Interfaces;
using FilesSafeReserve.Domain.Entities;

namespace FilesSafeReserve.Domain.Mappers;

public static class DirectoryInfoMapper
{
    public static ShyDirectoryEntity ToShyDirectory(this DirectoryInfo directory) => directory.FullName;

    public static IShyPathed ToShyPathed(this DirectoryInfo directory) => new ShyFileEntity { Path = directory.FullName };
}
