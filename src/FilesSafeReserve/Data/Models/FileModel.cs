using FilesSafeReserve.Data.Interfaces.Models;
using ShyryiFileSystemLibrary.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilesSafeReserve.Data.Models;

/// <summary>
/// Represents a reservation file entity.
/// </summary>
[Table("ReservationFile")]
public class FileModel : ShyFileEntity, IModelBase<Guid>
{
    /// <summary>
    /// Gets or sets the identifier for the reservation file.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the identifier for the reservation associated with this file.
    /// </summary>
    public Guid ReservationId { get; set; }

    /// <summary>
    /// Gets or sets the reservation associated with this file.
    /// </summary>
    public ReservationModel Reservation { get; set; } = null!;
}
