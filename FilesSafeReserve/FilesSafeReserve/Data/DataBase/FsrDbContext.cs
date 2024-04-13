using FilesSafeReserve.Data.Configs;
using FilesSafeReserve.Data.Models;
using FilesSafeReserve.Data.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FilesSafeReserve.Data.DataBase;

/// <summary>
/// Represents the database context for managing file safe reserves.
/// </summary>
public class FsrDbContext : DbContext
{
    private readonly DbService service = new();
    private readonly IConfiguration _configuration;

    /// <summary>
    /// Gets or sets the virtual safe models DbSet.
    /// </summary>
    public DbSet<VirtualSafeModel> VirtualSafeModels { get; set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="FilesSafeReserveDBContext"/> class.
    /// </summary>
    /// <param name="options">The DbContextOptions.</param>
    /// <param name="configuration">The configuration for the application.</param>
    public FsrDbContext(DbContextOptions<FsrDbContext> options, IConfiguration configuration)
        : base(options)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// Configures the database connection using SQLite based on the provided configuration.
    /// </summary>
    /// <param name="optionsBuilder">The options builder for configuring the database.</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var AppDataConfigs = _configuration.GetSection("AppData").Get<AppDataConfig>();

            var connectionDb = $"Filename={service.GetDbPath(
                    new()
                    {
                        AppName = AppDataConfigs.AppName,
                        DataBaseName = AppDataConfigs.AppName
                    })}";

            optionsBuilder.UseSqlite(connectionDb);
        }
    }
}

