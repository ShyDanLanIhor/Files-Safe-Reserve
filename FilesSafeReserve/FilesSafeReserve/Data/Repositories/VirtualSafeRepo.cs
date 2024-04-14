using FilesSafeReserve.Data.DataBase;
using FilesSafeReserve.Data.Entities.Results.Basic;
using FilesSafeReserve.Data.Interfaces.Repositories;
using FilesSafeReserve.Data.Models;
using FilesSafeReserve.Data.Repositories.IRepositories;

namespace FilesSafeReserve.Data.Repositories;

/// <summary>
/// Represents a repository for managing virtual safes in a database context.
/// </summary>
public class VirtualSafeRepo :
    IVirtualSafeRepo
{
    private FsrDbContext _dbContext;

    public FsrDbContext DbContext => _dbContext;

    public VirtualSafeRepo(FsrDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}

