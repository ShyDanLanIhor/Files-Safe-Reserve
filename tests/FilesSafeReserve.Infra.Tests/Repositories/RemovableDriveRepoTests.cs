using FilesSafeReserve.App.Models;
using FilesSafeReserve.Infra.DataBase;
using FilesSafeReserve.Infra.Repositories.IRepositories;
using FilesSafeReserve.Infra.Repositories;
using FilesSafeReserve.Infra.Tests.Factories;
using FluentAssertions;

namespace FilesSafeReserve.Infra.Tests.Repositories;

/// <summary>
/// Tests for RemovableDriveRepo class.
/// </summary>
public class RemovableDriveRepoTests
{
    /// <summary>
    /// Asynchronously retrieves a new instance of the FsrDbContext.
    /// </summary>
    /// <returns>The asynchronously retrieved FsrDbContext instance.</returns>
    private static async Task<FsrDbContext> GetDbContextAsync()
    {
        var dbContext = TestsFsrDbContextFactory.Create();

        // Adding predefined virtual safe models
        dbContext.VirtualSafes.AddRange(TestsVirtualSafeFactory.CreateRandomList());

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
        dbContext.VirtualSafes.AddRange(TestsVirtualSafeFactory.CreateRandomList());

        dbContext.SaveChanges();

        return dbContext;
    }

    /// <summary>
    /// Tests the asynchronous method ToListAsync to ensure it returns a list of RemovableDriveModel objects.
    /// </summary>
    [Fact]
    public async Task ToListAsync_ReturnsListOfRemovableDriveModels()
    {
        // Arrange
        IRemovableDriveRepo repo = new RemovableDriveRepo(await GetDbContextAsync());

        // Act
        var models = await repo.ToListAsync();

        // Assert
        models.Should().NotBeNull();
        models.Should().BeOfType<List<RemovableDriveModel>>();
    }

    /// <summary>
    /// Tests the asynchronous method GetByIdAsync to ensure it returns a RemovableDriveModel object.
    /// </summary>
    [Fact]
    public async Task GetByIdAsync_ReturnsRemovableDriveModel()
    {
        // Arrange
        IRemovableDriveRepo repo = new RemovableDriveRepo(await GetDbContextAsync());
        var models = await repo.ToListAsync();

        // Act
        var modelGuid = await repo.GetByIdAsync(models.First().Id);

        // Assert
        modelGuid.IsSucceeded.Should().BeTrue();
        modelGuid.Value.Should().Be(models.First());
    }

    /// <summary>
    /// Tests the asynchronous method UpdateAsync to ensure it updates a RemovableDriveModel object.
    /// </summary>
    [Fact]
    public async Task UpdateAsync_UpdatesRemovableDriveModel()
    {
        // Arrange
        IRemovableDriveRepo repo = new RemovableDriveRepo(await GetDbContextAsync());
        var models = await repo.ToListAsync();

        var modelToChange = models.First();
        modelToChange.Name = @"Changed";
        modelToChange.VolumeLabel = @"Changed";

        // Act
        await repo.UpdateAsync(modelToChange);

        // Assert
        var changedModel = models.First();

        changedModel.Should().Be(modelToChange);
    }

    /// <summary>
    /// Tests the asynchronous method AddAsync to ensure it adds a RemovableDriveModel object.
    /// </summary>
    [Fact]
    public async Task AddAsync_AddsRemovableDriveModel()
    {
        // Arrange
        IRemovableDriveRepo repo = new RemovableDriveRepo(await GetDbContextAsync());
        RemovableDriveModel modelToAdd = new()
        {
            Name = @"Changed",
            VolumeLabel = @"Changed"
        };

        // Act
        await repo.AddAsync(modelToAdd);

        // Assert
        var addedModel = (await repo.ToListAsync()).Last();

        addedModel.Should().Be(modelToAdd);
    }

    /// <summary>
    /// Tests the asynchronous method RemoveByIdAsync to ensure it removes a RemovableDriveModel object by its Id.
    /// </summary>
    [Fact]
    public async Task RemoveByIdAsync_RemovesRemovableDriveModel()
    {
        // Arrange
        IRemovableDriveRepo repo = new RemovableDriveRepo(await GetDbContextAsync());
        var firstModelIdToRemove = (await repo.ToListAsync()).First().Id;

        // Act
        var guidRemoveResult = await repo.RemoveByIdAsync(firstModelIdToRemove);

        // Assert
        guidRemoveResult.IsSucceeded.Should().BeTrue();
    }

