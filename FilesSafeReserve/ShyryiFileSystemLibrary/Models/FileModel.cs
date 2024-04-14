using ShyryiFileSystemLibrary.Exceptions;
using ShyryiFileSystemLibrary.Interfaces;
using System.Text.RegularExpressions;
using SysPath = System.IO.Path;

namespace ShyryiFileSystemLibrary.Models;

/// <summary>
/// Represents a file in the file system.
/// </summary>
public partial class FileModel : FileSystemItemModel, IPathed
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
            if (WinUiPathRegex().Match(value).Success is false
                && OtherPathRegex().Match(value).Success is false)
                throw new InvalidPathFormatException("File path does not match format");

            _path = value;
        }
    }

    /// <summary>
    /// Gets or sets the name of the file without extension.
    /// </summary>
    /// <exception cref="FileSystemItemRenamingException">Thrown when the file name contains forbidden characters.</exception>
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
    /// Gets or sets the name of the file with extension.
    /// </summary>
    /// <exception cref="FileSystemItemRenamingException">Thrown when the file name with extension does not match the expected pattern.</exception>
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
    /// <exception cref="FileSystemItemRenamingException">Thrown when the file extension contains forbidden characters.</exception>
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
    /// Gets the parent directory of the current file.
    /// </summary>
    public override DirectoryModel PrevDirectory
    {
        get => Path[..Path.LastIndexOf(Path.Contains(@"\") ? @"\" : @"/")];
    }

    /// <summary>
    /// Checks whether the file exists.
    /// </summary>
    public bool Exist
    {
        get => File.Exists(Path);
    }

    /// <summary>
    /// Implicitly converts a string to a FileModel.
    /// </summary>
    /// <param name="path">The path to the file.</param>
    public static implicit operator FileModel(string path)
        => new() { Path = path };

    /// <summary>
    /// Regular expression for validating Windows UI file paths.
    /// </summary>
    [GeneratedRegexAttribute($@"^([a-zA-Z]:\\)([{ProhibitedSymbols}]+\\)*[{ProhibitedSymbols}]*[.][{ProhibitedSymbols}.]*$")]
    public static partial Regex WinUiPathRegex();

    /// <summary>
    /// Regular expression for validating other file paths.
    /// </summary>
    [GeneratedRegexAttribute($@"/([{ProhibitedSymbols}]+/)*[{ProhibitedSymbols}.]*[.][{ProhibitedSymbols}.]*$")]
    public static partial Regex OtherPathRegex();
}


