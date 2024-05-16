using FilesSafeReserve.App.Entities.Results.Basic;
using FilesSafeReserve.App.Models;
using FilesSafeReserve.Infra.DataBase;
using FilesSafeReserve.Infra.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FilesSafeReserve.Infra.Repositories;

public class DirectoryRepo(FsrDbContext dbContext) : IDirectoryRepo
{
    public FsrDbContext DbContext { get; } = dbContext;

    public async Task<ValueResult<DirectoryModel?>> GetByIdAsync(Guid id)
    {
        return await DbContext.Directories
            .Include(field => field.Reservation)
                .ThenInclude(field => field.Files)
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

    public ValueResult<DirectoryModel?> GetById(Guid id)
    {
        return DbContext.Directories
            .Include(field => field.Reservation)
                .ThenInclude(field => field.Files)
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

    public async Task<List<DirectoryModel>> ToListAsync()
    {
        return await DbContext.Directories
            .Include(field => field.Reservation)
                .ThenInclude(field => field.Files)
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

    public List<DirectoryModel> ToList()
    {
        return [.. DbContext.Directories
            .Include(field => field.Reservation)
                .ThenInclude(field => field.Files)
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

    public async Task<ValueResult<DirectoryModel?>> GetByPathAsync(string path)
    {
        return await DbContext.Directories
            .Include(field => field.Reservation)
                .ThenInclude(field => field.Files)
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

    public ValueResult<DirectoryModel?> GetByPath(string path)
    {
        return DbContext.Directories
            .Include(field => field.Reservation)
                .ThenInclude(field => field.Files)
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
