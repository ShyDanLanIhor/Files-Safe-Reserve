using FilesSafeReserve.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace FilesSafeReserve.Data.Interfaces.Repositories;

/// <summary>
/// Represents a generic repository adder interface.
/// </summary>
/// <typeparam name="DbContextType">The type of the database context.</typeparam>
/// <typeparam name="RepoType">The type of the repository.</typeparam>
/// <typeparam name="IdType">The type of the identifier.</typeparam>
public interface IRepoAdder<DbContextType, RepoType, IdType> where DbContextType : DbContext where RepoType : ModelBase<IdType>
{
    /// <summary>
    /// Gets the database context associated with the repository.
    /// </summary>
    public DbContextType DbContext { get; }

    /// <summary>
    /// Asynchronously adds the specified model to the repository.
    /// </summary>
    /// <param name="model">The model to be added.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task AddAsync(RepoType model)
    {
        DbContext.Set<RepoType>().Add(model);
        await DbContext.SaveChangesAsync();
    }

    /// <summary>
    /// Adds the specified model to the repository.
    /// </summary>
    /// <param name="model">The model to be added.</param>
    public void Add(RepoType model)
    {
        DbContext.Set<RepoType>().Add(model);
        DbContext.SaveChanges();
    }
}
