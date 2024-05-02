using FilesSafeReserve.App.Interfaces.Models;
using FilesSafeReserve.Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilesSafeReserve.App.Models;

/// <summary>
/// The `ReservationModel` class represents a reservation.
/// This class is decorated with the `Table` attribute to specify the name of the database table that corresponds to this class.
/// </summary>
[Table("Reservation")]
public class ReservationModel : IModelBase<Guid>
{
    /// <summary>
    /// Gets or sets the unique identifier for this instance.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the time when last reservation was made.
    /// </summary>
    public DateTime ReservedTimestamp { get; set; } = DateTime.MinValue;

    /// <summary>
    /// Gets or sets the time of day when reservation takes place.
    /// </summary>
    public TimeSpan ToReserveTimeSpan { get; set; } = TimeSpan.Zero;

    /// <summary>
    /// Gets or sets the collection of files associated with this reservation.
    /// The default value is an empty collection.
    /// </summary>
    public ICollection<FileModel> Files { get; set; } = [];

    /// <summary>
    /// Gets or sets the collection of directories associated with this reservation.
    /// The default value is an empty collection.
    /// </summary>
    public ICollection<DirectoryModel> Directories { get; set; } = [];

    /// <summary>
    /// Gets a collection of pathed items associated with this reservation.
    /// This property is not mapped to a database column.
    /// </summary>
    [NotMapped]
    public ICollection<IShyPathed> Patheds
    {
        get
        {
            List<IShyPathed> items = [];

            foreach (var file in Files)
                items.Add(file);

            foreach (var directory in Directories)
                items.Add(directory);

            return items;
        }
    }

    /// <summary>
    /// Gets a collection of key-value pairs where the key is the unique identifier of a pathed item and the value is the pathed item itself.
    /// This property is not mapped to a database column.
    /// </summary>
    [NotMapped]
    public ICollection<KeyValuePair<Guid, IShyPathed>> IdsPathedsPair
    {
        get
        {
            List<KeyValuePair<Guid, IShyPathed>> items = [];

            foreach (var file in Files)
                items.Add(new KeyValuePair<Guid, IShyPathed>(file.Id, file));

            foreach (var directory in Directories)
                items.Add(new KeyValuePair<Guid, IShyPathed>(directory.Id, directory));

            return items;
        }
    }

    /// <summary>
    /// Gets or sets the unique identifier of the associated safe.
    /// </summary>
    public Guid SafeId { get; set; }

    /// <summary>
    /// Gets or sets the associated virtual safe.
    /// The default value is `null`.
    /// </summary>
    public VirtualSafeModel Safe { get; set; } = null!;
}

