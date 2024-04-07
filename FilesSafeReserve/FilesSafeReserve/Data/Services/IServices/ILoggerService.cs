using FilesSafeReserve.Data.Entities.Params.ILoggerService;
using FilesSafeReserve.Data.Entities.Results.ILoggerService;
using FilesSafeReserve.Data.Models;

namespace FilesSafeReserve.Data.Services.IServices;

/// <summary>
/// Interface for logging services.
/// </summary>
public interface ILoggerService
{
    /// <summary>
    /// Gets the log text based on the provided virtual safe model.
    /// </summary>
    /// <param name="model">The virtual safe model.</param>
    /// <returns>The log text.</returns>
    public string GetLogTextBy(VirtualSafeModel model);

    /// <summary>
    /// Logs transfer action based on the provided parameters.
    /// </summary>
    /// <param name="parameters">The parameters for logging transfer action.</param>
    /// <returns>The result of the logging action.</returns>
    public LogActionResult LogTransferItemsAction(LogTransferActionParams parameters);

    /// <summary>
    /// Logs delete action based on the provided parameters.
    /// </summary>
    /// <param name="parameters">The parameters for logging delete action.</param>
    /// <returns>The result of the logging action.</returns>
    public LogActionResult LogDeleteItemsAction(LogDeleteActionParams parameters);
}

