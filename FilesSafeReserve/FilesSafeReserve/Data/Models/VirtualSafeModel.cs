using ShyryiFileSystemLibrary.Interfaces;
using ShyryiFileSystemLibrary.Models;
using System.ComponentModel.DataAnnotations;
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
    /// Gets or sets the creation date.
    /// </summary>
    public DateTime CreatedTimestamp { get; set; } = DateTime.Now;

    /// <summary>
    /// Gets or sets when was last update by user.
    /// </summary>
    public DateTime LastUpdatedTimestamp { get; set; } = DateTime.Now;

    /// <summary>
    /// Gets or sets when was last data reservation.
    /// </summary>
    public DateTime LastReservationTimestamp { get; set; } = DateTime.Now;

    public List<LogModel> AssociatedLogs { get; set; } = new();

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

