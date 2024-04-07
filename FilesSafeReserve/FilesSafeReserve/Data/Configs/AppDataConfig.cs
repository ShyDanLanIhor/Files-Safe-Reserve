namespace FilesSafeReserve.Data.Configs;

/// <summary>
/// Represents the configuration data for an application.
/// </summary>
public class AppDataConfig
{
    /// <summary>
    /// Gets or sets the name of the application.
    /// </summary>
    public required string AppName { get; set; }

    /// <summary>
    /// Gets or sets the full name of the application.
    /// </summary>
    public required string AppFullName { get; set; }
}

