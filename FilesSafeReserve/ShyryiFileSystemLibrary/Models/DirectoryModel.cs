using ShyryiFileSystemLibrary.Exceptions;
using ShyryiFileSystemLibrary.Interfaces;
using System.Text.RegularExpressions;

namespace ShyryiFileSystemLibrary.Models;

/// <summary>
/// Represents a model for a directory in the file system.
/// </summary>
public class DirectoryModel : FileSystemItemModel, IPathable
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
            if (Regex.Match(value, $@"^([a-zA-Z]:\\)([{ProhibitedSymbols}]+\\)*[{ProhibitedSymbols}]*$").Success is false
                && Regex.Match(value, $@"^/([{ProhibitedSymbols}]+/)*[{ProhibitedSymbols}]*$").Success is false)
                throw new InvalidPathFormatException("Folder path does not match format");

            _path = value;
        }
    }

    /// <summary>
    /// Gets or sets the name of the directory.
    /// </summary>
    /// <exception cref="FileSystemItemRenamingException">Thrown when the provided folder name contains forbidden characters.</exception>
    public override string Name
    {
        get
        {
            return Path[Path.LastIndexOf(Path.Contains(@"\") ? @"\" : @"/")..][1..];
        }
        set
        {
            if (Regex.Match(value, $@"^[{ProhibitedSymbols}]+$").Success is not true)
                throw new FileSystemItemRenamingException("Folder name has forbidden characters");

            Path = $@"{Path[..(Path.LastIndexOf(Path.Contains(@"\") ? @"\" : @"/") + 1)]}{value}";
        }
    }

    /// <summary>
    /// Gets the list of files in the directory.
    /// </summary>
    public List<FileModel> Files
    {
        get
        {
            if (Exist is false)
                return null;

            string[] filesPathes = Directory.GetFiles(Path);
            List<FileModel> files = new();

            foreach (var file in filesPathes)
                files.Add(file);

            return files;
        }
    }

    /// <summary>
    /// Gets the list of subdirectories in the directory.
    /// </summary>
    public List<DirectoryModel> Directories
    {
        get
        {
            if (Exist is false)
                return null;

            string[] directoriesPathes = Directory.GetDirectories(Path);
            List<DirectoryModel> directories = new();

            foreach (var directory in directoriesPathes)
                directories.Add(directory);

            return directories;
        }
    }

    /// <summary>
    /// Gets the list of items (files and subdirectories) in the directory.
    /// </summary>
    public List<IPathable> Pathables
    {
        get
        {
            if (Exist is false)
                return null;

            string[] filesPathes = Directory.GetFiles(Path);
            string[] directoriesPathes = Directory.GetDirectories(Path);
            List<IPathable> items = new();

            foreach (var file in filesPathes)
                items.Add(new FileModel { Path = file });

            foreach (var directory in directoriesPathes)
                items.Add(new DirectoryModel() { Path = directory });

            return items;
        }
    }

    /// <summary>
    /// Gets the previous directory of the directory.
    /// </summary>
    public override DirectoryModel PrevDirectory
    {
        get => Path[..Path.LastIndexOf(Path.Contains(@"\") ? @"\" : @"/")];
    }

    /// <summary>
    /// Gets a value indicating whether the directory exists.
    /// </summary>
    public bool Exist
    {
        get => Directory.Exists(Path);
    }

    /// <summary>
    /// Implicitly converts a string to a <see cref="DirectoryModel"/> representing the directory at the specified path.
    /// </summary>
    /// <param name="path">The path of the directory.</param>
    /// <returns>A <see cref="DirectoryModel"/> representing the directory at the specified path.</returns>
    public static implicit operator DirectoryModel(string path)
        => new DirectoryModel() { Path = path };
}

