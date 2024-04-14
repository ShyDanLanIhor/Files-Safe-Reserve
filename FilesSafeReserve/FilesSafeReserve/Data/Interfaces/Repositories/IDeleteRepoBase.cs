using FilesSafeReserve.Data.Entities.Results.Basic;
using FilesSafeReserve.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FilesSafeReserve.Data.Interfaces.Repositories;

public interface IDeleteRepoBase<DbContextType, RepoType, IdType> 
    where DbContextType : DbContext 
    where RepoType : ModelBase<IdType>
{
    public DbContextType DbContext { get; }

    public async Task<ResultEntity> DeleteAsync(RepoType model)
    {
        var foundModel = await DbContext.Set<RepoType>().FindAsync(model.Id);

        if (foundModel is null) return false;

        DbContext.Set<RepoType>().Remove(foundModel);
        await DbContext.SaveChangesAsync();
        return true;
    }

    public ResultEntity Delete(RepoType model)
    {
        var foundModel = DbContext.Set<RepoType>().Find(model.Id);

        if (foundModel is null) return false;

        DbContext.Set<RepoType>().Remove(foundModel);
        DbContext.SaveChanges();
        return true;
    }
}
