using FilesSafeReserve.Data.Interfaces.Models;
using FilesSafeReserve.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FilesSafeReserve.Data.Interfaces.Repositories;

/// <summary>
/// Represents a generic repository to-list interface.
/// </summary>
/// <typeparam name="DbContextType">The type of the database context.</typeparam>
/// <typeparam name="RepoType">The type of the repository.</typeparam>
/// <typeparam name="IdType">The type of the identifier.</typeparam>
public interface IRepoToList<DbContextType, RepoType, IdType> 
    where DbContextType : DbContext 
    where RepoType : class, IModelBase<IdType>
{
    /// <summary>
    /// Gets the database context associated with the repository.
    /// </summary>
    public DbContextType DbContext { get; }

    /// <summary>
    /// Asynchronously retrieves all models from the repository.
    /// </summary>
    /// <returns>A task representing the asynchronous operation, containing a list of retrieved models.</returns>
    public async Task<List<RepoType>> ToListAsync()
        => await DbContext.Set<RepoType>().ToListAsync();

    /// <summary>
    /// Retrieves all models from the repository.
    /// </summary>
    /// <returns>A list containing all retrieved models.</returns>
    public List<RepoType> ToList()
        => [.. DbContext.Set<RepoType>()];
}
