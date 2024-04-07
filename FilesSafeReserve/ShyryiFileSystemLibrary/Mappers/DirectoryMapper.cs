using ShyryiFileSystemLibrary.Interfaces;
using ShyryiFileSystemLibrary.Models;

namespace ShyryiFileSystemLibrary.Mappers;

/// <summary>
/// Provides methods for mapping directory-related models.
/// </summary>
public static class DirectoryMapper
{
    /// <summary>
    /// Converts a <see cref="DirectoryModel"/> object to an <see cref="IPathable"/> object.
    /// </summary>
    /// <param name="model">The directory model to be converted.</param>
    /// <returns>An <see cref="IPathable"/> object representing the directory model.</returns>
    public static IPathable ToIPathable(this DirectoryModel model)
        => new DirectoryModel() { Path = model.Path };
}

