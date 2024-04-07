using ShyryiFileSystemLibrary.Exceptions;
using ShyryiFileSystemLibrary.Interfaces;
using System.Text.RegularExpressions;
using SysPath = System.IO.Path;

namespace ShyryiFileSystemLibrary.Models;

/// <summary>
/// Represents a model for a file in the file system.
/// </summary>
public class FileModel : FileSystemItemModel, IPathable
{
    private string _path = string.Empty;

    /// <summary>
    /// Gets or sets the path of the file.
    /// </summary>
    /// <exception cref="InvalidPathFormatException">Thrown when the provided file path does not match the expected format.</exception>
    public override string Path
    {
        get => _path;
        set
        {
            if (Regex.Match(value, $@"^([a-zA-Z]:\\)([{ProhibitedSymbols}]+\\)*[{ProhibitedSymbols}]*[.][{ProhibitedSymbols}.]*$").Success is false
                && Regex.Match(value, $@"/([{ProhibitedSymbols}]+/)*[{ProhibitedSymbols}.]*[.][{ProhibitedSymbols}.]*$").Success is false)
                throw new InvalidPathFormatException("File path does not match format");

            _path = value;
        }
    }

    /// <summary>
    /// Gets or sets the name of the file.
    /// </summary>
    /// <exception cref="FileSystemItemRenamingException">Thrown when the provided file name contains forbidden characters.</exception>
    public override string Name
    {
        get
        {
            return SysPath.GetFileNameWithoutExtension(Path);
        }
        set
        {
            if (Regex.Match(value, $@"^[{ProhibitedSymbols}.]+$").Success is not true)
                throw new FileSystemItemRenamingException("File name has forbidden characters");

            Path = $@"{Path[..(Path.LastIndexOf(Path.Contains(@"\") ? @"\" : @"/") + 1)]}{value}{Extension}";
        }
    }

    /// <summary>
    /// Gets or sets the name of the file with its extension.
    /// </summary>
    public string NameWithExtension
    {
        get
        {
            return SysPath.GetFileName(Path);
        }
        set
        {
            if (Regex.Match(value, $@"^[{ProhibitedSymbols}.]*\.[{ProhibitedSymbols}.]*$").Success is not true)
                throw new FileSystemItemRenamingException("File name with extension do not match pattern");

            Path = $@"{Path[..(Path.LastIndexOf(Path.Contains(@"\") ? @"\" : @"/") + 1)]}{value}";
        }
    }

    /// <summary>
    /// Gets or sets the extension of the file.
    /// </summary>
    public string Extension
    {
        get
        {
            return SysPath.GetExtension(Path);
        }
        set
        {
            if (Regex.Match(value, @"^[^\\/:*?"".<>|\r\n]+$").Success is not true)
                throw new FileSystemItemRenamingException("File name has forbidden characters");

            Path = $@"{Path[..(Path.LastIndexOf('.') + 1)]}{value}";
        }
    }

    /// <summary>
    /// Gets the previous directory of the file.
    /// </summary>
    public override DirectoryModel PrevDirectory
    {
        get => Path[..Path.LastIndexOf(Path.Contains(@"\") ? @"\" : @"/")];
    }

    /// <summary>
    /// Gets a value indicating whether the file exists.
    /// </summary>
    public bool Exist
    {
        get => File.Exists(Path);
    }

    /// <summary>
    /// Implicitly converts a string to a <see cref="FileModel"/> representing the file at the specified path.
    /// </summary>
    /// <param name="path">The path of the file.</param>
    /// <returns>A <see cref="FileModel"/> representing the file at the specified path.</returns>
    public static implicit operator FileModel(string path)
        => new FileModel() { Path = path };
}

