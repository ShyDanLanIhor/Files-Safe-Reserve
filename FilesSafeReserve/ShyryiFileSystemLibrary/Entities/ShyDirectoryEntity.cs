using ShyryiFileSystemLibrary.Exceptions;
using ShyryiFileSystemLibrary.Interfaces;
using ShyryiFileSystemLibrary.Mappers;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;

namespace ShyryiFileSystemLibrary.Entities;

public partial class ShyDirectoryEntity : ShyFsEntity, IShyPathed
{
    private string _path = string.Empty;

    public override string Path
    {
        get => _path;
        set
        {
            if (WinUiPathRegex().Match(value).Success is false
                && OtherPathRegex().Match(value).Success is false)
                throw new InvalidPathFormatException($"Folder path '{value}' does not match format");

            _path = value;
        }
    }

    [NotMapped]
    public override string Name
    {
        get => Path[Path.LastIndexOf(Path.Contains('\\') ? '\\' : '/')..][1..];
        set
        {
            if (NameRegex().Match(value).Success is not true)
                throw new FsRenamingException("Folder name has forbidden characters");

            Path = $@"{Path[..(Path.LastIndexOf(Path.Contains('\\') ? '\\' : '/') + 1)]}{value}";
        }
    }

    [NotMapped]
    public DirectoryInfo Info
    {
        get => new(Path);
    }

    [NotMapped]
    public ICollection<ShyFileEntity> Files
    {
        get => Info.EnumerateFiles().Select(el => el.ToShyFile()).ToList();
    }

    [NotMapped]
    public ICollection<ShyDirectoryEntity> Directories
    {
        get => Info.EnumerateDirectories().Select(el => el.ToShyDirectory()).ToList();
    }

    [NotMapped]
    public ICollection<IShyPathed> Patheds
    {
        get
        {
            var files = Files;
            var directories = Directories;

            ICollection<IShyPathed> items = [];

            foreach (var file in files)
                items.Add(new ShyFileEntity { Path = file.Path });

            foreach (var directory in directories)
                items.Add(new ShyDirectoryEntity() { Path = directory.Path });

            return items;
        }
    }

    public static implicit operator ShyDirectoryEntity(string path) 
        => new() { Path = path };

    [GeneratedRegexAttribute($@"^([a-zA-Z]:\\)([{ProhibitedSymbols}]+\\)*[{ProhibitedSymbols}]*$")]
    public static partial Regex WinUiPathRegex();

    [GeneratedRegexAttribute($@"^/([{ProhibitedSymbols}]+/)*[{ProhibitedSymbols}]*$")]
    public static partial Regex OtherPathRegex();
    [GeneratedRegexAttribute($@"^[{ProhibitedSymbols}]+$")]
    public static partial Regex NameRegex();
}


