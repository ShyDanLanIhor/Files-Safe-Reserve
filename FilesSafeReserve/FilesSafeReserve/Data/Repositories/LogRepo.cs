using FilesSafeReserve.Data.DataBase;
using FilesSafeReserve.Data.Repositories.IRepositories;

namespace FilesSafeReserve.Data.Repositories;

/// <summary>
/// Represents a repository for logs.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="LogRepo"/> class with the specified database context.
/// </remarks>
/// <param name="dbContext">The database context.</param>
public class LogRepo(FsrDbContext dbContext) : ILogRepo
{
    /// <summary>
    /// Gets the database context associated with the repository.
    /// </summary>
    public FsrDbContext DbContext { get; } = dbContext;
}
