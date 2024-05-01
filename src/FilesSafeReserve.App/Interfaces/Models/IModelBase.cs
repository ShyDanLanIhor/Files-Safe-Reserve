using System.ComponentModel.DataAnnotations;

namespace FilesSafeReserve.App.Interfaces.Models;

/// <summary>
/// Represents the base interface for entities with a generic identifier.
/// </summary>
/// <typeparam name="IdType">The type of the entity's identifier.</typeparam>
public interface IModelBase<IdType>
{
    /// <summary>
    /// Gets or sets the id of the model.
    /// </summary>
    [Key]
    public IdType? Id { get; set; }
}
