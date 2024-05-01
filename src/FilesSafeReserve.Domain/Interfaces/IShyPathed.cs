using FilesSafeReserve.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilesSafeReserve.Domain.Interfaces;

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

