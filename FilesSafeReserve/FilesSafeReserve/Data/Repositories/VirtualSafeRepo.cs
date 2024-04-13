using FilesSafeReserve.Data.DataBase;
using FilesSafeReserve.Data.Entities.Results.Basic;
using FilesSafeReserve.Data.Models;
using FilesSafeReserve.Data.Repositories.IRepositories;
using Microsoft.EntityFrameworkCore;

namespace FilesSafeReserve.Data.Repositories;

/// <summary>
/// Represents a repository for managing virtual safes in a database context.
/// </summary>
public class VirtualSafeRepo : IVirtualSafeRepo
{
    private readonly FsrDbContext _context;

    /// <summary>
    /// Initializes a new instance of the VirtualSafeRepo class with the specified database context.
    /// </summary>
    /// <param name="context">The database context.</param>
    public VirtualSafeRepo(FsrDbContext context)
    {
        _context = context;
    }

    /// <inheritdoc/>
    public async Task<ResultEntity> Delete(VirtualSafeModel model)
    {
        var safe = await _context.VirtualSafeModels.FindAsync(model.Id);

        if (safe is null) return false;

        _context.VirtualSafeModels.Remove(safe);
        await _context.SaveChangesAsync();
        return true;
    }

    /// <inheritdoc/>
    public async Task<ResultEntity> DeleteById(Guid id)
    {
        var safe = await _context.VirtualSafeModels.FindAsync(id);

        if (safe is null) return false;

        _context.VirtualSafeModels.Remove(safe);
        await _context.SaveChangesAsync();
        return true;
    }

    /// <inheritdoc/>
    public async Task<ResultEntity> DeleteById(string id)
    {
        var safe = await _context.VirtualSafeModels.FindAsync(new Guid(id));

        if (safe is null) return false;

        _context.VirtualSafeModels.Remove(safe);
        await _context.SaveChangesAsync();
        return true;
    }

    /// <inheritdoc/>
    public async Task<List<VirtualSafeModel>> GetAll()
        => await _context.VirtualSafeModels.ToListAsync();

    /// <inheritdoc/>
    public async Task<ValueResult<VirtualSafeModel>> GetById(Guid id)
        => await _context.VirtualSafeModels.FindAsync(id);

    /// <inheritdoc/>
    public async Task<ValueResult<VirtualSafeModel>> GetById(string id)
        => await _context.VirtualSafeModels.FindAsync(new Guid(id));

    /// <inheritdoc/>
    public async Task Add(VirtualSafeModel model)
    {
        _context.VirtualSafeModels.Add(model);
        await _context.SaveChangesAsync();
    }

    /// <inheritdoc/>
    public async Task Update(VirtualSafeModel model)
    {
        _context.Entry(model).State = EntityState.Modified;
        await _context.SaveChangesAsync();
    }
}

