using FilesSafeReserve.Data.DataBase;
using FilesSafeReserve.Data.Interfaces.Repositories;
using FilesSafeReserve.Data.Models;

namespace FilesSafeReserve.Data.Repositories.IRepositories;

/// <summary>
/// Represents a repository interface for log operations.
/// </summary>
public interface ILogOperationRepo :
    IRepoToList<FsrDbContext, LogOperationModel, Guid>,
    IRepoGetterById<FsrDbContext, LogOperationModel, Guid>,
    IRepoAdder<FsrDbContext, LogOperationModel, Guid>,
    IRepoUpdater<FsrDbContext, LogOperationModel, Guid>,
    IRepoRemover<FsrDbContext, LogOperationModel, Guid>,
    IRepoRemoverById<FsrDbContext, LogOperationModel, Guid>
{

}
