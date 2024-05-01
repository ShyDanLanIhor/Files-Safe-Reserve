using FilesSafeReserve.Domain.Interfaces;
using FilesSafeReserve.Domain.Entities;

namespace FilesSafeReserve.Domain.Mappers;

public static class ShyDirectoryMapper
{
    public static IShyPathed ToShyPathed(this ShyDirectoryEntity directory) => directory;
}
