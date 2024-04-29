using FilesSafeReserve.Data.Interfaces.Models;
using ShyryiFileSystemLibrary.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilesSafeReserve.Data.Models;

/// <summary>
/// Represents a virtual safe entity.
/// </summary>
[Table("VirtualSafe")]
public class VirtualSafeModel : IModelBase<Guid>
{
    /// <summary>
    /// Gets or sets the unique identifier of the virtual safe.
    /// </summary>
    public Guid Id { get; set; }

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
    /// Gets the directory associated with the virtual safe.
    /// </summary>
    [NotMapped]
    public ShyDirectoryEntity Directory { get => Path; }

    /// <summary>
    /// Gets or sets the details of the virtual safe.
    /// </summary>
    public VirtualSafeDetailsModel Details { get; set; } = null!;

    /// <summary>
    /// Gets or sets the reservation associated with the virtual safe.
    /// </summary>
    public ReservationModel Reservation { get; set; } = null!;
}