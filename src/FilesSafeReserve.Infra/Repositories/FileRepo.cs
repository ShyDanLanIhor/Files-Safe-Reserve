using FilesSafeReserve.Infra.DataBase;
using FilesSafeReserve.Infra.Repositories.IRepositories;

namespace FilesSafeReserve.Infra.Repositories;

public class FileRepo(FsrDbContext dbContext) : IFileRepo
{
    public FsrDbContext DbContext { get; } = dbContext;
}
