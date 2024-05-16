using FilesSafeReserve.App.Entities.Results.Basic;
using FilesSafeReserve.App.Models;
using FilesSafeReserve.Infra.DataBase;
using FilesSafeReserve.Infra.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FilesSafeReserve.Infra.Repositories;

public class FileRepo(FsrDbContext dbContext) : IFileRepo
{
    public FsrDbContext DbContext { get; } = dbContext;

    public async Task<ValueResult<FileModel?>> GetByIdAsync(Guid id)
    {
        return await DbContext.Files
            .Include(field => field.Reservation)
                .ThenInclude(field => field.Directories)
            .Include(field => field.Reservation)
                .ThenInclude(field => field.Safe)
                    .ThenInclude(field => field.Details)
                        .ThenInclude(field => field.RemovableDrive)
            .Include(field => field.Reservation)
                .ThenInclude(field => field.Safe)
                    .ThenInclude(field => field.Details)
                        .ThenInclude(field => field.Logs)
                            .ThenInclude(field => field.Operations)
            .FirstOrDefaultAsync(el => el.Id == id);
    }

    public ValueResult<FileModel?> GetById(Guid id)
    {
        return DbContext.Files
            .Include(field => field.Reservation)
                .ThenInclude(field => field.Directories)
            .Include(field => field.Reservation)
                .ThenInclude(field => field.Safe)
                    .ThenInclude(field => field.Details)
                        .ThenInclude(field => field.RemovableDrive)
            .Include(field => field.Reservation)
                .ThenInclude(field => field.Safe)
                    .ThenInclude(field => field.Details)
                        .ThenInclude(field => field.Logs)
                            .ThenInclude(field => field.Operations)
            .FirstOrDefault(el => el.Id == id);
    }

    public async Task<List<FileModel>> ToListAsync()
    {
        return await DbContext.Files
            .Include(field => field.Reservation)
                .ThenInclude(field => field.Directories)
            .Include(field => field.Reservation)
                .ThenInclude(field => field.Safe)
                    .ThenInclude(field => field.Details)
                        .ThenInclude(field => field.RemovableDrive)
            .Include(field => field.Reservation)
                .ThenInclude(field => field.Safe)
                    .ThenInclude(field => field.Details)
                        .ThenInclude(field => field.Logs)
                            .ThenInclude(field => field.Operations)
            .ToListAsync();
    }

    public List<FileModel> ToList()
    {
        return [.. DbContext.Files
            .Include(field => field.Reservation)
                .ThenInclude(field => field.Directories)
            .Include(field => field.Reservation)
                .ThenInclude(field => field.Safe)
                    .ThenInclude(field => field.Details)
                        .ThenInclude(field => field.RemovableDrive)
            .Include(field => field.Reservation)
                .ThenInclude(field => field.Safe)
                    .ThenInclude(field => field.Details)
                        .ThenInclude(field => field.Logs)
                            .ThenInclude(field => field.Operations)];
    }

    public async Task<ValueResult<FileModel?>> GetByPathAsync(string path)
    {
        return await DbContext.Files
            .Include(field => field.Reservation)
                .ThenInclude(field => field.Directories)
            .Include(field => field.Reservation)
                .ThenInclude(field => field.Safe)
                    .ThenInclude(field => field.Details)
                        .ThenInclude(field => field.RemovableDrive)
            .Include(field => field.Reservation)
                .ThenInclude(field => field.Safe)
                    .ThenInclude(field => field.Details)
                        .ThenInclude(field => field.Logs)
                            .ThenInclude(field => field.Operations)
            .FirstOrDefaultAsync(el => el.Path == path);
    }

    public ValueResult<FileModel?> GetByPath(string path)
    {
        return DbContext.Files
            .Include(field => field.Reservation)
                .ThenInclude(field => field.Directories)
            .Include(field => field.Reservation)
                .ThenInclude(field => field.Safe)
                    .ThenInclude(field => field.Details)
                        .ThenInclude(field => field.RemovableDrive)
            .Include(field => field.Reservation)
                .ThenInclude(field => field.Safe)
                    .ThenInclude(field => field.Details)
                        .ThenInclude(field => field.Logs)
                            .ThenInclude(field => field.Operations)
            .FirstOrDefault(el => el.Path == path);
    }
}
