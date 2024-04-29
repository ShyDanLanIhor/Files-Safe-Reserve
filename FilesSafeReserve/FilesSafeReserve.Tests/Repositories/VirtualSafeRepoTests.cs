using FilesSafeReserve.Data.DataBase;
using FilesSafeReserve.Data.Models;
using FilesSafeReserve.Data.Repositories;
using FilesSafeReserve.Data.Repositories.IRepositories;
using FilesSafeReserve.Tests.Factories;
using FluentAssertions;

namespace FilesSafeReserve.Tests.Repositories;

/// <summary>
/// Test suite for the VirtualSafeRepo class.
/// </summary>
public class VirtualSafeRepoTests
{
    /// <summary>
    /// Asynchronously retrieves a test database context.
    /// </summary>
    /// <returns>The test database context.</returns>
    private static async Task<FsrDbContext> GetDbContextAsync()
    {
        var dbContext = TestsFsrDbContextFactory.Create();

        // Adding predefined virtual safe models
        dbContext.VirtualSafes.AddRange(TestsVirtualSafeFactory.CreateRandomList());

        await dbContext.SaveChangesAsync();

        return dbContext;
    }

    /// <summary>
    /// Retrieves a test database context.
    /// </summary>
    /// <returns>The test database context.</returns>
    private static FsrDbContext GetDbContext()
    {
        var dbContext = TestsFsrDbContextFactory.Create();

        // Adding predefined virtual safe models
        dbContext.VirtualSafes.AddRange(TestsVirtualSafeFactory.CreateRandomList());

        dbContext.SaveChanges();

        return dbContext;
    }

    /// <summary>
    /// Tests the ToListAsync method of the VirtualSafeRepo class.
    /// </summary>
    [Fact]
    public async void ToListAsync_ReturnsListOfVirtualSafeModels()
    {
        // Arrange
        IVirtualSafeRepo repo = new VirtualSafeRepo(await GetDbContextAsync());

        // Act
        var models = await repo.ToListAsync();

        // Assert
        models.Should().NotBeNull();
        models.Should().BeOfType<List<VirtualSafeModel>>();
    }

    /// <summary>
    /// Tests the GetByIdAsync method of the VirtualSafeRepo class.
    /// </summary>
    [Fact]
    public async void GetByIdAsync_ReturnsVirtualSafeModel()
    {
        // Arrange
        IVirtualSafeRepo repo = new VirtualSafeRepo(await GetDbContextAsync());
        var models = await repo.ToListAsync();

        // Act
        var modelGuid = await repo.GetByIdAsync(models.First().Id);

        // Assert
        modelGuid.IsSucceeded.Should().BeTrue();
        modelGuid.Value.Should().Be(models.First());
    }

    /// <summary>
    /// Tests the UpdateAsync method of the VirtualSafeRepo class.
    /// </summary>
    [Fact]
    public async void UpdateAsync_UpdatesVirtualSafeModel()
    {
        // Arrange
        IVirtualSafeRepo repo = new VirtualSafeRepo(await GetDbContextAsync());
        var models = await repo.ToListAsync();

        var modelToChange = models.First();
        modelToChange.Name = "Changed";
        modelToChange.Description = "Changed";
        modelToChange.Path = "Changed";

        // Act
        await repo.UpdateAsync(modelToChange);

        // Assert
        var changedModel = models.First();

        changedModel.Should().Be(modelToChange);
    }

    /// <summary>
    /// Tests the AddAsync method of the VirtualSafeRepo class.
    /// </summary>
    [Fact]
    public async void AddAsync_AddsVirtualSafeModel()
    {
        // Arrange
        IVirtualSafeRepo repo = new VirtualSafeRepo(await GetDbContextAsync());
        VirtualSafeModel modelToAdd =
            new()
            {
                Name = "New Test Name",
                Description = "New Test Description",
                Path = @"C:\Users\username\Documents"
            };

        // Act
        await repo.AddAsync(modelToAdd);

        // Assert
        var addedModel = (await repo.ToListAsync()).Last();

        addedModel.Should().Be(modelToAdd);
    }

