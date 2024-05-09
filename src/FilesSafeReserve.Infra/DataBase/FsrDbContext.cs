using FilesSafeReserve.App.Models;
using FilesSafeReserve.Infra.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace FilesSafeReserve.Infra.DataBase;

/// <summary>
/// Represents the database context for managing file safe reserves.
/// </summary>
/// <remarks>
/// Initializes a new instance of the <see cref="FsrDbContext"/> class.
/// </remarks>
/// <param name="options">The DbContextOptions.</param>
/// <param name="configuration">The configuration for the application.</param>
public class FsrDbContext(DbContextOptions<FsrDbContext> options, IConfiguration configuration) : DbContext(options)
{
    private readonly DbService service = new();
    private readonly IConfiguration _configuration = configuration;

    /// <summary>
    /// Gets or sets the virtual safe models DbSet.
    /// </summary>
    public DbSet<VirtualSafeModel> VirtualSafes { get; set; }

    /// <summary>
    /// Gets or sets the virtual safe details models DbSet.
    /// </summary>
    public DbSet<VirtualSafeDetailsModel> VirtualSafeDetails { get; set; }

    /// <summary>
    /// Gets or sets the log models DbSet.
    /// </summary>
    public DbSet<LogModel> Logs { get; set; }

    /// <summary>
    /// Gets or sets the log operations models DbSet.
    /// </summary>
    public DbSet<LogOperationModel> LogOperations { get; set; }

    /// <summary>
    /// Gets or sets the reservations models DbSet.
    /// </summary>
    public DbSet<ReservationModel> Reservations { get; set; }

    /// <summary>
    /// Gets or sets the reservation files models DbSet.
    /// </summary>
    public DbSet<FileModel> Files { get; set; }

    /// <summary>
    /// Gets or sets the reservation directories models DbSet.
    /// </summary>
    public DbSet<DirectoryModel> Directories { get; set; }

    /// <summary>
    /// Gets or sets the shortcuts models DbSet.
    /// </summary>
    public DbSet<ShortcutModel> Shortcuts { get; set; }

    /// <summary>
    /// Configures the database connection using SQLite based on the provided configuration.
    /// </summary>
    /// <param name="optionsBuilder">The options builder for configuring the database.</param>
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            var appDataConfigs = _configuration.GetSection("AppData");

            var connectionDb = $"Filename={service.GetDbPath(
                    new()
                    {
                        AppName = appDataConfigs["AppName"]!,
                        DataBaseName = appDataConfigs["AppName"]!
                    })}";

            optionsBuilder.UseSqlite(connectionDb);
        }
    }

    /// <summary>
    /// Configures the model for the database.
    /// </summary>
    /// <param name="modelBuilder">The model builder used to configure the model.</param>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Додаємо початкові записи для таблиці Shortcuts
        SeedShortcutsData(modelBuilder);
    }

    /// <summary>
    /// Seeds initial data into the Shortcuts table.
    /// </summary>
    /// <param name="modelBuilder">The model builder used to configure the model.</param>
    private static void SeedShortcutsData(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ShortcutModel>().HasData(
            new ShortcutModel()
            {
                Id = Guid.NewGuid(),
                Type = ShortcutModel.Types.ReserveVirtualSafe,
                KeyCode = 82,
                KeyValue = "R",
                AltPressed = false,
                ControlPressed = false,
                MetaPressed = false,
                ShiftPressed = true,
            },
            new ShortcutModel()
            {
                Id = Guid.NewGuid(),
                Type = ShortcutModel.Types.ReserveVirtualSafes,
                KeyCode = 82,
                KeyValue = "R",
                AltPressed = false,
                ControlPressed = false,
                MetaPressed = false,
                ShiftPressed = true,
            },
            new ShortcutModel()
            {
                Id = Guid.NewGuid(),
                Type = ShortcutModel.Types.OpenVirtualSafe,
                KeyCode = 69,
                KeyValue = "E",
                AltPressed = false,
                ControlPressed = false,
                MetaPressed = false,
                ShiftPressed = true,
            }
        );
    }
}

