using ShyryiFileSystemLibrary.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShyryiFileSystemLibrary.Entities;

public abstract class ShyFsEntity : IShyPathed
{
    public abstract string Path { get; set; }

    [NotMapped]
    public const string ProhibitedSymbols = @"^\\/:*?""<>|\r\n";

    [NotMapped]
    public abstract string Name { get; set; }

    [NotMapped]
    public ShyFsType Type
    {
        get
        {
            if (Directory.Exists(Path))
                return ShyFsType.Directory;
            else if (File.Exists(Path))
                return ShyFsType.File;
            else
                return ShyFsType.NonExistent;
        }
    }

    [NotMapped]
    public bool Exists
    {
        get => Type is not ShyFsType.NonExistent;
    }

    public static bool operator ==(ShyFsEntity directory1, ShyFsEntity directory2)
        => directory1.Equals(directory2);

    public static bool operator !=(ShyFsEntity directory1, ShyFsEntity directory2)
        => !directory1.Equals(directory2);

    public override bool Equals(object? obj)
        => obj is ShyFsEntity && Equals(this, obj);

    public override int GetHashCode() => Path.GetHashCode();
}

public enum ShyFsType
{
    File,
    Directory,
    NonExistent
}