using FilesSafeReserve.App.Models;

namespace FilesSafeReserve.App.Entities.Params.ILogBuilder;

/// <summary>
/// Represents the parameters for a single log operation.
/// </summary>
public class LogBuilderOpParams
{
    /// <summary>
    /// Gets or sets the ID of the virtual safe details associated with the log operation.
    /// </summary>
    public required Guid VirtualSafeDetailsId { get; set; }

    /// <summary>
    /// Gets or sets the path of the item associated with the log operation.
    /// </summary>
    public required string ItemPath { get; set; }

    /// <summary>
    /// Gets or sets the type of the log operation.
    /// </summary>
    public required LogOperationModel.Types Type { get; set; }
}
