using FilesSafeReserve.App.Models;
using FilesSafeReserve.Infra.DataBase;
using FilesSafeReserve.Infra.Repositories.IRepositories;
using FilesSafeReserve.Infra.Repositories;
using FilesSafeReserve.Infra.Tests.Factories;
using FluentAssertions;

namespace FilesSafeReserve.Infra.Tests.Repositories;

/// <summary>
/// Tests for ShortcutRepo class.
/// </summary>
public class ShortcutRepoTests
{
    /// <summary>
    /// Asynchronously retrieves a new instance of the FsrDbContext.
    /// </summary>
    /// <returns>The asynchronously retrieved FsrDbContext instance.</returns>
    private static async Task<FsrDbContext> GetDbContextAsync()
    {
        var dbContext = TestsFsrDbContextFactory.Create();

        // Adding predefined virtual safe models
        dbContext.Shortcuts.AddRange(
            new()
            {
                Id = Guid.NewGuid(),
                Type = ShortcutModel.Types.ReserveVirtualSafe,
                KeyCode = 83,
                KeyValue = "S",
                AltPressed = true,
                ControlPressed = false,
                MetaPressed = false,
                ShiftPressed = true,
            },
            new()
            {
                Id = Guid.NewGuid(),
                Type = ShortcutModel.Types.ReserveVirtualSafes,
                KeyCode = 83,
                KeyValue = "S",
                AltPressed = true,
                ControlPressed = false,
                MetaPressed = false,
                ShiftPressed = true,
            },
            new()
            {
                Id = Guid.NewGuid(),
                Type = ShortcutModel.Types.OpenVirtualSafe,
                KeyCode = 69,
                KeyValue = "E",
                AltPressed = true,
                ControlPressed = false,
                MetaPressed = false,
                ShiftPressed = true,
            }
        );

        await dbContext.SaveChangesAsync();

        return dbContext;
    }

    /// <summary>
    /// Synchronously retrieves a new instance of the FsrDbContext.
    /// </summary>
    /// <returns>The synchronously retrieved FsrDbContext instance.</returns>
    private static FsrDbContext GetDbContext()
    {
        var dbContext = TestsFsrDbContextFactory.Create();

        // Adding predefined virtual safe models
        dbContext.Shortcuts.AddRange(
            new()
            {
                Id = Guid.NewGuid(),
                Type = ShortcutModel.Types.ReserveVirtualSafe,
                KeyCode = 83,
                KeyValue = "S",
                AltPressed = true,
                ControlPressed = false,
                MetaPressed = false,
                ShiftPressed = true,
            },
            new()
            {
                Id = Guid.NewGuid(),
                Type = ShortcutModel.Types.ReserveVirtualSafes,
                KeyCode = 83,
                KeyValue = "S",
                AltPressed = true,
                ControlPressed = false,
                MetaPressed = false,
                ShiftPressed = true,
            },
            new()
            {
                Id = Guid.NewGuid(),
                Type = ShortcutModel.Types.OpenVirtualSafe,
                KeyCode = 69,
                KeyValue = "E",
                AltPressed = true,
                ControlPressed = false,
                MetaPressed = false,
                ShiftPressed = true,
            }
        );

        dbContext.SaveChanges();

        return dbContext;
    }

    /// <summary>
    /// Tests the asynchronous method ToListAsync to ensure it returns a list of ShortcutModel objects.
    /// </summary>
    [Fact]
    public async Task ToListAsync_ReturnsListOfShortcutModels()
    {
        // Arrange
        IShortcutRepo repo = new ShortcutRepo(await GetDbContextAsync());

        // Act
        var models = await repo.ToListAsync();

        // Assert
        models.Should().NotBeNull();
        models.Should().BeOfType<List<ShortcutModel>>();
    }

    /// <summary>
    /// Tests the asynchronous method GetByIdAsync to ensure it returns a ShortcutModel object.
    /// </summary>
    [Fact]
    public async Task GetByIdAsync_ReturnsShortcutModel()
    {
        // Arrange
        IShortcutRepo repo = new ShortcutRepo(await GetDbContextAsync());
        var models = await repo.ToListAsync();

        // Act
        var modelGuid = await repo.GetByIdAsync(models.First().Id);

        // Assert
        modelGuid.IsSucceeded.Should().BeTrue();
        modelGuid.Value.Should().Be(models.First());
    }

    /// <summary>
    /// Tests the asynchronous method UpdateAsync to ensure it updates a ShortcutModel object.
    /// </summary>
    [Fact]
    public async Task UpdateAsync_UpdatesShortcutModel()
    {
        // Arrange
        IShortcutRepo repo = new ShortcutRepo(await GetDbContextAsync());
        var models = await repo.ToListAsync();

        var modelToChange = models.First();
        modelToChange.KeyCode = 10;
        modelToChange.KeyValue = "Changed";


        // Act
        await repo.UpdateAsync(modelToChange);

        // Assert
        var changedModel = models.First();

        changedModel.Should().Be(modelToChange);
    }

    /// <summary>
    /// Tests the synchronous method ToList to ensure it returns a list of ShortcutModel objects.
    /// </summary>
    [Fact]
    public void ToList_ReturnsListOfShortcutModels()
    {
        // Arrange
        IShortcutRepo repo = new ShortcutRepo(GetDbContext());

        // Act
        var models = repo.ToList();

        // Assert
        models.Should().NotBeNull();
        models.Should().BeOfType<List<ShortcutModel>>();
    }

    /// <summary>
    /// Tests the synchronous method GetById to ensure it returns a ShortcutModel object.
    /// </summary>
    [Fact]
    public void GetById_ReturnsShortcutModel()
    {
        // Arrange
        IShortcutRepo repo = new ShortcutRepo(GetDbContext());
        var models = repo.ToList();

        // Act
        var modelGuid = repo.GetById(models.First().Id);

        // Assert
        modelGuid.IsSucceeded.Should().BeTrue();
        modelGuid.Value.Should().Be(models.First());
    }

    /// <summary>
    /// Tests the synchronous method Update to ensure it updates a ShortcutModel object.
    /// </summary>
    [Fact]
    public void Update_UpdatesShortcutModel()
    {
        // Arrange
        IShortcutRepo repo = new ShortcutRepo(GetDbContext());
        var models = repo.ToList();

        var modelToChange = models.First();
        modelToChange.KeyCode = 10;
        modelToChange.KeyValue = "Changed";

        // Act
        repo.Update(modelToChange);

        // Assert
        var changedModel = models.First();

        changedModel.Should().Be(modelToChange);
    }
}
