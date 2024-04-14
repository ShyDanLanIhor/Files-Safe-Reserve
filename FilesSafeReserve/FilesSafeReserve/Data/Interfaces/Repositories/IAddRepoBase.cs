using FilesSafeReserve.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FilesSafeReserve.Data.Interfaces.Repositories;

public interface IAddRepoBase<DbContextType, RepoType, IdType> 
    where DbContextType : DbContext 
    where RepoType : ModelBase<IdType>
{
    public DbContextType DbContext { get; }

    public async Task AddAsync(RepoType model)
    {
        DbContext.Set<RepoType>().Add(model);
        await DbContext.SaveChangesAsync();
    }

    public void Add(RepoType model)
    {
        DbContext.Set<RepoType>().Add(model);
        DbContext.SaveChanges();
    }
}
