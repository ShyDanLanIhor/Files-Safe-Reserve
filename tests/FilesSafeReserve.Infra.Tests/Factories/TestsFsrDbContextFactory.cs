using FilesSafeReserve.Infra.DataBase;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FilesSafeReserve.Infra.Tests.Factories;

/// <summary>
/// Factory class for creating instances of <see cref="FsrDbContext"/> for testing purposes.
/// </summary>
public static class TestsFsrDbContextFactory
{
    /// <summary>
    /// Creates a new instance of <see cref="FsrDbContext"/> using an in-memory database.
    /// </summary>
    /// <returns>A new instance of <see cref="FsrDbContext"/>.</returns>
    public static FsrDbContext Create()
    {
        var options = new DbContextOptionsBuilder<FsrDbContext>()
            .UseInMemoryDatabase(databaseName: Guid.NewGuid().ToString())
            .Options;

        var dbContext = new FsrDbContext(options, new ConfigurationBuilder().Build());

        dbContext.Database.EnsureCreated();

        return dbContext;
    }
}

