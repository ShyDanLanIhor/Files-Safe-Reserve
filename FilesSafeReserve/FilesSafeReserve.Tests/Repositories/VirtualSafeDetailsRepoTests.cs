using FilesSafeReserve.Data.DataBase;
using FilesSafeReserve.Data.Models;
using FilesSafeReserve.Data.Repositories;
using FilesSafeReserve.Data.Repositories.IRepositories;
using FilesSafeReserve.Tests.Factories;
using FluentAssertions;

namespace FilesSafeReserve.Tests.Repositories;

/// <summary>
/// Tests for VirtualSafeDetailsRepo class.
/// </summary>
public class VirtualSafeDetailsRepoTests
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
    /// Tests the asynchronous method ToListAsync to ensure it returns a list of VirtualSafeDetailsModel objects.
    /// </summary>
    [Fact]
    public async void ToListAsync_ReturnsListOfVirtualSafeDetailsModels()
    {
        // Arrange
        IVirtualSafeDetailsRepo repo = new VirtualSafeDetailsRepo(await GetDbContextAsync());

        // Act
        var models = await repo.ToListAsync();

        // Assert
        models.Should().NotBeNull();
        models.Should().BeOfType<List<VirtualSafeDetailsModel>>();
    }

    /// <summary>
    /// Tests the asynchronous method GetByIdAsync to ensure it returns a VirtualSafeDetailsModel object.
    /// </summary>
    [Fact]
    public async void GetByIdAsync_ReturnsVirtualSafeDetailsModel()
    {
        // Arrange
        IVirtualSafeDetailsRepo repo = new VirtualSafeDetailsRepo(await GetDbContextAsync());
        var models = await repo.ToListAsync();

        // Act
        var modelGuid = await repo.GetByIdAsync(models.First().Id);

        // Assert
        modelGuid.IsSucceeded.Should().BeTrue();
        modelGuid.Value.Should().Be(models.First());
    }

    /// <summary>
    /// Tests the asynchronous method UpdateAsync to ensure it updates a VirtualSafeDetailsModel object.
    /// </summary>
    [Fact]
    public async void UpdateAsync_UpdatesVirtualSafeDetailsModel()
    {
        // Arrange
        IVirtualSafeDetailsRepo repo = new VirtualSafeDetailsRepo(await GetDbContextAsync());
        var models = await repo.ToListAsync();

        var modelToChange = models.First();
        modelToChange.ReservedTimestamp = DateTime.Now;

        // Act
        await repo.UpdateAsync(modelToChange);

        // Assert
        var changedModel = models.First();

        changedModel.Should().Be(modelToChange);
    }

    /// <summary>
    /// Tests the asynchronous method AddAsync to ensure it adds a VirtualSafeDetailsModel object.
    /// </summary>
    [Fact]
    public async void AddAsync_AddsVirtualSafeDetailsModel()
    {
        // Arrange
        IVirtualSafeDetailsRepo repo = new VirtualSafeDetailsRepo(await GetDbContextAsync());
        VirtualSafeDetailsModel modelToAdd = new();

        // Act
        await repo.AddAsync(modelToAdd);

        // Assert
        var addedModel = (await repo.ToListAsync()).Last();

        addedModel.Should().Be(modelToAdd);
    }

    /// <summary>
    /// Tests the asynchronous method RemoveByIdAsync to ensure it removes a VirtualSafeDetailsModel object by its Id.
    /// </summary>
    [Fact]
    public async void RemoveByIdAsync_RemovesVirtualSafeDetailsModel()
    {
        // Arrange
        IVirtualSafeDetailsRepo repo = new VirtualSafeDetailsRepo(await GetDbContextAsync());
        var firstModelIdToRemove = (await repo.ToListAsync()).First().Id;

        // Act
        var guidRemoveResult = await repo.RemoveByIdAsync(firstModelIdToRemove);

        // Assert
        guidRemoveResult.IsSucceeded.Should().BeTrue();
    }

    /// <summary>
    /// Tests the asynchronous method RemoveAsync to ensure it removes a VirtualSafeDetailsModel object.
    /// </summary>
    [Fact]
    public async void RemoveAsync_RemovesVirtualSafeDetailsModel()
    {
        // Arrange
        IVirtualSafeDetailsRepo repo = new VirtualSafeDetailsRepo(await GetDbContextAsync());
        var modelToRemove = (await repo.ToListAsync()).First();

        // Act
        var result = await repo.RemoveAsync(modelToRemove);

        // Assert
        result.IsSucceeded.Should().BeTrue();
    }

    /// <summary>
    /// Tests the synchronous method ToList to ensure it returns a list of VirtualSafeDetailsModel objects.
    /// </summary>
    [Fact]
    public void ToList_ReturnsListOfVirtualSafeDetailsModels()
    {
        // Arrange
        IVirtualSafeDetailsRepo repo = new VirtualSafeDetailsRepo(GetDbContext());

        // Act
        var models = repo.ToList();

        // Assert
        models.Should().NotBeNull();
        models.Should().BeOfType<List<VirtualSafeDetailsModel>>();
    }

    /// <summary>
    /// Tests the synchronous method GetById to ensure it returns a VirtualSafeDetailsModel object.
    /// </summary>
    [Fact]
    public void GetById_ReturnsVirtualSafeDetailsModel()
    {
        // Arrange
        IVirtualSafeDetailsRepo repo = new VirtualSafeDetailsRepo(GetDbContext());
        var models = repo.ToList();

        // Act
        var modelGuid = repo.GetById(models.First().Id);

        // Assert
        modelGuid.IsSucceeded.Should().BeTrue();
        modelGuid.Value.Should().Be(models.First());
    }

    /// <summary>
    /// Tests the synchronous method Update to ensure it updates a VirtualSafeDetailsModel object.
    /// </summary>
    [Fact]
    public void Update_UpdatesVirtualSafeDetailsModel()
    {
        // Arrange
        IVirtualSafeDetailsRepo repo = new VirtualSafeDetailsRepo(GetDbContext());
        var models = repo.ToList();

        var modelToChange = models.First();
        modelToChange.ReservedTimestamp = DateTime.Now;

        // Act
        repo.Update(modelToChange);

        // Assert
        var changedModel = models.First();

        changedModel.Should().Be(modelToChange);
    }

    /// <summary>
    /// Tests the synchronous method Add to ensure it adds a VirtualSafeDetailsModel object.
    /// </summary>
    [Fact]
    public void Add_AddsVirtualSafeDetailsModel()
    {
        // Arrange
        IVirtualSafeDetailsRepo repo = new VirtualSafeDetailsRepo(GetDbContext());
        VirtualSafeDetailsModel modelToAdd = new();

        // Act
        repo.Add(modelToAdd);

        // Assert
        var addedModel = repo.ToList().Last();

        addedModel.Should().Be(modelToAdd);
    }

    /// <summary>
    /// Tests the synchronous method RemoveById to ensure it removes a VirtualSafeDetailsModel object by its Id.
    /// </summary>
    [Fact]
    public void RemoveById_RemovesVirtualSafeDetailsModel()
    {
        // Arrange
        IVirtualSafeDetailsRepo repo = new VirtualSafeDetailsRepo(GetDbContext());
        var firstModelIdToRemove = repo.ToList().First().Id;

        // Act
        var guidRemoveResult = repo.RemoveById(firstModelIdToRemove);

        // Assert
        guidRemoveResult.IsSucceeded.Should().BeTrue();
    }

    /// <summary>
    /// Tests the synchronous method Remove to ensure it removes a VirtualSafeDetailsModel object.
    /// </summary>
    [Fact]
    public void Remove_RemovesVirtualSafeDetailsModel()
    {
        // Arrange
        IVirtualSafeDetailsRepo repo = new VirtualSafeDetailsRepo(GetDbContext());
        var modelToRemove = repo.ToList().First();

        // Act
        var result = repo.Remove(modelToRemove);

        // Assert
        result.IsSucceeded.Should().BeTrue();
    }
}

