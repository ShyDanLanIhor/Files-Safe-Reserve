using FilesSafeReserve.Infra.Services.IServices;

namespace FilesSafeReserve.Infra.Services;

/// <summary>
/// Implementation of the application-level service interface.
/// </summary>
public class AppService : IAppService
{
    /// <summary>
    /// Ensures the existence of the documents directory for the specified application.
    /// </summary>
    /// <param name="AppName">The name of the application.</param>
    public void EnsureCreatedDocumentsDirectory(string AppName)
    {
        // Get the path of the MyDocuments folder
        string folder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

        // Create the directory for the specified application
        Directory.CreateDirectory(Path.Combine(folder, AppName));
    }
}

