using FilesSafeReserve.App.Entities.Results.Basic;
using FilesSafeReserve.App.Models;
using FilesSafeReserve.Infra.DataBase;
using FilesSafeReserve.Infra.Interfaces.Repositories;

namespace FilesSafeReserve.Infra.Repositories.IRepositories;

public interface IDirectoryRepo :
    IRepoToList<FsrDbContext, DirectoryModel, Guid>,
    IRepoGetterById<FsrDbContext, DirectoryModel, Guid>,
    IRepoAdder<FsrDbContext, DirectoryModel, Guid>,
    IRepoUpdater<FsrDbContext, DirectoryModel, Guid>,
    IRepoRemover<FsrDbContext, DirectoryModel, Guid>,
    IRepoRemoverById<FsrDbContext, DirectoryModel, Guid>
{
    public Task<ValueResult<DirectoryModel?>> GetByPathAsync(string path);

    public ValueResult<DirectoryModel?> GetByPath(string path);
}
