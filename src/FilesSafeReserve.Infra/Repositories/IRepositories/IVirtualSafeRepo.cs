using FilesSafeReserve.App.Models;
using FilesSafeReserve.Infra.DataBase;
using FilesSafeReserve.Infra.Interfaces.Repositories;

namespace FilesSafeReserve.Infra.Repositories.IRepositories;

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


