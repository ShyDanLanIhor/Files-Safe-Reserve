using FilesSafeReserve.Data.DataBase;
using FilesSafeReserve.Data.Repositories.IRepositories;

namespace FilesSafeReserve.Data.Repositories;

public class FileRepo(FsrDbContext dbContext) : IFileRepo
{
    public FsrDbContext DbContext { get; } = dbContext;
}
