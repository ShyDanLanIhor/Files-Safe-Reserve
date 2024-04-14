using FilesSafeReserve.Data.DataBase;
using FilesSafeReserve.Data.Models;
using FilesSafeReserve.Data.Repositories;
using FilesSafeReserve.Data.Repositories.IRepositories;
using FilesSafeReserve.Tests.Factories;
using FluentAssertions;

namespace FilesSafeReserve.Tests.Repositories;

/// <summary>
/// Test suite for the LogOperationRepo class.
/// </summary>
public class LogOperationTests
{
    /// <summary>
    /// Asynchronously retrieves a test database context.
    /// </summary>
    /// <returns>The test database context.</returns>
    private static async Task<FsrDbContext> GetDbContextAsync()
    {
        var dbContext = TestFsrDbContextFactory.Create();

        // Adding predefined logs models
        dbContext.LogOperations.AddRange(TestLogOperationFactory.CreateList());

        await dbContext.SaveChangesAsync();

        return dbContext;
    }

    /// <summary>
    /// Retrieves a test database context.
    /// </summary>
    /// <returns>The test database context.</returns>
    private static FsrDbContext GetDbContext()
    {
        var dbContext = TestFsrDbContextFactory.Create();

        // Adding predefined logs models
        dbContext.LogOperations.AddRange(TestLogOperationFactory.CreateList());

        dbContext.SaveChanges();

        return dbContext;
    }

    /// <summary>
    /// Tests the ToListAsync method of the LogOperationRepo class.
    /// </summary>
    [Fact]
    public async void ToListAsync_ReturnsListOfLogOperationModels()
    {
        // Arrange
        ILogOperationRepo repo = new LogOperationRepo(await GetDbContextAsync());

        // Act
        var models = await repo.ToListAsync();

        // Assert
        models.Should().NotBeNull();
        models.Should().BeOfType<List<LogOperationModel>>();
    }

    /// <summary>
    /// Tests the GetByIdAsync method of the LogOperationRepo class.
    /// </summary>
    [Fact]
    public async void GetByIdAsync_ReturnsLogOperationModel()
    {
        // Arrange
        ILogOperationRepo repo = new LogOperationRepo(await GetDbContextAsync());
        var models = await repo.ToListAsync();

        // Act
        var modelGuid = await repo.GetByIdAsync(models.First().Id);

        // Assert
        modelGuid.IsSucceeded.Should().BeTrue();
        modelGuid.Value.Should().Be(models.First());
    }

    /// <summary>
    /// Tests the UpdateAsync method of the LogOperationRepo class.
    /// </summary>
    [Fact]
    public async void UpdateAsync_UpdatesLogOperationModel()
    {
        // Arrange
        ILogOperationRepo repo = new LogOperationRepo(await GetDbContextAsync());
        var models = await repo.ToListAsync();

        var modelToChange = models.First();
        modelToChange.IsSucceeded = false;
        modelToChange.Type = LogOperationModel.OperationsTypes.DeleteFile;
        modelToChange.VirtualSafeFilePath = "Changed";
        modelToChange.ExternalFilePath = "Changed";
        modelToChange.PerformTimestamp = DateTime.Now;


        // Act
        await repo.UpdateAsync(modelToChange);

        // Assert
        var changedModel = models.First();

        changedModel.Should().Be(modelToChange);
    }

    /// <summary>
    /// Tests the AddAsync method of the LogOperationRepo class.
    /// </summary>
    [Fact]
    public async void AddAsync_AddsLogOperationModel()
    {
        // Arrange
        ILogOperationRepo repo = new LogOperationRepo(await GetDbContextAsync());
        LogOperationModel modelToAdd =
            new()
            {
                IsSucceeded = false,
                Type = LogOperationModel.OperationsTypes.DeleteFile,
                VirtualSafeFilePath = "Changed",
                ExternalFilePath = "Changed",
                PerformTimestamp = DateTime.Now,
                Log = new() { VirtualSafe = new() }
            };

        // Act
        await repo.AddAsync(modelToAdd);

        // Assert
        var addedModel = (await repo.ToListAsync()).Last();

        addedModel.Should().Be(modelToAdd);
    }

