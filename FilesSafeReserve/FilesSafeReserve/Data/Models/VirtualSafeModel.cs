using ShyryiFileSystemLibrary.Interfaces;
using ShyryiFileSystemLibrary.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilesSafeReserve.Data.Models;

/// <summary>
/// Represents a virtual safe model.
/// </summary>
public class VirtualSafeModel : ModelBase<Guid>
{
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
    /// Gets or sets the timestamp when the virtual safe was created.
    /// </summary>
    public DateTime CreatedTimestamp { get; set; } = DateTime.Now;

    /// <summary>
    /// Gets or sets the timestamp when the virtual safe was last updated.
    /// </summary>
    public DateTime LastUpdatedTimestamp { get; set; } = DateTime.Now;

    /// <summary>
    /// Gets or sets the timestamp of the last reservation made on the virtual safe.
    /// </summary>
    public DateTime LastReservationTimestamp { get; set; } = DateTime.Now;

    /// <summary>
    /// Gets or sets the list of collection associated with the virtual safe.
    /// </summary>
    public ICollection<LogModel> Logs { get; set; } = [];

    /// <summary>
    /// Gets the directory associated with the virtual safe.
    /// </summary>
    [NotMapped]
    public DirectoryModel Directory { get => Path; }

    /// <summary>
    /// Gets the items contained within the directory associated with the virtual safe.
    /// </summary>
    [NotMapped]
    public List<IPathed>? Items { get => Directory.Patheds; }
}


