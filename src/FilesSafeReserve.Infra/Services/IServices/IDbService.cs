using FilesSafeReserve.Infra.Entities.Params.IDataBaseService;

namespace FilesSafeReserve.Infra.Services.IServices;

/// <summary>
/// Interface for accessing database-related services.
/// </summary>
public interface IDbService
{
    /// <summary>
    /// Gets the path to the database based on the provided parameters.
    /// </summary>
    /// <param name="parameters">The parameters for obtaining the database path.</param>
    /// <returns>The path to the database.</returns>
    public string GetDbPath(GetDbPathParams parameters);
}

