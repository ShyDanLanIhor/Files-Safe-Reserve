using FilesSafeReserve.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FilesSafeReserve.Data.Interfaces.Repositories;

public interface IUpdateRepoBase<DbContextType, RepoType, IdType> 
    where DbContextType : DbContext 
    where RepoType : ModelBase<IdType>
{
    public DbContextType DbContext { get; }

    public async Task UpdateAsync(RepoType model)
    {
        DbContext.Entry(model).State = EntityState.Modified;
        await DbContext.SaveChangesAsync();
    }

    public void Update(RepoType model)
    {
        DbContext.Entry(model).State = EntityState.Modified;
        DbContext.SaveChanges();
    }
}
