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
            .FirstOrDefaultAsync(el => el.Id == id);
    }

    public ValueResult<VirtualSafeDetailsModel?> GetById(Guid id)
    {
        return DbContext.VirtualSafeDetails
            .Include(field => field.Logs)
            .FirstOrDefault(el => el.Id == id);
    }

    public async Task<List<VirtualSafeDetailsModel>> ToListAsync()
    {
        return await DbContext.VirtualSafeDetails
            .Include(field => field.Logs)
            .ToListAsync();
    }

    public List<VirtualSafeDetailsModel> ToList()
    {
        return DbContext.VirtualSafeDetails
            .Include(field => field.Logs)
            .ToList();
    }
}
