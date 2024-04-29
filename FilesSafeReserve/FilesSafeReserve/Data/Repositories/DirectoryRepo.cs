using FilesSafeReserve.Data.DataBase;
using FilesSafeReserve.Data.Repositories.IRepositories;

namespace FilesSafeReserve.Data.Repositories;

public class DirectoryRepo(FsrDbContext dbContext) : IDirectoryRepo
{
    public FsrDbContext DbContext { get; } = dbContext;
}
