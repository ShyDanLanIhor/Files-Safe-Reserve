using FilesSafeReserve.Data.DataBase;
using FilesSafeReserve.Data.Repositories.IRepositories;

namespace FilesSafeReserve.Data.Repositories;

public class LogRepo : ILogRepo
{
    private FsrDbContext _dbContext;

    public FsrDbContext DbContext => _dbContext;

    public LogRepo(FsrDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}
