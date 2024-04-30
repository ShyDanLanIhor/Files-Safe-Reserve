using ShyryiFileSystemLibrary.Entities;
using ShyryiFileSystemLibrary.Interfaces;

namespace ShyryiFileSystemLibrary.Mappers;

public static class ShyFileMapper
{
    public static IShyPathed ToShyPathed(this ShyFileEntity file) => file;
}
