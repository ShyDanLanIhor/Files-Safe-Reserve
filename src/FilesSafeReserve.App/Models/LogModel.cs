using FilesSafeReserve.App.Extensions;
using FilesSafeReserve.App.Interfaces.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace FilesSafeReserve.App.Models;

/// <summary>
/// The `LogModel` class represents a log.
/// This class is decorated with the `Table` attribute to specify the name of the database table that corresponds to this class.
/// </summary>
[Table("Log")]
public class LogModel : IModelBase<Guid>
{
    /// <summary>
    /// Gets or sets the unique identifier for this instance.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Gets or sets the timestamp when this log started.
    /// </summary>
    public DateTime StartTimestamp { get; set; }

    /// <summary>
    /// Gets or sets the timestamp when this log ended.
    /// </summary>
    public DateTime EndTimestamp { get; set; }

    /// <summary>
    /// Gets or sets the collection of operations associated with this log.
    /// The default value is an empty collection.
    /// </summary>
    public ICollection<LogOperationModel> Operations { get; set; } = [];

    /// <summary>
    /// Gets the name of this log.
    /// This property is not mapped to a database column.
    /// </summary>
    [NotMapped]
    public string Name
    {
        get
        {
            string name = Operations.Count is not 0 ? "Operations group log" : "Unknown log";

            foreach (LogOperationModel.Types opType in Enum.GetValues(typeof(LogOperationModel.Types)))
            {
                if (Operations.All(op => op.Type == opType))
                    name = $"Log of type '{opType.GetName()}'";
            }

            return $"{name} in time frame '{StartTimestamp:dd/MM/yyyy HH:mm:ss}'-'{EndTimestamp:dd/MM/yyyy HH:mm:ss}'";
        }
    }

    /// <summary>
    /// Gets or sets the unique identifier of the associated virtual safe details.
    /// </summary>
    public Guid VirtualSafeDetailsId { get; set; }

    /// <summary>
    /// Gets or sets the associated virtual safe details.
    /// The default value is `null`.
    /// </summary>
    public VirtualSafeDetailsModel VirtualSafeDetails { get; set; } = null!;
}


