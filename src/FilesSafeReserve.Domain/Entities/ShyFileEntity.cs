using FilesSafeReserve.Domain.Interfaces;
using FilesSafeReserve.Domain.Exceptions;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.RegularExpressions;
using SysPath = System.IO.Path;

namespace FilesSafeReserve.Domain.Entities;

public partial class ShyFileEntity : ShyFsEntity, IShyPathed
{
    private string _path = string.Empty;

    public override string Path
    {
        get => _path;
        set
        {
            if (WinUiPathRegex().Match(value).Success is false
                && OtherPathRegex().Match(value).Success is false)
                throw new InvalidPathFormatException($"File path '{value}' does not match format");

            _path = value;
        }
    }

    [NotMapped]
    public string NameWithoutExtension
    {
        get => SysPath.GetFileNameWithoutExtension(Path);
        set
        {
            if (NameWithoutExtensionRegex().Match(value).Success is not true)
                throw new FsRenamingException("File name has forbidden characters");

            Path = $@"{Path[..(Path.LastIndexOf(Path.Contains('\\') ? '\\' : '/') + 1)]}{value}{Extension}";
        }
    }

    [NotMapped]
    public override string Name
    {
        get => SysPath.GetFileName(Path);
        set
        {
            if (NameWithExtensionRegex().Match(value).Success is not true)
                throw new FsRenamingException("File name with extension do not match pattern");

            Path = $@"{Path[..(Path.LastIndexOf(Path.Contains('\\') ? '\\' : '/') + 1)]}{value}";
        }
    }

    [NotMapped]
    public string Extension
    {
        get => SysPath.GetExtension(Path);
        set
        {
            if (ExtensionRegex().Match(value).Success is not true)
                throw new FsRenamingException("File name has forbidden characters");

            Path = $@"{Path[..(Path.LastIndexOf('.') + 1)]}{value}";
        }
    }

    [NotMapped]
    public FileInfo Info
    {
        get => new(Path);
    }

    public static implicit operator ShyFileEntity(string path)
        => new() { Path = path };

    [GeneratedRegexAttribute($@"^([a-zA-Z]:\\)([{ProhibitedSymbols}]+\\)*[{ProhibitedSymbols}]*[.][{ProhibitedSymbols}.]*$")]
    public static partial Regex WinUiPathRegex();

    [GeneratedRegexAttribute($@"/([{ProhibitedSymbols}]+/)*[{ProhibitedSymbols}.]*[.][{ProhibitedSymbols}.]*$")]
    public static partial Regex OtherPathRegex();

    [GeneratedRegexAttribute($@"^[{ProhibitedSymbols}.]+$")]
    public static partial Regex NameWithoutExtensionRegex();

    [GeneratedRegexAttribute($@"^[{ProhibitedSymbols}.]*\.[{ProhibitedSymbols}.]*$")]
    public static partial Regex NameWithExtensionRegex();

    [GeneratedRegex(@"^[^\\/:*?"".<>|\r\n]+$")]
    public static partial Regex ExtensionRegex();
}


