using FilesSafeReserve.Domain.Interfaces;
using FilesSafeReserve.Domain.Entities;

namespace FilesSafeReserve.Domain.Mappers;

public static class ShyFileMapper
{
    public static IShyPathed ToShyPathed(this ShyFileEntity file) => file;
}
