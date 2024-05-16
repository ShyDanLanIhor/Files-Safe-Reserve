using FilesSafeReserve.App.Models;
using FilesSafeReserve.Infra.DataBase;
using FilesSafeReserve.Infra.Interfaces.Repositories;

namespace FilesSafeReserve.Infra.Repositories.IRepositories;

/// <summary>
/// Represents a repository interface for managing removable drives.
/// </summary>
public interface IRemovableDriveRepo :
    IRepoToList<FsrDbContext, RemovableDriveModel, Guid>,
    IRepoGetterById<FsrDbContext, RemovableDriveModel, Guid>,
    IRepoAdder<FsrDbContext, RemovableDriveModel, Guid>,
    IRepoUpdater<FsrDbContext, RemovableDriveModel, Guid>,
    IRepoRemover<FsrDbContext, RemovableDriveModel, Guid>,
    IRepoRemoverById<FsrDbContext, RemovableDriveModel, Guid>
{

}
