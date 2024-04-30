using FilesSafeReserve.Data.DataBase;
using FilesSafeReserve.Data.Interfaces.Repositories;
using FilesSafeReserve.Data.Models;

namespace FilesSafeReserve.Data.Repositories.IRepositories;

public interface IFileRepo :
    IRepoToList<FsrDbContext, FileModel, Guid>,
    IRepoGetterById<FsrDbContext, FileModel, Guid>,
    IRepoAdder<FsrDbContext, FileModel, Guid>,
    IRepoUpdater<FsrDbContext, FileModel, Guid>,
    IRepoRemover<FsrDbContext, FileModel, Guid>,
    IRepoRemoverById<FsrDbContext, FileModel, Guid>
{

}
