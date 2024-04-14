using ShyryiFileSystemLibrary.Exceptions;
using ShyryiFileSystemLibrary.Interfaces;
using System.Text.RegularExpressions;

namespace ShyryiFileSystemLibrary.Models;

/// <summary>
/// Represents a directory in the file system.
/// </summary>
public partial class DirectoryModel : FileSystemItemModel, IPathed
{
    private string _path = string.Empty;

    /// <summary>
    /// Gets or sets the path of the directory.
    /// </summary>
    /// <exception cref="InvalidPathFormatException">Thrown when the provided folder path does not match the expected format.</exception>
    public override string Path
    {
        get => _path;
        set
        {
            if (WinUiPathRegex().Match(value).Success is false
                && OtherPathRegex().Match(value).Success is false)
                throw new InvalidPathFormatException("Folder path does not match format");

            _path = value;
        }
    }

    /// <summary>
    /// Gets or sets the name of the directory.
    /// </summary>
    /// <exception cref="FileSystemItemRenamingException">Thrown when the folder name contains forbidden characters.</exception>
    public override string Name
    {
        get
        {
            return Path[Path.LastIndexOf(Path.Contains('\\') ? '\\' : '/')..][1..];
        }
        set
        {
            if (Regex.Match(value, $@"^[{ProhibitedSymbols}]+$").Success is not true)
                throw new FileSystemItemRenamingException("Folder name has forbidden characters");

            Path = $@"{Path[..(Path.LastIndexOf(Path.Contains('\\') ? '\\' : '/') + 1)]}{value}";
        }
    }

    /// <summary>
    /// Gets the list of files in the directory.
    /// </summary>
    public List<FileModel>? Files
    {
        get
        {
            if (Exist is false)
                return null;

            string[] filesPaths = Directory.GetFiles(Path);
            List<FileModel> files = [.. filesPaths];

            return files;
        }
    }

    /// <summary>
    /// Gets the list of subdirectories in the directory.
    /// </summary>
    public List<DirectoryModel>? Directories
    {
        get
        {
            if (Exist is false)
                return null;

            string[] directoriesPathes = Directory.GetDirectories(Path);
            List<DirectoryModel> directories = [.. directoriesPathes];

            return directories;
        }
    }

    /// <summary>
    /// Gets the list of files and directories in the directory.
    /// </summary>
    public List<IPathed>? Patheds
    {
        get
        {
            if (Exist is false)
                return null;

            string[] filesPaths = Directory.GetFiles(Path);
            string[] directoriesPaths = Directory.GetDirectories(Path);
            List<IPathed> items = [];

            foreach (var file in filesPaths)
                items.Add(new FileModel { Path = file });

            foreach (var directory in directoriesPaths)
                items.Add(new DirectoryModel() { Path = directory });

            return items;
        }
    }

    /// <summary>
    /// Gets the parent directory of the current directory.
    /// </summary>
    public override DirectoryModel PrevDirectory
    {
        get => Path[..Path.LastIndexOf(Path.Contains('\\') ? '\\' : '/')];
    }

    /// <summary>
    /// Checks whether the directory exists.
    /// </summary>
    public bool Exist
    {
        get => Directory.Exists(Path);
    }

    /// <summary>
    /// Implicitly converts a string to a DirectoryModel.
    /// </summary>
    /// <param name="path">The path to the directory.</param>
    public static implicit operator DirectoryModel(string path)
        => new() { Path = path };

    /// <summary>
    /// Regular expression for validating Windows UI paths.
    /// </summary>
    [GeneratedRegexAttribute($@"^([a-zA-Z]:\\)([{ProhibitedSymbols}]+\\)*[{ProhibitedSymbols}]*$")]
    public static partial Regex WinUiPathRegex();

    /// <summary>
    /// Regular expression for validating other paths.
    /// </summary>
    [GeneratedRegexAttribute($@"^/([{ProhibitedSymbols}]+/)*[{ProhibitedSymbols}]*$")]
    public static partial Regex OtherPathRegex();
}


