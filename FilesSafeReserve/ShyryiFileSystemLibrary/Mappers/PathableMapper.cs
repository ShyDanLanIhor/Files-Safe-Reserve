using ShyryiFileSystemLibrary.Interfaces;
using ShyryiFileSystemLibrary.Models;

namespace ShyryiFileSystemLibrary.Mappers;

/// <summary>
/// Provides methods for mapping objects implementing the <see cref="IPathed"/> interface.
/// </summary>
public static class PathableMapper
{

    /// <summary>
    /// Converts an object implementing <see cref="IPathed"/> to a <see cref="FileModel"/>.
    /// </summary>
    /// <param name="pathable">The object implementing <see cref="IPathed"/> to be converted.</param>
    /// <returns>A <see cref="FileModel"/> object representing the converted pathable object.</returns>
    public static FileModel ToFileModel(this IPathed pathable) => pathable.Path;

    /// <summary>
    /// Converts an object implementing <see cref="IPathed"/> to a <see cref="DirectoryModel"/>.
    /// </summary>
    /// <param name="pathable">The object implementing <see cref="IPathed"/> to be converted.</param>
    /// <returns>A <see cref="DirectoryModel"/> object representing the converted pathable object.</returns>
    public static DirectoryModel ToDirectoryModel(this IPathed pathable) => pathable.Path;
}

