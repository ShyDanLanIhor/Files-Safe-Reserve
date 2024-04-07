using ShyryiFileSystemLibrary.Interfaces;

namespace ShyryiFileSystemLibrary.Models;

/// <summary>
/// Represents an abstract base class for file system item models.
/// </summary>
public abstract class FileSystemItemModel : IPathable
{
    /// <summary>
    /// Specifies a string containing characters that are prohibited in file or directory names.
    /// </summary>
    public static string ProhibitedSymbols = @"^\\/:*?""<>|\r\n";

    /// <summary>
    /// Gets or sets the name of the file system item.
    /// </summary>
    public abstract string Name { get; set; }

    /// <summary>
    /// Gets or sets the path of the file system item.
    /// </summary>
    public abstract string Path { get; set; }

    /// <summary>
    /// Gets the previous directory of the file system item.
    /// </summary>
    public abstract DirectoryModel PrevDirectory { get; }

    /// <summary>
    /// Determines whether two file system items are equal.
    /// </summary>
    public static bool operator ==(FileSystemItemModel directory1, FileSystemItemModel directory2)
        => directory1.Equals(directory2);

    /// <summary>
    /// Determines whether two file system items are not equal.
    /// </summary>
    public static bool operator !=(FileSystemItemModel directory1, FileSystemItemModel directory2)
        => !directory1.Equals(directory2);

    /// <summary>
    /// Decrements the current file system item to its previous directory.
    /// </summary>
    public static FileSystemItemModel operator --(FileSystemItemModel directory)
        => directory.PrevDirectory;

    /// <summary>
    /// Determines whether the specified object is equal to the current file system item.
    /// </summary>
    public override bool Equals(object obj) => obj is FileSystemItemModel && Equals(this, obj);

    /// <summary>
    /// Returns the hash code for the current file system item.
    /// </summary>
    public override int GetHashCode() => Path.GetHashCode();
}

