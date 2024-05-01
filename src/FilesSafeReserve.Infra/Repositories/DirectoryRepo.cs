using FilesSafeReserve.Infra.DataBase;
using FilesSafeReserve.Infra.Repositories.IRepositories;

namespace FilesSafeReserve.Infra.Repositories;

public class DirectoryRepo(FsrDbContext dbContext) : IDirectoryRepo
{
    public FsrDbContext DbContext { get; } = dbContext;
}