    /// <summary>
    /// Tests the RemoveByIdAsync method of the VirtualSafeRepo class.
    /// </summary>
    [Fact]
    public async void RemoveByIdAsync_RemovesVirtualSafeModel()
    {
        // Arrange
        IVirtualSafeRepo repo = new VirtualSafeRepo(await GetDbContextAsync());
        var firstModelIdToRemove = (await repo.ToListAsync()).First().Id;

        // Act
        var guidRemoveResult = await repo.RemoveByIdAsync(firstModelIdToRemove);

        // Assert
        guidRemoveResult.IsSucceeded.Should().BeTrue();
    }

    /// <summary>
    /// Tests the RemoveAsync method of the VirtualSafeRepo class.
    /// </summary>
    [Fact]
    public async void RemoveAsync_RemovesVirtualSafeModel()
    {
        // Arrange
        IVirtualSafeRepo repo = new VirtualSafeRepo(await GetDbContextAsync());
        var modelToRemove = (await repo.ToListAsync()).First();

        // Act
        var result = await repo.RemoveAsync(modelToRemove);

        // Assert
        result.IsSucceeded.Should().BeTrue();
    }

    /// <summary>
    /// Tests the ToList method of the VirtualSafeRepo class.
    /// </summary>
    [Fact]
    public void ToList_ReturnsListOfVirtualSafeModels()
    {
        // Arrange
        IVirtualSafeRepo repo = new VirtualSafeRepo(GetDbContext());

        // Act
        var models = repo.ToList();

        // Assert
        models.Should().NotBeNull();
        models.Should().BeOfType<List<VirtualSafeModel>>();
    }

    /// <summary>
    /// Tests the GetById method of the VirtualSafeRepo class.
    /// </summary>
    [Fact]
    public void GetById_ReturnsVirtualSafeModel()
    {
        // Arrange
        IVirtualSafeRepo repo = new VirtualSafeRepo(GetDbContext());
        var models = repo.ToList();

        // Act
        var modelGuid = repo.GetById(models.First().Id);

        // Assert
        modelGuid.IsSucceeded.Should().BeTrue();
        modelGuid.Value.Should().Be(models.First());
    }

    /// <summary>
    /// Tests the Update method of the VirtualSafeRepo class.
    /// </summary>
    [Fact]
    public void Update_UpdatesVirtualSafeModel()
    {
        // Arrange
        IVirtualSafeRepo repo = new VirtualSafeRepo(GetDbContext());
        var models = repo.ToList();

        var modelToChange = models.First();
        modelToChange.Name = "Changed";
        modelToChange.Description = "Changed";
        modelToChange.Path = "Changed";

        // Act
        repo.Update(modelToChange);

        // Assert
        var changedModel = models.First();

        changedModel.Should().Be(modelToChange);
    }

    /// <summary>
    /// Tests the Add method of the VirtualSafeRepo class.
    /// </summary>
    [Fact]
    public void Add_AddsVirtualSafeModel()
    {
        // Arrange
        IVirtualSafeRepo repo = new VirtualSafeRepo(GetDbContext());
        VirtualSafeModel modelToAdd =
            new()
            {
                Name = "New Test Name",
                Description = "New Test Description",
                Path = @"C:\Users\username\Documents"
            };

        // Act
        repo.Add(modelToAdd);

        // Assert
        var addedModel = repo.ToList().Last();

        addedModel.Should().Be(modelToAdd);
    }

    /// <summary>
    /// Tests the RemoveById method of the VirtualSafeRepo class.
    /// </summary>
    [Fact]
    public void RemoveById_RemovesVirtualSafeModel()
    {
        // Arrange
        IVirtualSafeRepo repo = new VirtualSafeRepo(GetDbContext());
        var firstModelIdToRemove = repo.ToList().First().Id;

        // Act
        var guidRemoveResult = repo.RemoveById(firstModelIdToRemove);

        // Assert
        guidRemoveResult.IsSucceeded.Should().BeTrue();
    }

    /// <summary>
    /// Tests the Remove method of the VirtualSafeRepo class.
    /// </summary>
    [Fact]
    public void Remove_RemovesVirtualSafeModel()
    {
        // Arrange
        IVirtualSafeRepo repo = new VirtualSafeRepo(GetDbContext());
        var modelToRemove = repo.ToList().First();

        // Act
        var result = repo.Remove(modelToRemove);

        // Assert
        result.IsSucceeded.Should().BeTrue();
    }
}

