using FilesSafeReserve.App.Models;

namespace FilesSafeReserve.App.Entities.Params.ILogBuilder;

/// <summary>
/// The `LogBuilderLogOpsParams` class is used to log operations parameters.
/// </summary>
public class LogBuilderOpsParams
{
    /// <summary>
    /// Gets or sets the ID of the virtual safe details. This is a required property.
    /// </summary>
    /// <value>The ID of the virtual safe details.</value>
    /// <see cref="Guid"/>
    public required Guid VirtualSafeDetailsId { get; set; }

    /// <summary>
    /// Gets or sets the collection of operations parameters. This is a required property.
    /// </summary>
    /// <value>The collection of operations parameters.</value>
    /// <see cref="ICollection{T}"/>
    public required ICollection<OperationsParams> Operations { get; set; }

    /// <summary>
    /// The `OperationsParams` class is used to define the parameters for each operation.
    /// </summary>
    public class OperationsParams
    {
        /// <summary>
        /// Gets or sets the path of the item. This is a required property.
        /// </summary>
        /// <value>The path of the item.</value>
        public required string ItemPath { get; set; }

        /// <summary>
        /// Gets or sets the type of the log operation. This is a required property.
        /// </summary>
        /// <value>The type of the log operation.</value>
        /// <see cref="LogOperationModel.Types"/>
        public required LogOperationModel.Types Type { get; set; }
    }
}
