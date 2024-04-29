using FilesSafeReserve.Data.DataBase;
using FilesSafeReserve.Data.Entities.Results.Basic;
using FilesSafeReserve.Data.Models;
using FilesSafeReserve.Data.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FilesSafeReserve.Data.Repositories;

public class ReservationRepo(FsrDbContext dbContext) : IReservationRepo
{
    public FsrDbContext DbContext { get; } = dbContext;

    public async Task<ValueResult<ReservationModel?>> GetByIdAsync(Guid id)
    {
        return await DbContext.Reservations
            .Include(field => field.Files)
            .Include(field => field.Directories)
            .FirstOrDefaultAsync();
    }

    public ValueResult<ReservationModel?> GetById(Guid id)
    {
        return DbContext.Reservations
            .Include(field => field.Files)
            .Include(field => field.Directories)
            .FirstOrDefault();
    }

    public async Task<List<ReservationModel>> ToListAsync()
    {
        return await DbContext.Reservations
            .Include(field => field.Files)
            .Include(field => field.Directories)
            .ToListAsync();
    }

    public List<ReservationModel> ToList()
    {
        return [.. DbContext.Reservations
            .Include(field => field.Files)
            .Include(field => field.Directories)];
    }
}
