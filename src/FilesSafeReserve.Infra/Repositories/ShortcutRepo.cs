using FilesSafeReserve.App.Entities.Results.Basic;
using FilesSafeReserve.App.Models;
using FilesSafeReserve.Infra.DataBase;
using FilesSafeReserve.Infra.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FilesSafeReserve.Infra.Repositories;

public class ShortcutRepo(FsrDbContext dbContext) : IShortcutRepo
{
    public FsrDbContext DbContext { get; } = dbContext;

    ValueResult<ShortcutModel?> IShortcutRepo.GetByType(ShortcutModel.Types type)
        => DbContext.Shortcuts.Where(shortcut => shortcut.Type == type).FirstOrDefault();

    async Task<ValueResult<ShortcutModel?>> IShortcutRepo.GetByTypeAsync(ShortcutModel.Types type)
        => await DbContext.Shortcuts.Where(shortcut => shortcut.Type == type).FirstOrDefaultAsync();
}
