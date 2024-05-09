using FilesSafeReserve.App.Entities.Results.Basic;
using FilesSafeReserve.App.Models;
using FilesSafeReserve.Infra.DataBase;
using FilesSafeReserve.Infra.Interfaces.Repositories;

namespace FilesSafeReserve.Infra.Repositories.IRepositories;

public interface IShortcutRepo :
    IRepoToList<FsrDbContext, ShortcutModel, Guid>,
    IRepoGetterById<FsrDbContext, ShortcutModel, Guid>,
    IRepoUpdater<FsrDbContext, ShortcutModel, Guid>
{
    public ValueResult<ShortcutModel?> GetByType(ShortcutModel.Types type);
    public Task<ValueResult<ShortcutModel?>> GetByTypeAsync(ShortcutModel.Types type);
}
