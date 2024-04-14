using FilesSafeReserve.Data.Entities.Results.Basic;
using FilesSafeReserve.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FilesSafeReserve.Data.Interfaces.Repositories;

/// <summary>
/// Represents a generic repository getter interface by identifier.
/// </summary>
/// <typeparam name="DbContextType">The type of the database context.</typeparam>
/// <typeparam name="RepoType">The type of the repository.</typeparam>
/// <typeparam name="IdType">The type of the identifier.</typeparam>
public interface IRepoGetterById<DbContextType, RepoType, IdType> where DbContextType : DbContext where RepoType : ModelBase<IdType>
{
    /// <summary>
    /// Gets the database context associated with the repository.
    /// </summary>
    public DbContextType DbContext { get; }

    /// <summary>
    /// Asynchronously retrieves a model from the repository by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the model to retrieve.</param>
    /// <returns>A task representing the asynchronous operation, containing the retrieved model.</returns>
    public async Task<ValueResult<RepoType?>> GetByIdAsync(IdType id)
        => await DbContext.Set<RepoType>().FindAsync(id);

    /// <summary>
    /// Retrieves a model from the repository by its identifier.
    /// </summary>
    /// <param name="id">The identifier of the model to retrieve.</param>
    /// <returns>A value result containing the retrieved model.</returns>
    public ValueResult<RepoType?> GetById(IdType id)
        => DbContext.Set<RepoType>().Find(id);
}
