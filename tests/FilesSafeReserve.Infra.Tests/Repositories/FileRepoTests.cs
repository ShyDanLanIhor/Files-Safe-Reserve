using FilesSafeReserve.App.Models;
using FilesSafeReserve.Infra.DataBase;
using FilesSafeReserve.Infra.Repositories;
using FilesSafeReserve.Infra.Repositories.IRepositories;
using FilesSafeReserve.Infra.Tests.Factories;
using FluentAssertions;

namespace FilesSafeReserve.Infra.Tests.Repositories;

/// <summary>
/// Tests for FileRepo class.
/// </summary>
public class FileRepoTests
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
    /// Tests the asynchronous method ToListAsync to ensure it returns a list of FileModel objects.
    /// </summary>
    [Fact]
    public async Task ToListAsync_ReturnsListOfFileModels()
    {
        // Arrange
        IFileRepo repo = new FileRepo(await GetDbContextAsync());

        // Act
        var models = await repo.ToListAsync();

        // Assert
        models.Should().NotBeNull();
        models.Should().BeOfType<List<FileModel>>();
    }

    /// <summary>
    /// Tests the asynchronous method GetByIdAsync to ensure it returns a FileModel object.
    /// </summary>
    [Fact]
    public async Task GetByIdAsync_ReturnsFileModel()
    {
        // Arrange
        IFileRepo repo = new FileRepo(await GetDbContextAsync());
        var models = await repo.ToListAsync();

        // Act
        var modelGuid = await repo.GetByIdAsync(models.First().Id);

        // Assert
        modelGuid.IsSucceeded.Should().BeTrue();
        modelGuid.Value.Should().Be(models.First());
    }

    /// <summary>
    /// Tests the asynchronous method UpdateAsync to ensure it updates a FileModel object.
    /// </summary>
    [Fact]
    public async Task UpdateAsync_UpdatesFileModel()
    {
        // Arrange
        IFileRepo repo = new FileRepo(await GetDbContextAsync());
        var models = await repo.ToListAsync();

        var modelToChange = models.First();
        modelToChange.Path = @"C:\Users\username\file.extension";

        // Act
        await repo.UpdateAsync(modelToChange);

        // Assert
        var changedModel = models.First();

        changedModel.Should().Be(modelToChange);
    }

    /// <summary>
    /// Tests the asynchronous method AddAsync to ensure it adds a FileModel object.
    /// </summary>
    [Fact]
    public async Task AddAsync_AddsFileModel()
    {
        // Arrange
        IFileRepo repo = new FileRepo(await GetDbContextAsync());
        FileModel modelToAdd = new()
        {
            Path = @"C:\Users\username\file.extension"
        };

        // Act
        await repo.AddAsync(modelToAdd);

        // Assert
        var addedModel = (await repo.ToListAsync()).Last();

        addedModel.Should().Be(modelToAdd);
    }

    /// <summary>
    /// Tests the asynchronous method RemoveByIdAsync to ensure it removes a FileModel object by its Id.
    /// </summary>
    [Fact]
    public async Task RemoveByIdAsync_RemovesFileModel()
    {
        // Arrange
        IFileRepo repo = new FileRepo(await GetDbContextAsync());
        var firstModelIdToRemove = (await repo.ToListAsync()).First().Id;

        // Act
        var guidRemoveResult = await repo.RemoveByIdAsync(firstModelIdToRemove);

        // Assert
        guidRemoveResult.IsSucceeded.Should().BeTrue();
    }

    /// <summary>
    /// Tests the asynchronous method RemoveAsync to ensure it removes a FileModel object.
    /// </summary>
    [Fact]
    public async Task RemoveAsync_RemovesFileModel()
    {
        // Arrange
        IFileRepo repo = new FileRepo(await GetDbContextAsync());
        var modelToRemove = (await repo.ToListAsync()).First();

        // Act
        var result = await repo.RemoveAsync(modelToRemove);

        // Assert
        result.IsSucceeded.Should().BeTrue();
    }

    /// <summary>
    /// Tests the synchronous method ToList to ensure it returns a list of FileModel objects.
    /// </summary>
    [Fact]
    public void ToList_ReturnsListOfFileModels()
    {
        // Arrange
        IFileRepo repo = new FileRepo(GetDbContext());

        // Act
        var models = repo.ToList();

        // Assert
        models.Should().NotBeNull();
        models.Should().BeOfType<List<FileModel>>();
    }

    /// <summary>
    /// Tests the synchronous method GetById to ensure it returns a FileModel object.
    /// </summary>
    [Fact]
    public void GetById_ReturnsFileModel()
    {
        // Arrange
        IFileRepo repo = new FileRepo(GetDbContext());
        var models = repo.ToList();

        // Act
        var modelGuid = repo.GetById(models.First().Id);

        // Assert
        modelGuid.IsSucceeded.Should().BeTrue();
        modelGuid.Value.Should().Be(models.First());
    }

    /// <summary>
    /// Tests the synchronous method Update to ensure it updates a FileModel object.
    /// </summary>
    [Fact]
    public void Update_UpdatesFileModel()
    {
        // Arrange
        IFileRepo repo = new FileRepo(GetDbContext());
        var models = repo.ToList();

        var modelToChange = models.First();
        modelToChange.Path = @"C:\Users\username\file.extension";

        // Act
        repo.Update(modelToChange);

        // Assert
        var changedModel = models.First();

        changedModel.Should().Be(modelToChange);
    }

    /// <summary>
    /// Tests the synchronous method Add to ensure it adds a FileModel object.
    /// </summary>
    [Fact]
    public void Add_AddsFileModel()
    {
        // Arrange
        IFileRepo repo = new FileRepo(GetDbContext());
        FileModel modelToAdd = new()
        {
            Path = @"C:\Users\username\file.extension"
        };

        // Act
        repo.Add(modelToAdd);

        // Assert
        var addedModel = repo.ToList().Last();

        addedModel.Should().Be(modelToAdd);
    }

    /// <summary>
    /// Tests the synchronous method RemoveById to ensure it removes a FileModel object by its Id.
    /// </summary>
    [Fact]
    public void RemoveById_RemovesFileModel()
    {
        // Arrange
        IFileRepo repo = new FileRepo(GetDbContext());
        var firstModelIdToRemove = repo.ToList().First().Id;

        // Act
        var guidRemoveResult = repo.RemoveById(firstModelIdToRemove);

        // Assert
        guidRemoveResult.IsSucceeded.Should().BeTrue();
    }

    /// <summary>
    /// Tests the synchronous method Remove to ensure it removes a FileModel object.
    /// </summary>
    [Fact]
    public void Remove_RemovesFileModel()
    {
        // Arrange
        IFileRepo repo = new FileRepo(GetDbContext());
        var modelToRemove = repo.ToList().First();

        // Act
        var result = repo.Remove(modelToRemove);

        // Assert
        result.IsSucceeded.Should().BeTrue();
    }
}
