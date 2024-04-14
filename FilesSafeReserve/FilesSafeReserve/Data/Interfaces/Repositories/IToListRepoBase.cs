using FilesSafeReserve.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FilesSafeReserve.Data.Interfaces.Repositories;

public interface IToListRepoBase<DbContextType, RepoType, IdType> 
    where DbContextType : DbContext 
    where RepoType : ModelBase<IdType>
{
    public DbContextType DbContext { get; }

    public async Task<List<RepoType>> ToListAsync()
        => await DbContext.Set<RepoType>().ToListAsync();

    public List<RepoType> ToList()
        => DbContext.Set<RepoType>().ToList();
}
