using FilesSafeReserve.App.Interfaces.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilesSafeReserve.App.Models;

/// <summary>
/// The `VirtualSafeDetailsModel` class represents the details of a virtual safe.
/// This class is decorated with the `Table` attribute to specify the name of the database table that corresponds to this class.
/// </summary>
[Table("VirtualSafeDetails")]
public class VirtualSafeDetailsModel : IModelBase<Guid>
{
    /// <summary>
    /// Gets or sets the unique identifier for this instance.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the timestamp when this instance was created.
    /// The default value is the current date and time.
    /// </summary>
    public DateTime CreatedTimestamp { get; set; } = DateTime.Now;

    /// <summary>
    /// Gets or sets the timestamp when this instance was last updated.
    /// The default value is the current date and time.
    /// </summary>
    public DateTime UpdatedTimestamp { get; set; } = DateTime.Now;

    /// <summary>
    /// Gets or sets the timestamp when this instance was reserved.
    /// The default value is the current date and time.
    /// </summary>
    public DateTime ReservedTimestamp { get; set; } = DateTime.Now;

    /// <summary>
    /// Gets or sets the collection of logs associated with this instance.
    /// The default value is an empty collection.
    /// </summary>
    public ICollection<LogModel> Logs { get; set; } = [];

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

