using FilesSafeReserve.Domain.Interfaces;
using FilesSafeReserve.Domain.Entities;

namespace FilesSafeReserve.Domain.Mappers;

public static class ShyPathedMapper
{
    public static ShyDirectoryEntity ToShyDirectory(this IShyPathed pathed) => pathed.Path;
    public static ShyFileEntity ToShyFile(this IShyPathed pathed) => pathed.Path;
}
