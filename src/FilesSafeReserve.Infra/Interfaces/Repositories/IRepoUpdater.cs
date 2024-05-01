using FilesSafeReserve.App.Entities.Results.Basic;
using FilesSafeReserve.App.Interfaces.Models;
using Microsoft.EntityFrameworkCore;

namespace FilesSafeReserve.Infra.Interfaces.Repositories;

/// <summary>
/// Represents a generic repository updater interface.
/// </summary>
/// <typeparam name="DbContextType">The type of the database context.</typeparam>
/// <typeparam name="RepoType">The type of the repository.</typeparam>
/// <typeparam name="IdType">The type of the identifier.</typeparam>
public interface IRepoUpdater<DbContextType, RepoType, IdType>
    where DbContextType : DbContext
    where RepoType : class, IModelBase<IdType>
{
    /// <summary>
    /// Gets the database context associated with the repository.
    /// </summary>
    public DbContextType DbContext { get; }

    /// <summary>
    /// Asynchronously updates the specified model in the repository.
    /// </summary>
    /// <param name="model">The model to be updated.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task UpdateAsync(RepoType model)
    {
        DbContext.Entry(model).State = EntityState.Modified;
        await DbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Updates the specified model in the repository.
    /// </summary>
    /// <param name="model">The model to be updated.</param>
    public void Update(RepoType model)
    {
        DbContext.Entry(model).State = EntityState.Modified;
        DbContext.SaveChanges();
    }
}

