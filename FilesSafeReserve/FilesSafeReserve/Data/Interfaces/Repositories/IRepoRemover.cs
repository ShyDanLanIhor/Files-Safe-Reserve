using FilesSafeReserve.Data.Entities.Results.Basic;
using FilesSafeReserve.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FilesSafeReserve.Data.Interfaces.Repositories;

/// <summary>
/// Represents a generic repository remover interface.
/// </summary>
/// <typeparam name="DbContextType">The type of the database context.</typeparam>
/// <typeparam name="RepoType">The type of the repository.</typeparam>
/// <typeparam name="IdType">The type of the identifier.</typeparam>
public interface IRepoRemover<DbContextType, RepoType, IdType> where DbContextType : DbContext where RepoType : ModelBase<IdType>
{
    /// <summary>
    /// Gets the database context associated with the repository.
    /// </summary>
    public DbContextType DbContext { get; }

    /// <summary>
    /// Asynchronously removes the specified model from the repository.
    /// </summary>
    /// <param name="model">The model to be removed.</param>
    /// <returns>A task representing the asynchronous operation, indicating whether the removal was successful.</returns>
    public async Task<ResultEntity> RemoveAsync(RepoType model)
    {
        var foundModel = await DbContext.Set<RepoType>().FindAsync(model.Id);

        if (foundModel is null) return false;

        DbContext.Set<RepoType>().Remove(foundModel);
        await DbContext.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Removes the specified model from the repository.
    /// </summary>
    /// <param name="model">The model to be removed.</param>
    /// <returns>A value indicating whether the removal was successful.</returns>
    public ResultEntity Remove(RepoType model)
    {
        var foundModel = DbContext.Set<RepoType>().Find(model.Id);

        if (foundModel is null) return false;

        DbContext.Set<RepoType>().Remove(foundModel);
        DbContext.SaveChanges();
        return true;
    }
}
