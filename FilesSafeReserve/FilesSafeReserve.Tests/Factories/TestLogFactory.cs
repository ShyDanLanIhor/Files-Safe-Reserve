using FilesSafeReserve.Data.Models;

namespace FilesSafeReserve.Tests.Factories;

/// <summary>
/// Factory for creating a list of logs.
/// </summary>
public static class TestLogFactory
{
    /// <summary>
    /// Creates a list of logs.
    /// </summary>
    /// <returns>The list of logs.</returns>
    public static List<LogModel> CreateList()
    {
        return
        [
            new LogModel
            {
                StartTimestamp = DateTime.Now,
                EndTimestamp = DateTime.Now,
                VirtualSafe = new()
                {
                    Name = "Test Name 1",
                    Description = "Test Description 1",
                    Path = @"C:\Users\username\Documents",
                },
                LogOperations =
                [
                    new LogOperationModel
                    {
                        IsSucceeded = true,
                        Type = LogOperationModel.OperationsTypes.TransferFile,
                        PerformTimestamp = DateTime.Now,
                        VirtualSafeFilePath = @"C:\Users\username\Documents",
                        ExternalFilePath = @"C:\Users\username\Documents"
                    },
                    new LogOperationModel
                    {
                        IsSucceeded = true,
                        Type = LogOperationModel.OperationsTypes.TransferFile,
                        PerformTimestamp = DateTime.Now,
                        VirtualSafeFilePath = @"C:\Users\username\Documents",
                        ExternalFilePath = @"C:\Users\username\Documents"
                    },
                    new LogOperationModel
                    {
                        IsSucceeded = true,
                        Type = LogOperationModel.OperationsTypes.TransferFile,
                        PerformTimestamp = DateTime.Now,
                        VirtualSafeFilePath = @"C:\Users\username\Documents",
                        ExternalFilePath = @"C:\Users\username\Documents"
                    }
                ]
            },
            new LogModel
            {
                StartTimestamp = DateTime.Now,
                EndTimestamp = DateTime.Now,
                VirtualSafe = new()
                {
                    Name = "Test Name 2",
                    Description = "Test Description 2",
                    Path = @"C:\Users\username\Documents",
                },
                LogOperations =
                [
                    new LogOperationModel
                    {
                        IsSucceeded = true,
                        Type = LogOperationModel.OperationsTypes.TransferFile,
                        PerformTimestamp = DateTime.Now,
                        VirtualSafeFilePath = @"C:\Users\username\Documents",
                        ExternalFilePath = @"C:\Users\username\Documents"
                    },
                    new LogOperationModel
                    {
                        IsSucceeded = true,
                        Type = LogOperationModel.OperationsTypes.TransferFile,
                        PerformTimestamp = DateTime.Now,
                        VirtualSafeFilePath = @"C:\Users\username\Documents",
                        ExternalFilePath = @"C:\Users\username\Documents"
                    },
                    new LogOperationModel
                    {
                        IsSucceeded = true,
                        Type = LogOperationModel.OperationsTypes.TransferFile,
                        PerformTimestamp = DateTime.Now,
                        VirtualSafeFilePath = @"C:\Users\username\Documents",
                        ExternalFilePath = @"C:\Users\username\Documents"
                    }
                ]
            },
            new LogModel
            {
                StartTimestamp = DateTime.Now,
                EndTimestamp = DateTime.Now,
                VirtualSafe = new()
                {
                    Name = "Test Name 3",
                    Description = "Test Description 3",
                    Path = @"C:\Users\username\Documents",
                },
                LogOperations =
                [
                    new LogOperationModel
                    {
                        IsSucceeded = true,
                        Type = LogOperationModel.OperationsTypes.TransferFile,
                        PerformTimestamp = DateTime.Now,
                        VirtualSafeFilePath = @"C:\Users\username\Documents",
                        ExternalFilePath = @"C:\Users\username\Documents"
                    },
                    new LogOperationModel
                    {
                        IsSucceeded = true,
                        Type = LogOperationModel.OperationsTypes.TransferFile,
                        PerformTimestamp = DateTime.Now,
                        VirtualSafeFilePath = @"C:\Users\username\Documents",
                        ExternalFilePath = @"C:\Users\username\Documents"
                    },
                    new LogOperationModel
                    {
                        IsSucceeded = true,
                        Type = LogOperationModel.OperationsTypes.TransferFile,
                        PerformTimestamp = DateTime.Now,
                        VirtualSafeFilePath = @"C:\Users\username\Documents",
                        ExternalFilePath = @"C:\Users\username\Documents"
                    }
                ]
            }
        ];
    }
}
