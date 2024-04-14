using FilesSafeReserve.Data.DataBase;
using FilesSafeReserve.Data.Interfaces.Repositories;
using FilesSafeReserve.Data.Models;

namespace FilesSafeReserve.Data.Repositories.IRepositories;

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
