using FilesSafeReserve.Infra.DataBase;
using FilesSafeReserve.Infra.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;
using FilesSafeReserve.App.Entities.Results.Basic;
using FilesSafeReserve.App.Models;

namespace FilesSafeReserve.Infra.Repositories;

/// <summary>
/// Represents a repository for logs.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="LogRepo"/> class with the specified database context.
/// </remarks>
/// <param name="dbContext">The database context.</param>
public class LogRepo(FsrDbContext dbContext) : ILogRepo
{
    /// <summary>
    /// Gets the database context associated with the repository.
    /// </summary>
    public FsrDbContext DbContext { get; } = dbContext;

    public async Task<ValueResult<LogModel?>> GetByIdAsync(Guid id)
    {
        return await DbContext.Logs
            .Include(field => field.Operations)
            .FirstOrDefaultAsync();
    }

    public ValueResult<LogModel?> GetById(Guid id)
    {
        return DbContext.Logs
            .Include(field => field.Operations)
            .FirstOrDefault();
    }

    public async Task<List<LogModel>> ToListAsync()
    {
        return await DbContext.Logs
            .Include(field => field.Operations)
            .ToListAsync();
    }

    public List<LogModel> ToList()
    {
        return DbContext.Logs
            .Include(field => field.Operations)
            .ToList();
    }
}