    /// <summary>
    /// Tests the asynchronous method RemoveAsync to ensure it removes a RemovableDriveModel object.
    /// </summary>
    [Fact]
    public async Task RemoveAsync_RemovesRemovableDriveModel()
    {
        // Arrange
        IRemovableDriveRepo repo = new RemovableDriveRepo(await GetDbContextAsync());
        var modelToRemove = (await repo.ToListAsync()).First();

        // Act
        var result = await repo.RemoveAsync(modelToRemove);

        // Assert
        result.IsSucceeded.Should().BeTrue();
    }

    /// <summary>
    /// Tests the synchronous method ToList to ensure it returns a list of RemovableDriveModel objects.
    /// </summary>
    [Fact]
    public void ToList_ReturnsListOfRemovableDriveModels()
    {
        // Arrange
        IRemovableDriveRepo repo = new RemovableDriveRepo(GetDbContext());

        // Act
        var models = repo.ToList();

        // Assert
        models.Should().NotBeNull();
        models.Should().BeOfType<List<RemovableDriveModel>>();
    }

    /// <summary>
    /// Tests the synchronous method GetById to ensure it returns a RemovableDriveModel object.
    /// </summary>
    [Fact]
    public void GetById_ReturnsRemovableDriveModel()
    {
        // Arrange
        IRemovableDriveRepo repo = new RemovableDriveRepo(GetDbContext());
        var models = repo.ToList();

        // Act
        var modelGuid = repo.GetById(models.First().Id);

        // Assert
        modelGuid.IsSucceeded.Should().BeTrue();
        modelGuid.Value.Should().Be(models.First());
    }

    /// <summary>
    /// Tests the synchronous method Update to ensure it updates a RemovableDriveModel object.
    /// </summary>
    [Fact]
    public void Update_UpdatesRemovableDriveModel()
    {
        // Arrange
        IRemovableDriveRepo repo = new RemovableDriveRepo(GetDbContext());
        var models = repo.ToList();

        var modelToChange = models.First();
        modelToChange.Name = @"Changed";
        modelToChange.VolumeLabel = @"Changed";

        // Act
        repo.Update(modelToChange);

        // Assert
        var changedModel = models.First();

        changedModel.Should().Be(modelToChange);
    }

    /// <summary>
    /// Tests the synchronous method Add to ensure it adds a RemovableDriveModel object.
    /// </summary>
    [Fact]
    public void Add_AddsRemovableDriveModel()
    {
        // Arrange
        IRemovableDriveRepo repo = new RemovableDriveRepo(GetDbContext());
        RemovableDriveModel modelToAdd = new()
        {
            Name = @"Changed",
            VolumeLabel = @"Changed"
        };

        // Act
        repo.Add(modelToAdd);

        // Assert
        var addedModel = repo.ToList().Last();

        addedModel.Should().Be(modelToAdd);
    }

    /// <summary>
    /// Tests the synchronous method RemoveById to ensure it removes a RemovableDriveModel object by its Id.
    /// </summary>
    [Fact]
    public void RemoveById_RemovesRemovableDriveModel()
    {
        // Arrange
        IRemovableDriveRepo repo = new RemovableDriveRepo(GetDbContext());
        var firstModelIdToRemove = repo.ToList().First().Id;

        // Act
        var guidRemoveResult = repo.RemoveById(firstModelIdToRemove);

        // Assert
        guidRemoveResult.IsSucceeded.Should().BeTrue();
    }

    /// <summary>
    /// Tests the synchronous method Remove to ensure it removes a RemovableDriveModel object.
    /// </summary>
    [Fact]
    public void Remove_RemovesRemovableDriveModel()
    {
        // Arrange
        IRemovableDriveRepo repo = new RemovableDriveRepo(GetDbContext());
        var modelToRemove = repo.ToList().First();

        // Act
        var result = repo.Remove(modelToRemove);

        // Assert
        result.IsSucceeded.Should().BeTrue();
    }
}
