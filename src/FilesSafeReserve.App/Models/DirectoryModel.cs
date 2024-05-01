using FilesSafeReserve.App.Interfaces.Models;
using FilesSafeReserve.Domain.Entities;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilesSafeReserve.App.Models;

/// <summary>
/// Represents a reservation directory entity.
/// </summary>
[Table("ReservationDirectory")]
public class DirectoryModel : ShyDirectoryEntity, IModelBase<Guid>
{
    /// <summary>
    /// Gets or sets the identifier for the reservation directory.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the identifier for the reservation associated with this directory.
    /// </summary>
    public Guid ReservationId { get; set; }

    /// <summary>
    /// Gets or sets the reservation associated with this directory.
    /// </summary>
    public ReservationModel Reservation { get; set; } = null!;
}

