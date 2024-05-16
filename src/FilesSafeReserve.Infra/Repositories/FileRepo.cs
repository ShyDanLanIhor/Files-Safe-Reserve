using FilesSafeReserve.App.Entities.Results.Basic;
using FilesSafeReserve.App.Models;
using FilesSafeReserve.Infra.DataBase;
using FilesSafeReserve.Infra.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FilesSafeReserve.Infra.Repositories;

public class FileRepo(FsrDbContext dbContext) : IFileRepo
{
    public FsrDbContext DbContext { get; } = dbContext;

    public async Task<ValueResult<FileModel?>> GetByPathAsync(string path)
    {
        return await DbContext.Files
            .FirstOrDefaultAsync(el => el.Path == path);
    }

    public ValueResult<FileModel?> GetByPath(string path)
    {
        return DbContext.Files
            .FirstOrDefault(el => el.Path == path);
    }
}
