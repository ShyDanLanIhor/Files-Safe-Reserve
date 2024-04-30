using ShyryiFileSystemLibrary.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShyryiFileSystemLibrary.Interfaces;

public interface IShyPathed
{
    public string Path { get; set; }

    [NotMapped]
    public ShyFsType Type { get; }

    [NotMapped]
    public bool Exists { get; }

    [NotMapped]
    public string Name { get; set; }
}

