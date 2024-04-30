using FilesSafeReserve.Data.Models;

namespace FilesSafeReserve.Data.Extensions;

/// <summary>
/// Provides extension methods for converting <see cref="LogOperationModel.Types"/> enum values to strings representing operation types.
/// </summary>
public static class LogOperationTypeExtensions
{
    /// <summary>
    /// Converts the specified <paramref name="type"/> enum value to its corresponding string representation.
    /// </summary>
    /// <param name="type">The <see cref="LogOperationModel.Types"/> enum value.</param>
    /// <returns>A string representing the operation type.</returns>
    public static string ToString(this LogOperationModel.Types type)
        => type switch
        {
            LogOperationModel.Types.CreateVirtualSafe => "Create virtual safe",
            LogOperationModel.Types.UpdateVirtualSafe => "Update virtual safe",
            LogOperationModel.Types.DeleteVirtualSafe => "Delete virtual safe",
            LogOperationModel.Types.TransferToVirtualSafe => "Transfer to virtual safe",
            LogOperationModel.Types.RemoveFromReservation => "Remove from reservation",
            LogOperationModel.Types.DeleteFromVirtualSafe => "Delete from virtual safe",
            _ => "Unknown"
        };

    /// <summary>
    /// Gets the name of the specified <paramref name="type"/> enum value.
    /// </summary>
    /// <param name="type">The <see cref="LogOperationModel.Types"/> enum value.</param>
    /// <returns>The name of the operation type.</returns>
    public static string GetName(this LogOperationModel.Types type)
        => type switch
        {
            LogOperationModel.Types.CreateVirtualSafe => "Virtual safe creation",
            LogOperationModel.Types.UpdateVirtualSafe => "Virtual safe updating",
            LogOperationModel.Types.DeleteVirtualSafe => "Virtual safe deletion",
            LogOperationModel.Types.TransferToVirtualSafe => "Transferring to virtual safe",
            LogOperationModel.Types.RemoveFromReservation => "Removing from reservation",
            LogOperationModel.Types.DeleteFromVirtualSafe => "Deletion from virtual safe",
            _ => "Unknown"
        };
}
