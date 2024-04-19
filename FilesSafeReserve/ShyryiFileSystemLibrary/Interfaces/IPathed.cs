using ShyryiFileSystemLibrary.Models;
using static ShyryiFileSystemLibrary.Models.FileSystemItemModel;

namespace ShyryiFileSystemLibrary.Interfaces;

/// <summary>
/// Represents an interface for objects that have a name, path, and previous directory information.
/// </summary>
public interface IPathed
{
    public FileSystemItemType Type
    {
        get
        {
            if (Directory.Exists(Path))
                return FileSystemItemType.Directory;
            else if (File.Exists(Path))
                return FileSystemItemType.File;
            else
                return FileSystemItemType.Unknown;
        }
    }

    /// <summary>
    /// Gets or sets the name of the pathable object.
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Gets or sets the path of the pathable object.
    /// </summary>
    public string Path { get; set; }

    /// <summary>
    /// Gets the previous directory of the pathable object.
    /// </summary>
    /// <remarks>This property is read-only.</remarks>
    public DirectoryModel PrevDirectory { get; }

    bool Equals(object obj);
}

