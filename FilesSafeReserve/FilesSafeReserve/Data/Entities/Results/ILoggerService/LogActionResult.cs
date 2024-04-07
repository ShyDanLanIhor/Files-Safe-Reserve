using ShyryiFileSystemLibrary.Models;

namespace FilesSafeReserve.Data.Entities.Results.ILoggerService;

/// <summary>
/// Represents the result of logging an action.
/// </summary>
public class LogActionResult
{
    /// <summary>
    /// Gets or sets a value indicating whether the action was successfully logged.
    /// </summary>
    public required bool IsLogged { get; set; }

    /// <summary>
    /// Gets or sets any error message encountered during logging, if applicable.
    /// </summary>
    public string Error { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the directory model representing the logging file, if available.
    /// </summary>
    public DirectoryModel? LoggingFile { get; set; }
}

