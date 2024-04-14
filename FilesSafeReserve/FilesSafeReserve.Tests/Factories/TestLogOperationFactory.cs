using FilesSafeReserve.Data.Models;

namespace FilesSafeReserve.Tests.Factories;

public static class TestLogOperationFactory
{
    public static List<LogOperationModel> CreateList()
    {
        return new()
        {
            new LogOperationModel
            {
                IsSucceeded = true,
                Type = LogOperationModel.OperationsTypes.TransferFile,
                PerformTimestamp = DateTime.Now,
                VirtualSafeFilePath = @"C:\Users\username\Documents",
                ExternalFilePath = @"C:\Users\username\Documents",
                AssociatedLog = new()
                {
                    StartTimestamp = DateTime.Now,
                    EndTimestamp = DateTime.Now,
                    AssociatedVirtualSafe = new()
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
                AssociatedLog = new()
                {
                    StartTimestamp = DateTime.Now,
                    EndTimestamp = DateTime.Now,
                    AssociatedVirtualSafe = new()
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
                AssociatedLog = new()
                {
                    StartTimestamp = DateTime.Now,
                    EndTimestamp = DateTime.Now,
                    AssociatedVirtualSafe = new()
                    {
                        Name = "Test Name 3",
                        Description = "Test Description 3",
                        Path = @"C:\Users\username\Documents",
                    }
                }
            }
        };
    }
}
