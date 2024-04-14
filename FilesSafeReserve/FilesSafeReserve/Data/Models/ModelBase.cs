using System.ComponentModel.DataAnnotations;

namespace FilesSafeReserve.Data.Models;

/// <summary>
/// Represents a base model with an identifier.
/// </summary>
/// <typeparam name="IdType">The type of the identifier.</typeparam>
public class ModelBase<IdType>
{
    /// <summary>
    /// Gets or sets the identifier of the model.
    /// </summary>
    [Key]
    public IdType? Id { get; set; }
}

