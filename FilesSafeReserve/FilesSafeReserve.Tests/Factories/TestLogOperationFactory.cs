using FilesSafeReserve.Data.Models;

namespace FilesSafeReserve.Tests.Factories;

/// <summary>
/// Factory for creating a list of log operations.
/// </summary>
public static class TestLogOperationFactory
{
    /// <summary>
    /// Creates a list of log operations.
    /// </summary>
    /// <returns>The list of log operations.</returns>
    public static List<LogOperationModel> CreateList()
    {
        return
        [
            new LogOperationModel
            {
                IsSucceeded = true,
                Type = LogOperationModel.OperationsTypes.TransferFile,
                PerformTimestamp = DateTime.Now,
                VirtualSafeFilePath = @"C:\Users\username\Documents",
                ExternalFilePath = @"C:\Users\username\Documents",
                Log = new()
                {
                    StartTimestamp = DateTime.Now,
                    EndTimestamp = DateTime.Now,
                    VirtualSafe = new()
                    {
                        Name = "Test Name 1",
                        Description = "Test Description 1",
                        Path = @"C:\Users\username\Documents",
                    }
                }
            },
            new LogOperationModel
            {
                IsSucceeded = true,
                Type = LogOperationModel.OperationsTypes.TransferFile,
                PerformTimestamp = DateTime.Now,
                VirtualSafeFilePath = @"C:\Users\username\Documents",
                ExternalFilePath = @"C:\Users\username\Documents",
                Log = new()
                {
                    StartTimestamp = DateTime.Now,
                    EndTimestamp = DateTime.Now,
                    VirtualSafe = new()
                    {
                        Name = "Test Name 2",
                        Description = "Test Description 2",
                        Path = @"C:\Users\username\Documents",
                    }
                }
            },
            new LogOperationModel
            {
                IsSucceeded = true,
                Type = LogOperationModel.OperationsTypes.TransferFile,
                PerformTimestamp = DateTime.Now,
                VirtualSafeFilePath = @"C:\Users\username\Documents",
                ExternalFilePath = @"C:\Users\username\Documents",
                Log = new()
                {
                    StartTimestamp = DateTime.Now,
                    EndTimestamp = DateTime.Now,
                    VirtualSafe = new()
                    {
                        Name = "Test Name 3",
                        Description = "Test Description 3",
                        Path = @"C:\Users\username\Documents",
                    }
                }
            }
        ];
    }
}
