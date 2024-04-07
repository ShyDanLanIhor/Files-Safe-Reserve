using FilesSafeReserve.Data.Entities.Params.IDataBaseService;
using FilesSafeReserve.Data.Services.IServices;

namespace FilesSafeReserve.Data.Services;

/// <summary>
/// Implementation of the database service interface.
/// </summary>
public class DbService : IDbService
{
    /// <summary>
    /// Gets the path to the database based on the provided parameters.
    /// </summary>
    /// <param name="parameters">The parameters for obtaining the database path.</param>
    /// <returns>The path to the database.</returns>
    public string GetDbPath(GetDbPathParams parameters)
    {
        // Get the path of the MyDocuments folder
        var myDocuments = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        // Combine the path with the application name and database directory
        var dbDirectory = Path.Combine(myDocuments, parameters.AppName, $"{parameters.DataBaseName}_db");

        // Create the database directory if it doesn't exist
        Directory.CreateDirectory(dbDirectory);

        // Combine the directory path with the database file name
        return Path.Combine(dbDirectory, $"{parameters.DataBaseName}.db");
    }
}

