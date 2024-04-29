﻿using FilesSafeReserve.Data.DataBase;
using FilesSafeReserve.Data.Repositories.IRepositories;
using FilesSafeReserve.Data.Entities.Results.Basic;
using FilesSafeReserve.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FilesSafeReserve.Data.Repositories;

/// <summary>
/// Represents a repository for virtual safes.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="VirtualSafeRepo"/> class with the specified database context.
/// </remarks>
/// <param name="dbContext">The database context.</param>
public class VirtualSafeRepo(FsrDbContext dbContext) : IVirtualSafeRepo
{
    /// <summary>
    /// Gets the database context associated with the repository.
    /// </summary>
    public FsrDbContext DbContext { get; } = dbContext;

    public async Task<ValueResult<VirtualSafeModel?>> GetByIdAsync(Guid id)
    {
        return await DbContext.VirtualSafes
            .Include(field => field.Details)
                .ThenInclude(field => field.Logs)
                    .ThenInclude(field => field.Operations)
            .Include(field => field.Reservation)
                .ThenInclude(field => field.Files)
            .Include(field => field.Reservation)
                .ThenInclude(field => field.Directories)
            .FirstOrDefaultAsync();
    }

    public ValueResult<VirtualSafeModel?> GetById(Guid id)
    {
        return DbContext.VirtualSafes
            .Include(field => field.Details)
                .ThenInclude(field => field.Logs)
                    .ThenInclude(field => field.Operations)
            .Include(field => field.Reservation)
                .ThenInclude(field => field.Files)
            .Include(field => field.Reservation)
                .ThenInclude(field => field.Directories)
            .FirstOrDefault();
    }

    public async Task<List<VirtualSafeModel>> ToListAsync()
    {
        return await DbContext.VirtualSafes
            .Include(field => field.Details)
                .ThenInclude(field => field.Logs)
                    .ThenInclude(field => field.Operations)
            .Include(field => field.Reservation)
                .ThenInclude(field => field.Files)
            .Include(field => field.Reservation)
                .ThenInclude(field => field.Directories)
            .ToListAsync();
    }

    public List<VirtualSafeModel> ToList()
    {
        return DbContext.VirtualSafes
            .Include(field => field.Details)
                .ThenInclude(field => field.Logs)
                    .ThenInclude(field => field.Operations)
            .Include(field => field.Reservation)
                .ThenInclude(field => field.Files)
            .Include(field => field.Reservation)
                .ThenInclude(field => field.Directories)
            .ToList();
    }
}


