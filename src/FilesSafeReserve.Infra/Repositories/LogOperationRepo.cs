using FilesSafeReserve.App.Entities.Results.Basic;
using FilesSafeReserve.App.Models;
using FilesSafeReserve.Infra.DataBase;
using FilesSafeReserve.Infra.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FilesSafeReserve.Infra.Repositories;

/// <summary>
/// Represents a repository for log operations.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="LogOperationRepo"/> class with the specified database context.
/// </remarks>
/// <param name="dbContext">The database context.</param>
public class LogOperationRepo(FsrDbContext dbContext) : ILogOperationRepo
{
    /// <summary>
    /// Gets the database context associated with the repository.
    /// </summary>
    public FsrDbContext DbContext { get; } = dbContext;

    public async Task<ValueResult<LogOperationModel?>> GetByIdAsync(Guid id)
    {
        return await DbContext.LogOperations
            .Include(field => field.Log)
                .ThenInclude(field => field.VirtualSafeDetails)
                    .ThenInclude(field => field.Safe)
                        .ThenInclude(field => field.Reservation)
                            .ThenInclude(field => field.Files)
            .Include(field => field.Log)
                .ThenInclude(field => field.VirtualSafeDetails)
                    .ThenInclude(field => field.Safe)
                        .ThenInclude(field => field.Reservation)
                            .ThenInclude(field => field.Directories)
            .Include(field => field.Log)
                .ThenInclude(field => field.VirtualSafeDetails)
                    .ThenInclude(field => field.RemovableDrive)
            .FirstOrDefaultAsync(el => el.Id == id);
    }

    public ValueResult<LogOperationModel?> GetById(Guid id)
    {
        return DbContext.LogOperations
            .Include(field => field.Log)
                .ThenInclude(field => field.VirtualSafeDetails)
                    .ThenInclude(field => field.Safe)
                        .ThenInclude(field => field.Reservation)
                            .ThenInclude(field => field.Files)
            .Include(field => field.Log)
                .ThenInclude(field => field.VirtualSafeDetails)
                    .ThenInclude(field => field.Safe)
                        .ThenInclude(field => field.Reservation)
                            .ThenInclude(field => field.Directories)
            .Include(field => field.Log)
                .ThenInclude(field => field.VirtualSafeDetails)
                    .ThenInclude(field => field.RemovableDrive)
            .FirstOrDefault(el => el.Id == id);
    }

    public async Task<List<LogOperationModel>> ToListAsync()
    {
        return await DbContext.LogOperations
            .Include(field => field.Log)
                .ThenInclude(field => field.VirtualSafeDetails)
                    .ThenInclude(field => field.Safe)
                        .ThenInclude(field => field.Reservation)
                            .ThenInclude(field => field.Files)
            .Include(field => field.Log)
                .ThenInclude(field => field.VirtualSafeDetails)
                    .ThenInclude(field => field.Safe)
                        .ThenInclude(field => field.Reservation)
                            .ThenInclude(field => field.Directories)
            .Include(field => field.Log)
                .ThenInclude(field => field.VirtualSafeDetails)
                    .ThenInclude(field => field.RemovableDrive)
            .ToListAsync();
    }

    public List<LogOperationModel> ToList()
    {
        return [.. DbContext.LogOperations
            .Include(field => field.Log)
                .ThenInclude(field => field.VirtualSafeDetails)
                    .ThenInclude(field => field.Safe)
                        .ThenInclude(field => field.Reservation)
                            .ThenInclude(field => field.Files)
            .Include(field => field.Log)
                .ThenInclude(field => field.VirtualSafeDetails)
                    .ThenInclude(field => field.Safe)
                        .ThenInclude(field => field.Reservation)
                            .ThenInclude(field => field.Directories)
            .Include(field => field.Log)
                .ThenInclude(field => field.VirtualSafeDetails)
                    .ThenInclude(field => field.RemovableDrive)];
    }
}
