namespace FilesSafeReserve.Data.Entities.Results.Basic;

/// <summary>
/// Represents the result of an operation.
/// </summary>
public class ResultEntity
{
    /// <summary>
    /// Gets or sets a value indicating whether the operation succeeded.
    /// </summary>
    public bool IsSucceeded { get; set; }

    /// <summary>
    /// Implicitly converts a boolean value to a ResultEntity instance.
    /// </summary>
    /// <param name="value">The boolean value indicating the success of the operation.</param>
    /// <returns>A ResultEntity instance.</returns>
    public static implicit operator ResultEntity(bool value) => new() { IsSucceeded = value };

    /// <summary>
    /// Explicitly converts a ResultEntity instance to a boolean value.
    /// </summary>
    /// <param name="value">The ResultEntity instance to convert.</param>
    /// <returns>The boolean value indicating the success of the operation.</returns>
    public static explicit operator bool(ResultEntity value) => value.IsSucceeded;

    /// <summary>
    /// Determines whether two specified instances of ResultEntity and boolean are equal.
    /// </summary>
    /// <param name="left">The first ResultEntity instance to compare.</param>
    /// <param name="right">The boolean value to compare.</param>
    /// <returns>True if the Succeeded property of the left ResultEntity instance equals the right boolean value; otherwise, false.</returns>
    public static bool operator ==(ResultEntity left, bool right) => left.IsSucceeded.Equals(right);

    /// <summary>
    /// Determines whether two specified instances of ResultEntity and boolean are not equal.
    /// </summary>
    /// <param name="left">The first ResultEntity instance to compare.</param>
    /// <param name="right">The boolean value to compare.</param>
    /// <returns>True if the Succeeded property of the left ResultEntity instance does not equal the right boolean value; otherwise, false.</returns>
    public static bool operator !=(ResultEntity left, bool right) => !left.IsSucceeded.Equals(right);
}

