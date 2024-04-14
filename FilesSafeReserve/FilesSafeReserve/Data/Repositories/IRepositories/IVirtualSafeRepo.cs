using FilesSafeReserve.Data.DataBase;
using FilesSafeReserve.Data.Interfaces.Repositories;
using FilesSafeReserve.Data.Models;

namespace FilesSafeReserve.Data.Repositories.IRepositories;

/// <summary>
/// Represents a repository interface for managing virtual safes.
/// </summary>
public interface IVirtualSafeRepo :
    IToListRepoBase<FsrDbContext, VirtualSafeModel, Guid>,
    IGetByIdRepoBase<FsrDbContext, VirtualSafeModel, Guid>,
    IAddRepoBase<FsrDbContext, VirtualSafeModel, Guid>,
    IUpdateRepoBase<FsrDbContext, VirtualSafeModel, Guid>,
    IDeleteRepoBase<FsrDbContext, VirtualSafeModel, Guid>,
    IDeleteByIdRepoBase<FsrDbContext, VirtualSafeModel, Guid>
{

}


