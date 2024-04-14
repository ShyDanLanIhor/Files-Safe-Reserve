using FilesSafeReserve.Data.Entities.Results.Basic;
using FilesSafeReserve.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FilesSafeReserve.Data.Interfaces.Repositories;

public interface IGetByIdRepoBase<DbContextType, RepoType, IdType> 
    where DbContextType : DbContext 
    where RepoType : ModelBase<IdType>
{
    public DbContextType DbContext { get; }

    public async Task<ValueResult<RepoType?>> GetByIdAsync(IdType id)
        => await DbContext.Set<RepoType>().FindAsync(id);

    public ValueResult<RepoType?> GetById(IdType id)
        => DbContext.Set<RepoType>().Find(id);
}
