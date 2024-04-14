using FilesSafeReserve.Data.Models;

namespace FilesSafeReserve.Tests.Factories;

/// <summary>
/// Factory for creating a list of virtual safes.
/// </summary>
public static class TestVirtualSafeFactory
{
    /// <summary>
    /// Creates a list of virtual safes.
    /// </summary>
    /// <returns>The list of virtual safes.</returns>
    public static List<VirtualSafeModel> CreateList()
    {
        return
        [
            new VirtualSafeModel
            {
                Name = "Test Name 1",
                Description = "Test Description 1",
                Path = @"C:\Users\username\Documents",
                Logs =
                [
                    new LogModel
                    {
                        StartTimestamp = DateTime.Now,
                        EndTimestamp = DateTime.Now,
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
                ],
            },
            new VirtualSafeModel
            {
                Name = "Test Name 2",
                Description = "Test Description 2",
                Path = @"C:\Users\username\Documents",
                Logs =
                [
                    new LogModel
                    {
                        StartTimestamp = DateTime.Now,
                        EndTimestamp = DateTime.Now,
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
                ],
            },
            new VirtualSafeModel
            {
                Name = "Test Name 3",
                Description = "Test Description 3",
                Path = @"C:\Users\username\Documents",
                Logs =
                [
                    new LogModel
                    {
                        StartTimestamp = DateTime.Now,
                        EndTimestamp = DateTime.Now,
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
                ],
            }
        ];
    }
}
