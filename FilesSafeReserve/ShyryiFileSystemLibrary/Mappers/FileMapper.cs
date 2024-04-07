using ShyryiFileSystemLibrary.Interfaces;
using ShyryiFileSystemLibrary.Models;

namespace ShyryiFileSystemLibrary.Mappers;

/// <summary>
/// Provides methods for mapping file-related models.
/// </summary>
public static class FileMapper
{
    /// <summary>
    /// Converts a <see cref="FileModel"/> object to an <see cref="IPathable"/> object.
    /// </summary>
    /// <param name="model">The file model to be converted.</param>
    /// <returns>An <see cref="IPathable"/> object representing the file model.</returns>
    public static IPathable ToIPathable(this FileModel model)
        => new FileModel() { Path = model.Path };
}

