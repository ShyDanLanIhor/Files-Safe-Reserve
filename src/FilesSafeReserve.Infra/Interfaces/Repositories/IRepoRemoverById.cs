using FilesSafeReserve.App.Entities.Results.Basic;
using FilesSafeReserve.App.Interfaces.Models;
using Microsoft.EntityFrameworkCore;

namespace FilesSafeReserve.Infra.Interfaces.Repositories;

/// <summary>
/// Represents a generic repository remover interface by identifier.
/// </summary>
/// <typeparam name="DbContextType">The type of the database context.</typeparam>
/// <typeparam name="RepoType">The type of the repository.</typeparam>
/// <typeparam name="IdType">The type of the identifier.</typeparam>
public interface IRepoRemoverById<DbContextType, RepoType, IdType>
    where DbContextType : DbContext
    where RepoType : class, IModelBase<IdType>
{
    /// <summary>
    /// Gets the database context associated with the repository.
    /// </summary>
    public DbContextType DbContext { get; }

    /// <summary>
    /// Asynchronously removes a model from the repository by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the model to be removed.</param>
    /// <returns>A task representing the asynchronous operation, indicating whether the removal was successful.</returns>
    public async Task<ResultEntity> RemoveByIdAsync(IdType id)
    {
        var foundModel = await DbContext.Set<RepoType>().FindAsync(id);

        if (foundModel is null) return false;

        DbContext.Set<RepoType>().Remove(foundModel);
        await DbContext.SaveChangesAsync();
        return true;
    }

    /// <summary>
    /// Removes a model from the repository by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the model to be removed.</param>
    /// <returns>A value indicating whether the removal was successful.</returns>
    public ResultEntity RemoveById(IdType id)
    {
        var foundModel = DbContext.Set<RepoType>().Find(id);

        if (foundModel is null) return false;

        DbContext.Set<RepoType>().Remove(foundModel);
        DbContext.SaveChanges();
        return true;
    }
}
