using System.Diagnostics.CodeAnalysis;

namespace FilesSafeReserve.Data.Entities.Results.Basic;

/// <summary>
/// Represents the result of an operation with an object.
/// </summary>
public class ObjResult : ResultEntity
{
    /// <summary>
    /// Gets a value indicating whether the operation succeeded based on the presence and truthiness of the Object property.
    /// </summary>
    [MemberNotNullWhen(returnValue: true, nameof(Object))]
    public new bool IsSucceeded { get => Object is not null or false; }

    /// <summary>
    /// Gets or sets the object associated with the result.
    /// </summary>
    public object? Object { get; set; }
}

