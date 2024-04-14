using FilesSafeReserve.Data.DataBase;
using FilesSafeReserve.Data.Models;
using FilesSafeReserve.Data.Repositories;
using FilesSafeReserve.Data.Repositories.IRepositories;
using FilesSafeReserve.Tests.Factories;
using FluentAssertions;

namespace FilesSafeReserve.Tests.Repositories;

/// <summary>
/// Test suite for the LogRepo class.
/// </summary>
public class LogRepoTests
{
    /// <summary>
    /// Asynchronously retrieves a test database context.
    /// </summary>
    /// <returns>The test database context.</returns>
    private static async Task<FsrDbContext> GetDbContextAsync()
    {
        var dbContext = TestFsrDbContextFactory.Create();

        // Adding predefined logs models
        dbContext.Logs.AddRange(TestLogFactory.CreateList());

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
        dbContext.Logs.AddRange(TestLogFactory.CreateList());

        dbContext.SaveChanges();

        return dbContext;
    }

    /// <summary>
    /// Tests the ToListAsync method of the LogRepo class.
    /// </summary>
    [Fact]
    public async void ToListAsync_ReturnsListOfLogModels()
    {
        // Arrange
        ILogRepo repo = new LogRepo(await GetDbContextAsync());

        // Act
        var models = await repo.ToListAsync();

        // Assert
        models.Should().NotBeNull();
        models.Should().BeOfType<List<LogModel>>();
    }

    /// <summary>
    /// Tests the GetByIdAsync method of the LogRepo class.
    /// </summary>
    [Fact]
    public async void GetByIdAsync_ReturnsLogModel()
    {
        // Arrange
        ILogRepo repo = new LogRepo(await GetDbContextAsync());
        var models = await repo.ToListAsync();

        // Act
        var modelGuid = await repo.GetByIdAsync(models.First().Id);

        // Assert
        modelGuid.IsSucceeded.Should().BeTrue();
        modelGuid.Value.Should().Be(models.First());
    }

    /// <summary>
    /// Tests the UpdateAsync method of the LogRepo class.
    /// </summary>
    [Fact]
    public async void UpdateAsync_UpdatesLogModel()
    {
        // Arrange
        ILogRepo repo = new LogRepo(await GetDbContextAsync());
        var models = await repo.ToListAsync();

        var modelToChange = models.First();
        modelToChange.StartTimestamp = DateTime.Now;
        modelToChange.EndTimestamp = DateTime.Now;

        // Act
        await repo.UpdateAsync(modelToChange);

        // Assert
        var changedModel = models.First();

        changedModel.Should().Be(modelToChange);
    }

    /// <summary>
    /// Tests the AddAsync method of the LogRepo class.
    /// </summary>
    [Fact]
    public async void AddAsync_AddsLogModel()
    {
        // Arrange
        ILogRepo repo = new LogRepo(await GetDbContextAsync());
        LogModel modelToAdd =
            new()
            {
                StartTimestamp = DateTime.Now,
                EndTimestamp = DateTime.Now
            };

        // Act
        await repo.AddAsync(modelToAdd);

        // Assert
        var addedModel = (await repo.ToListAsync()).Last();

        addedModel.Should().Be(modelToAdd);
    }

    /// <summary>
    /// Tests the RemoveByIdAsync method of the LogRepo class.
    /// </summary>
    [Fact]
    public async void RemoveByIdAsync_RemovesLogModel()
    {
        // Arrange
        ILogRepo repo = new LogRepo(await GetDbContextAsync());
        var firstModelIdToRemove = (await repo.ToListAsync()).First().Id;

        // Act
        var guidRemoveResult = await repo.RemoveByIdAsync(firstModelIdToRemove);

        // Assert
        guidRemoveResult.IsSucceeded.Should().BeTrue();
    }

    /// <summary>
    /// Tests the RemoveAsync method of the LogRepo class.
    /// </summary>
    [Fact]
    public async void RemoveAsync_RemovesLogModel()
    {
        // Arrange
        ILogRepo repo = new LogRepo(await GetDbContextAsync());
        var modelToRemove = (await repo.ToListAsync()).First();

        // Act
        var result = await repo.RemoveAsync(modelToRemove);

        // Assert
        result.IsSucceeded.Should().BeTrue();
    }

    /// <summary>
    /// Tests the ToList method of the LogRepo class.
    /// </summary>
    [Fact]
    public void ToList_ReturnsListOfLogModels()
    {
        // Arrange
        ILogRepo repo = new LogRepo(GetDbContext());

        // Act
        var models = repo.ToList();

        // Assert
        models.Should().NotBeNull();
        models.Should().BeOfType<List<LogModel>>();
    }

    /// <summary>
    /// Tests the GetById method of the LogRepo class.
    /// </summary>
    [Fact]
    public void GetById_ReturnsLogModel()
    {
        // Arrange
        ILogRepo repo = new LogRepo(GetDbContext());
        var models = repo.ToList();

        // Act
        var modelGuid = repo.GetById(models.First().Id);

        // Assert
        modelGuid.IsSucceeded.Should().BeTrue();
        modelGuid.Value.Should().Be(models.First());
    }

    /// <summary>
    /// Tests the Update method of the LogRepo class.
    /// </summary>
    [Fact]
    public void Update_UpdatesLogModel()
    {
        // Arrange
        ILogRepo repo = new LogRepo(GetDbContext());
        var models = repo.ToList();

        var modelToChange = models.First();
        modelToChange.StartTimestamp = DateTime.Now;
        modelToChange.EndTimestamp = DateTime.Now;

        // Act
        repo.Update(modelToChange);

        // Assert
        var changedModel = models.First();

        changedModel.Should().Be(modelToChange);
    }

    /// <summary>
    /// Tests the Add method of the LogRepo class.
    /// </summary>
    [Fact]
    public void Add_AddsLogModel()
    {
        // Arrange
        ILogRepo repo = new LogRepo(GetDbContext());
        LogModel modelToAdd =
            new()
            {
                StartTimestamp = DateTime.Now,
                EndTimestamp = DateTime.Now
            };

        // Act
        repo.Add(modelToAdd);

        // Assert
        var addedModel = repo.ToList().Last();

        addedModel.Should().Be(modelToAdd);
    }

    /// <summary>
    /// Tests the RemoveById method of the LogRepo class.
    /// </summary>
    [Fact]
    public void RemoveById_RemovesLogModel()
    {
        // Arrange
        ILogRepo repo = new LogRepo(GetDbContext());
        var firstModelIdToRemove = repo.ToList().First().Id;

        // Act
        var guidRemoveResult = repo.RemoveById(firstModelIdToRemove);

        // Assert
        guidRemoveResult.IsSucceeded.Should().BeTrue();
    }

    /// <summary>
    /// Tests the Remove method of the LogRepo class.
    /// </summary>
    [Fact]
    public void Remove_RemovesLogModel()
    {
        // Arrange
        ILogRepo repo = new LogRepo(GetDbContext());
        var modelToRemove = repo.ToList().First();

        // Act
        var result = repo.Remove(modelToRemove);

        // Assert
        result.IsSucceeded.Should().BeTrue();
    }
}
