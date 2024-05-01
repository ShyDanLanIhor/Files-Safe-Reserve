using FilesSafeReserve.App.Models;
using FilesSafeReserve.Infra.DataBase;
using FilesSafeReserve.Infra.Interfaces.Repositories;

namespace FilesSafeReserve.Infra.Repositories.IRepositories;

/// <summary>
/// Represents a repository interface for logs.
/// </summary>
public interface ILogRepo :
    IRepoToList<FsrDbContext, LogModel, Guid>,
    IRepoGetterById<FsrDbContext, LogModel, Guid>,
    IRepoAdder<FsrDbContext, LogModel, Guid>,
    IRepoUpdater<FsrDbContext, LogModel, Guid>,
    IRepoRemover<FsrDbContext, LogModel, Guid>,
    IRepoRemoverById<FsrDbContext, LogModel, Guid>
{

}
