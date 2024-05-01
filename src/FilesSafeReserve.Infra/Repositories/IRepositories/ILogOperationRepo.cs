using FilesSafeReserve.App.Models;
using FilesSafeReserve.Infra.DataBase;
using FilesSafeReserve.Infra.Interfaces.Repositories;

namespace FilesSafeReserve.Infra.Repositories.IRepositories;

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
