using ShyryiFileSystemLibrary.Interfaces;
using ShyryiFileSystemLibrary.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilesSafeReserve.Data.Models;

/// <summary>
/// Represents a virtual safe model.
/// </summary>
public class VirtualSafeModel
{
    /// <summary>
    /// Gets or sets the unique identifier of the virtual safe.
    /// </summary>
    [Key]
    public Guid Id { get; set; } = Guid.Empty;

    /// <summary>
    /// Gets or sets the name of the virtual safe.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the description of the virtual safe.
    /// </summary>
    public string Description { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the path of the virtual safe.
    /// </summary>
    public string Path { get; set; } = string.Empty;

    /// <summary>
    /// Gets the directory model associated with the virtual safe.
    /// </summary>
    [NotMapped]
    public DirectoryModel Directory { get => Path; }

    /// <summary>
    /// Gets the items contained within the virtual safe.
    /// </summary>
    [NotMapped]
    public List<IPathable> Items { get => Directory.Pathables; }
}

