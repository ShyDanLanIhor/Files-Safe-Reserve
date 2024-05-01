namespace FilesSafeReserve.Infra.Services.IServices;

/// <summary>
/// Interface for application-level services.
/// </summary>
public interface IAppService
{
    /// <summary>
    /// Ensures the existence of the documents directory for the specified application.
    /// </summary>
    /// <param name="AppName">The name of the application.</param>
    public void EnsureCreatedDocumentsDirectory(string AppName);
}

