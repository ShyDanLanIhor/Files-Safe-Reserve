using FilesSafeReserve.Data.DataBase;
using FilesSafeReserve.Data.Interfaces.Repositories;
using FilesSafeReserve.Data.Models;

namespace FilesSafeReserve.Data.Repositories.IRepositories;

/// <summary>
/// Represents a repository interface for managing virtual safes.
/// </summary>
public interface IVirtualSafeRepo :
    IRepoToList<FsrDbContext, VirtualSafeModel, Guid>,
    IRepoGetterById<FsrDbContext, VirtualSafeModel, Guid>,
    IRepoAdder<FsrDbContext, VirtualSafeModel, Guid>,
    IRepoUpdater<FsrDbContext, VirtualSafeModel, Guid>,
    IRepoRemover<FsrDbContext, VirtualSafeModel, Guid>,
    IRepoRemoverById<FsrDbContext, VirtualSafeModel, Guid>
{
}


