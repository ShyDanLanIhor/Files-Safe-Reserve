namespace FilesSafeReserve.Data.Entities.Params.IDataBaseService;

/// <summary>
/// Represents the parameters for retrieving the database path.
/// </summary>
public class GetDbPathParams
{
    /// <summary>
    /// Gets or sets the name of the application.
    /// </summary>
    public required string AppName { get; set; } = string.Empty;

    /// <summary>
    /// Gets or sets the name of the database.
    /// </summary>
    public required string DataBaseName { get; set; } = string.Empty;
}