    /// <summary>
    /// Tests the RemoveByIdAsync method of the LogOperationRepo class.
    /// </summary>
    [Fact]
    public async void RemoveByIdAsync_RemovesLogOperationModel()
    {
        // Arrange
        ILogOperationRepo repo = new LogOperationRepo(await GetDbContextAsync());
        var firstModelIdToRemove = (await repo.ToListAsync()).First().Id;

        // Act
        var guidRemoveResult = await repo.RemoveByIdAsync(firstModelIdToRemove);

        // Assert
        guidRemoveResult.IsSucceeded.Should().BeTrue();
    }

    /// <summary>
    /// Tests the RemoveAsync method of the LogOperationRepo class.
    /// </summary>
    [Fact]
    public async void RemoveAsync_RemovesLogOperationModel()
    {
        // Arrange
        ILogOperationRepo repo = new LogOperationRepo(await GetDbContextAsync());
        var modelToRemove = (await repo.ToListAsync()).First();

        // Act
        var result = await repo.RemoveAsync(modelToRemove);

        // Assert
        result.IsSucceeded.Should().BeTrue();
    }

    /// <summary>
    /// Tests the ToList method of the LogOperationRepo class.
    /// </summary>
    [Fact]
    public void ToList_ReturnsListOfLogOperationModels()
    {
        // Arrange
        ILogOperationRepo repo = new LogOperationRepo(GetDbContext());

        // Act
        var models = repo.ToList();

        // Assert
        models.Should().NotBeNull();
        models.Should().BeOfType<List<LogOperationModel>>();
    }

    /// <summary>
    /// Tests the GetById method of the LogOperationRepo class.
    /// </summary>
    [Fact]
    public void GetById_ReturnsLogOperationModel()
    {
        // Arrange
        ILogOperationRepo repo = new LogOperationRepo(GetDbContext());
        var models = repo.ToList();

        // Act
        var modelGuid = repo.GetById(models.First().Id);

        // Assert
        modelGuid.IsSucceeded.Should().BeTrue();
        modelGuid.Value.Should().Be(models.First());
    }

    /// <summary>
    /// Tests the Update method of the LogOperationRepo class.
    /// </summary>
    [Fact]
    public void Update_UpdatesLogOperationModel()
    {
        // Arrange
        ILogOperationRepo repo = new LogOperationRepo(GetDbContext());
        var models = repo.ToList();

        var modelToChange = models.First();
        modelToChange.IsSucceeded = false;
        modelToChange.Type = LogOperationModel.OperationsTypes.DeleteFile;
        modelToChange.VirtualSafeFilePath = "Changed";
        modelToChange.ExternalFilePath = "Changed";
        modelToChange.PerformTimestamp = DateTime.Now;

        // Act
        repo.Update(modelToChange);

        // Assert
        var changedModel = models.First();

        changedModel.Should().Be(modelToChange);
    }

    /// <summary>
    /// Tests the Add method of the LogOperationRepo class.
    /// </summary>
    [Fact]
    public void Add_AddsLogOperationModel()
    {
        // Arrange
        ILogOperationRepo repo = new LogOperationRepo(GetDbContext());
        LogOperationModel modelToAdd =
            new()
            {
                IsSucceeded = false,
                Type = LogOperationModel.OperationsTypes.DeleteFile,
                VirtualSafeFilePath = "Changed",
                ExternalFilePath = "Changed",
                PerformTimestamp = DateTime.Now,
                Log = new() { VirtualSafe = new() }
            };

        // Act
        repo.Add(modelToAdd);

        // Assert
        var addedModel = repo.ToList().Last();

        addedModel.Should().Be(modelToAdd);
    }

    /// <summary>
    /// Tests the RemoveById method of the LogOperationRepo class.
    /// </summary>
    [Fact]
    public void RemoveById_RemovesLogOperationModel()
    {
        // Arrange
        ILogOperationRepo repo = new LogOperationRepo(GetDbContext());
        var firstModelIdToRemove = repo.ToList().First().Id;

        // Act
        var guidRemoveResult = repo.RemoveById(firstModelIdToRemove);

        // Assert
        guidRemoveResult.IsSucceeded.Should().BeTrue();
    }

    /// <summary>
    /// Tests the Remove method of the LogOperationRepo class.
    /// </summary>
    [Fact]
    public void Remove_RemovesLogOperationModel()
    {
        // Arrange
        ILogOperationRepo repo = new LogOperationRepo(GetDbContext());
        var modelToRemove = repo.ToList().First();

        // Act
        var result = repo.Remove(modelToRemove);

        // Assert
        result.IsSucceeded.Should().BeTrue();
    }
}
