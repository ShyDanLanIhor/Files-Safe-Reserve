using FilesSafeReserve.App.Entities.Results.Basic;
using FilesSafeReserve.App.Models;
using FilesSafeReserve.Infra.DataBase;
using FilesSafeReserve.Infra.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FilesSafeReserve.Infra.Repositories;

public class DirectoryRepo(FsrDbContext dbContext) : IDirectoryRepo
{
    public FsrDbContext DbContext { get; } = dbContext;

    public async Task<ValueResult<DirectoryModel?>> GetByPathAsync(string path)
    {
        return await DbContext.Directories
            .FirstOrDefaultAsync(el => el.Path == path);
    }

    public ValueResult<DirectoryModel?> GetByPath(string path)
    {
        return DbContext.Directories
            .FirstOrDefault(el => el.Path == path);
    }
}
