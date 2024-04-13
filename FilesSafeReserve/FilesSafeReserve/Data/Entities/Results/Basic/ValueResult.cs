namespace FilesSafeReserve.Data.Entities.Results.Basic;

/// <summary>
/// Represents the result of an operation with a value.
/// </summary>
public class ValueResult : ResultEntity
{
    /// <summary>
    /// Gets a value indicating whether the operation succeeded based on the presence and truthiness of the Value property.
    /// </summary>
    public new bool IsSucceeded { get => Value is not null or false; }

    /// <summary>
    /// Gets or sets the dynamic value associated with the result.
    /// </summary>
    public dynamic? Value { get; set; }
}


/// <summary>
/// Represents the result of an operation with a value of a specified type.
/// </summary>
/// <typeparam name="ValueType">The type of the value associated with the result.</typeparam>
public class ValueResult<ValueType> : ResultEntity
{
    /// <summary>
    /// Gets a value indicating whether the operation succeeded based on the presence and truthiness of the Value property.
    /// </summary>
    public new bool IsSucceeded { get => Value is not null or false; }

    /// <summary>
    /// Gets or sets the value associated with the result.
    /// </summary>
    public ValueType? Value { get; set; }

    /// <summary>
    /// Implicitly converts a value of type <typeparamref name="ValueType"/> to a ValueResult instance.
    /// </summary>
    /// <param name="value">The value to associate with the result.</param>
    /// <returns>A ValueResult instance with the specified value.</returns>
    public static implicit operator ValueResult<ValueType>(ValueType value) => new() { Value = value };

    /// <summary>
    /// Explicitly converts a ValueResult instance to a nullable <typeparamref name="ValueType"/>.
    /// </summary>
    /// <param name="value">The ValueResult instance to convert.</param>
    /// <returns>The value associated with the result, or null if the result has no value.</returns>
    public static explicit operator ValueType?(ValueResult<ValueType> value) => value.Value;

    /// <summary>
    /// Determines whether the value associated with the specified ValueResult instance is equal to the specified boolean value.
    /// </summary>
    /// <param name="left">The ValueResult instance to compare.</param>
    /// <param name="right">The boolean value to compare.</param>
    /// <returns>True if the value associated with the left ValueResult instance equals the right boolean value or is null; otherwise, false.</returns>
    public static bool operator ==(ValueResult<ValueType> left, bool right)
        => left.Value?.Equals(right) ?? (left.Value is null);

    /// <summary>
    /// Determines whether the value associated with the specified ValueResult instance is not equal to the specified boolean value.
    /// </summary>
    /// <param name="left">The ValueResult instance to compare.</param>
    /// <param name="right">The boolean value to compare.</param>
    /// <returns>True if the value associated with the left ValueResult instance does not equal the right boolean value or is null; otherwise, false.</returns>
    public static bool operator !=(ValueResult<ValueType> left, bool right)
        => !left.Value?.Equals(right) ?? (left.Value is null);
}

