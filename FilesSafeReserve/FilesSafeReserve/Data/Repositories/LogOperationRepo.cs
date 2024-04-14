using FilesSafeReserve.Data.DataBase;
using FilesSafeReserve.Data.Repositories.IRepositories;

namespace FilesSafeReserve.Data.Repositories;

public class LogOperationRepo : ILogOperationRepo
{
    private FsrDbContext _dbContext;

    public FsrDbContext DbContext => _dbContext;

    public LogOperationRepo(FsrDbContext dbContext)
    {
        _dbContext = dbContext;
    }
}
