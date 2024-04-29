using FilesSafeReserve.Data.DataBase;
using FilesSafeReserve.Data.Models;
using FilesSafeReserve.Data.Repositories;
using FilesSafeReserve.Data.Repositories.IRepositories;
using FilesSafeReserve.Tests.Factories;
using FluentAssertions;

namespace FilesSafeReserve.Tests.Repositories;

/// <summary>
/// Tests for DirectoryRepo class.
/// </summary>
public class DirectoryRepoTests
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
    /// Tests the asynchronous method ToListAsync to ensure it returns a list of DirectoryModel objects.
    /// </summary>
    [Fact]
    public async void ToListAsync_ReturnsListOfDirectoryModels()
    {
        // Arrange
        IDirectoryRepo repo = new DirectoryRepo(await GetDbContextAsync());

        // Act
        var models = await repo.ToListAsync();

        // Assert
        models.Should().NotBeNull();
        models.Should().BeOfType<List<DirectoryModel>>();
    }

    /// <summary>
    /// Tests the asynchronous method GetByIdAsync to ensure it returns a DirectoryModel object.
    /// </summary>
    [Fact]
    public async void GetByIdAsync_ReturnsDirectoryModel()
    {
        // Arrange
        IDirectoryRepo repo = new DirectoryRepo(await GetDbContextAsync());
        var models = await repo.ToListAsync();

        // Act
        var modelGuid = await repo.GetByIdAsync(models.First().Id);

        // Assert
        modelGuid.IsSucceeded.Should().BeTrue();
        modelGuid.Value.Should().Be(models.First());
    }

    /// <summary>
    /// Tests the asynchronous method UpdateAsync to ensure it updates a DirectoryModel object.
    /// </summary>
    [Fact]
    public async void UpdateAsync_UpdatesDirectoryModel()
    {
        // Arrange
        IDirectoryRepo repo = new DirectoryRepo(await GetDbContextAsync());
        var models = await repo.ToListAsync();

        var modelToChange = models.First();
        modelToChange.Path = @"C:\Users\username\folder";

        // Act
        await repo.UpdateAsync(modelToChange);

        // Assert
        var changedModel = models.First();

        changedModel.Should().Be(modelToChange);
    }

    /// <summary>
    /// Tests the asynchronous method AddAsync to ensure it adds a DirectoryModel object.
    /// </summary>
    [Fact]
    public async void AddAsync_AddsDirectoryModel()
    {
        // Arrange
        IDirectoryRepo repo = new DirectoryRepo(await GetDbContextAsync());
        DirectoryModel modelToAdd = new()
        {
            Path = @"C:\Users\username\folder"
        };

        // Act
        await repo.AddAsync(modelToAdd);

        // Assert
        var addedModel = (await repo.ToListAsync()).Last();

        addedModel.Should().Be(modelToAdd);
    }

    /// <summary>
    /// Tests the asynchronous method RemoveByIdAsync to ensure it removes a DirectoryModel object by its Id.
    /// </summary>
    [Fact]
    public async void RemoveByIdAsync_RemovesDirectoryModel()
    {
        // Arrange
        IDirectoryRepo repo = new DirectoryRepo(await GetDbContextAsync());
        var firstModelIdToRemove = (await repo.ToListAsync()).First().Id;

        // Act
        var guidRemoveResult = await repo.RemoveByIdAsync(firstModelIdToRemove);

        // Assert
        guidRemoveResult.IsSucceeded.Should().BeTrue();
    }

    /// <summary>
    /// Tests the asynchronous method RemoveAsync to ensure it removes a DirectoryModel object.
    /// </summary>
    [Fact]
    public async void RemoveAsync_RemovesDirectoryModel()
    {
        // Arrange
        IDirectoryRepo repo = new DirectoryRepo(await GetDbContextAsync());
        var modelToRemove = (await repo.ToListAsync()).First();

        // Act
        var result = await repo.RemoveAsync(modelToRemove);

        // Assert
        result.IsSucceeded.Should().BeTrue();
    }

    /// <summary>
    /// Tests the synchronous method ToList to ensure it returns a list of DirectoryModel objects.
    /// </summary>
    [Fact]
    public void ToList_ReturnsListOfDirectoryModels()
    {
        // Arrange
        IDirectoryRepo repo = new DirectoryRepo(GetDbContext());

        // Act
        var models = repo.ToList();

        // Assert
        models.Should().NotBeNull();
        models.Should().BeOfType<List<DirectoryModel>>();
    }

    /// <summary>
    /// Tests the synchronous method GetById to ensure it returns a DirectoryModel object.
    /// </summary>
    [Fact]
    public void GetById_ReturnsDirectoryModel()
    {
        // Arrange
        IDirectoryRepo repo = new DirectoryRepo(GetDbContext());
        var models = repo.ToList();

        // Act
        var modelGuid = repo.GetById(models.First().Id);

        // Assert
        modelGuid.IsSucceeded.Should().BeTrue();
        modelGuid.Value.Should().Be(models.First());
    }

    /// <summary>
    /// Tests the synchronous method Update to ensure it updates a DirectoryModel object.
    /// </summary>
    [Fact]
    public void Update_UpdatesDirectoryModel()
    {
        // Arrange
        IDirectoryRepo repo = new DirectoryRepo(GetDbContext());
        var models = repo.ToList();

        var modelToChange = models.First();
        modelToChange.Path = @"C:\Users\username\folder";

        // Act
        repo.Update(modelToChange);

        // Assert
        var changedModel = models.First();

        changedModel.Should().Be(modelToChange);
    }

    /// <summary>
    /// Tests the synchronous method Add to ensure it adds a DirectoryModel object.
    /// </summary>
    [Fact]
    public void Add_AddsDirectoryModel()
    {
        // Arrange
        IDirectoryRepo repo = new DirectoryRepo(GetDbContext());
        DirectoryModel modelToAdd = new()
        {
            Path = @"C:\Users\username\folder"
        };

        // Act
        repo.Add(modelToAdd);

        // Assert
        var addedModel = repo.ToList().Last();

        addedModel.Should().Be(modelToAdd);
    }

    /// <summary>
    /// Tests the synchronous method RemoveById to ensure it removes a DirectoryModel object by its Id.
    /// </summary>
    [Fact]
    public void RemoveById_RemovesDirectoryModel()
    {
        // Arrange
        IDirectoryRepo repo = new DirectoryRepo(GetDbContext());
        var firstModelIdToRemove = repo.ToList().First().Id;

        // Act
        var guidRemoveResult = repo.RemoveById(firstModelIdToRemove);

        // Assert
        guidRemoveResult.IsSucceeded.Should().BeTrue();
    }

    /// <summary>
    /// Tests the synchronous method Remove to ensure it removes a DirectoryModel object.
    /// </summary>
    [Fact]
    public void Remove_RemovesDirectoryModel()
    {
        // Arrange
        IDirectoryRepo repo = new DirectoryRepo(GetDbContext());
        var modelToRemove = repo.ToList().First();

        // Act
        var result = repo.Remove(modelToRemove);

        // Assert
        result.IsSucceeded.Should().BeTrue();
    }
}
