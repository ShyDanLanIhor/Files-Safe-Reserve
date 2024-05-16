using FilesSafeReserve.App.Entities.Results.Basic;
using FilesSafeReserve.App.Models;
using FilesSafeReserve.Infra.DataBase;
using FilesSafeReserve.Infra.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FilesSafeReserve.Infra.Repositories;

public class VirtualSafeDetailsRepo(FsrDbContext dbContext) : IVirtualSafeDetailsRepo
{
    public FsrDbContext DbContext { get; } = dbContext;

    public async Task<ValueResult<VirtualSafeDetailsModel?>> GetByIdAsync(Guid id)
    {
        return await DbContext.VirtualSafeDetails
            .Include(field => field.Logs)
                .ThenInclude(field => field.Operations)
            .Include(field => field.RemovableDrive)
            .Include(field => field.Safe)
                .ThenInclude(field => field.Reservation)
                    .ThenInclude(field => field.Files)
            .Include(field => field.Safe)
                .ThenInclude(field => field.Reservation)
                    .ThenInclude(field => field.Directories)
            .FirstOrDefaultAsync(el => el.Id == id);
    }

    public ValueResult<VirtualSafeDetailsModel?> GetById(Guid id)
    {
        return DbContext.VirtualSafeDetails
            .Include(field => field.Logs)
                .ThenInclude(field => field.Operations)
            .Include(field => field.RemovableDrive)
            .Include(field => field.Safe)
                .ThenInclude(field => field.Reservation)
                    .ThenInclude(field => field.Files)
            .Include(field => field.Safe)
                .ThenInclude(field => field.Reservation)
                    .ThenInclude(field => field.Directories)
            .FirstOrDefault(el => el.Id == id);
    }

    public async Task<List<VirtualSafeDetailsModel>> ToListAsync()
    {
        return await DbContext.VirtualSafeDetails
            .Include(field => field.Logs)
                .ThenInclude(field => field.Operations)
            .Include(field => field.RemovableDrive)
            .Include(field => field.Safe)
                .ThenInclude(field => field.Reservation)
                    .ThenInclude(field => field.Files)
            .Include(field => field.Safe)
                .ThenInclude(field => field.Reservation)
                    .ThenInclude(field => field.Directories)
            .ToListAsync();
    }

    public List<VirtualSafeDetailsModel> ToList()
    {
        return [.. DbContext.VirtualSafeDetails
            .Include(field => field.Logs)
                .ThenInclude(field => field.Operations)
            .Include(field => field.RemovableDrive)
            .Include(field => field.Safe)
                .ThenInclude(field => field.Reservation)
                    .ThenInclude(field => field.Files)
            .Include(field => field.Safe)
                .ThenInclude(field => field.Reservation)
                    .ThenInclude(field => field.Directories)];
    }
}
