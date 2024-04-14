using FilesSafeReserve.Data.DataBase;
using FilesSafeReserve.Data.Models;
using FilesSafeReserve.Data.Repositories;
using FilesSafeReserve.Data.Repositories.IRepositories;
using FilesSafeReserve.Tests.Factories;
using FluentAssertions;

namespace FilesSafeReserve.Tests.Repositories;

public class LogRepoTests
{
    private async Task<FsrDbContext> GetDbContextAsync()
    {
        var dbContext = TestFsrDbContextFactory.Create();

        // Adding predefined logs models
        dbContext.Logs.AddRange(TestLogFactory.CreateList());

        await dbContext.SaveChangesAsync();

        return dbContext;
    }

    private FsrDbContext GetDbContext()
    {
        var dbContext = TestFsrDbContextFactory.Create();

        // Adding predefined logs models
        dbContext.Logs.AddRange(TestLogFactory.CreateList());

        dbContext.SaveChanges();

        return dbContext;
    }

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

    [Fact]
    public async void DeleteByIdAsync_DeletesLogModel()
    {
        // Arrange
        ILogRepo repo = new LogRepo(await GetDbContextAsync());
        var firstModelIdToDelete = (await repo.ToListAsync()).First().Id;

        // Act
        var guidDeleteResult = await repo.DeleteByIdAsync(firstModelIdToDelete);

        // Assert
        guidDeleteResult.IsSucceeded.Should().BeTrue();
    }

    [Fact]
    public async void DeleteAsync_DeletesLogModel()
    {
        // Arrange
        ILogRepo repo = new LogRepo(await GetDbContextAsync());
        var modelToDelete = (await repo.ToListAsync()).First();

        // Act
        var result = await repo.DeleteAsync(modelToDelete);

        // Assert
        result.IsSucceeded.Should().BeTrue();
    }

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

    [Fact]
    public void DeleteById_DeletesLogModel()
    {
        // Arrange
        ILogRepo repo = new LogRepo(GetDbContext());
        var firstModelIdToDelete = repo.ToList().First().Id;

        // Act
        var guidDeleteResult = repo.DeleteById(firstModelIdToDelete);

        // Assert
        guidDeleteResult.IsSucceeded.Should().BeTrue();
    }

    [Fact]
    public void Delete_DeletesLogModel()
    {
        // Arrange
        ILogRepo repo = new LogRepo(GetDbContext());
        var modelToDelete = repo.ToList().First();

        // Act
        var result = repo.Delete(modelToDelete);

        // Assert
        result.IsSucceeded.Should().BeTrue();
    }
}
