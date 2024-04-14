using FilesSafeReserve.Data.Entities.Results.Basic;
using FilesSafeReserve.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FilesSafeReserve.Data.Interfaces.Repositories;

public interface IDeleteByIdRepoBase<DbContextType, RepoType, IdType>
    where DbContextType : DbContext
    where RepoType : ModelBase<IdType>
{
    public DbContextType DbContext { get; }

    public async Task<ResultEntity> DeleteByIdAsync(IdType id)
    {
        var foundModel = await DbContext.Set<RepoType>().FindAsync(id);

        if (foundModel is null) return false;

        DbContext.Set<RepoType>().Remove(foundModel);
        await DbContext.SaveChangesAsync();
        return true;
    }

    public ResultEntity DeleteById(IdType id)
    {
        var foundModel = DbContext.Set<RepoType>().Find(id);

        if (foundModel is null) return false;

        DbContext.Set<RepoType>().Remove(foundModel);
        DbContext.SaveChanges();
        return true;
    }
}
