using ShyryiFileSystemLibrary.Interfaces;
using ShyryiFileSystemLibrary.Models;

namespace ShyryiFileSystemLibrary.Mappers;

/// <summary>
/// Provides methods for mapping objects implementing the <see cref="IPathable"/> interface.
/// </summary>
public static class PathableMapper
{

    /// <summary>
    /// Converts an object implementing <see cref="IPathable"/> to a <see cref="FileModel"/>.
    /// </summary>
    /// <param name="pathable">The object implementing <see cref="IPathable"/> to be converted.</param>
    /// <returns>A <see cref="FileModel"/> object representing the converted pathable object.</returns>
    public static FileModel ToFileModel(this IPathable pathable) => pathable.Path;

    /// <summary>
    /// Converts an object implementing <see cref="IPathable"/> to a <see cref="DirectoryModel"/>.
    /// </summary>
    /// <param name="pathable">The object implementing <see cref="IPathable"/> to be converted.</param>
    /// <returns>A <see cref="DirectoryModel"/> object representing the converted pathable object.</returns>
    public static DirectoryModel ToDirectoryModel(this IPathable pathable) => pathable.Path;
}

