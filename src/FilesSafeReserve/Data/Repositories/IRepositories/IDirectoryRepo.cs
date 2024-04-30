using FilesSafeReserve.Data.DataBase;
using FilesSafeReserve.Data.Interfaces.Repositories;
using FilesSafeReserve.Data.Models;

namespace FilesSafeReserve.Data.Repositories.IRepositories;

public interface IDirectoryRepo :
    IRepoToList<FsrDbContext, DirectoryModel, Guid>,
    IRepoGetterById<FsrDbContext, DirectoryModel, Guid>,
    IRepoAdder<FsrDbContext, DirectoryModel, Guid>,
    IRepoUpdater<FsrDbContext, DirectoryModel, Guid>,
    IRepoRemover<FsrDbContext, DirectoryModel, Guid>,
    IRepoRemoverById<FsrDbContext, DirectoryModel, Guid>
{

}
