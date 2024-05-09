using FilesSafeReserve.App.Models;

namespace FilesSafeReserve.App.Entities.Results.ILogBuilder;

/// <summary>
/// Represents the result of a logging operation.
/// </summary>
public record LogBuilderResult(LogModel Log)
{
    /// <summary>
    /// Gets a value indicating whether all operations in the log were successful.
    /// </summary>
    public bool IsSucceeded { get => Log.Operations.All(el => el.IsSucceeded is true); }
}

/// <summary>
/// Represents the result of a logging operation with a specific result type.
/// </summary>
public record LogBuilderResult<ResultType>(LogModel Log, ResultType? ActionResult)
{
    /// <summary>
    /// Gets a value indicating whether all operations in the log were successful.
    /// </summary>
    public bool IsSucceeded { get => Log.Operations.All(el => el.IsSucceeded is true); }
}

/// <summary>
/// Represents the result of logging multiple operations with a specific result type.
/// </summary>
public record LogsBuilderResult<ResultType>(LogModel Log, IEnumerable<ResultType?>? ActionResult)
{
    /// <summary>
    /// Gets a value indicating whether all operations in the log were successful.
    /// </summary>
    public bool IsSucceeded { get => Log.Operations.All(el => el.IsSucceeded is true); }
}
