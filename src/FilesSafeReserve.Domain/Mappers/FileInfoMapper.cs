using FilesSafeReserve.Domain.Interfaces;
using FilesSafeReserve.Domain.Entities;

namespace FilesSafeReserve.Domain.Mappers;

public static class FileInfoMapper
{
    public static ShyFileEntity ToShyFile(this FileInfo file) => file.FullName;

    public static IShyPathed ToShyPathed(this FileInfo file) => new ShyFileEntity { Path = file.FullName };
}
