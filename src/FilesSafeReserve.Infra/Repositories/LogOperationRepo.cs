using FilesSafeReserve.Infra.DataBase;
using FilesSafeReserve.Infra.Repositories.IRepositories;

namespace FilesSafeReserve.Infra.Repositories;

/// <summary>
/// Represents a repository for log operations.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="LogOperationRepo"/> class with the specified database context.
/// </remarks>
/// <param name="dbContext">The database context.</param>
public class LogOperationRepo(FsrDbContext dbContext) : ILogOperationRepo
{
    /// <summary>
    /// Gets the database context associated with the repository.
    /// </summary>
    public FsrDbContext DbContext { get; } = dbContext;
}
