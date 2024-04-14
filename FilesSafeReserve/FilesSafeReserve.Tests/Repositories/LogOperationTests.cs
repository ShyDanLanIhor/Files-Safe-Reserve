using FilesSafeReserve.Data.DataBase;
using FilesSafeReserve.Data.Models;
using FilesSafeReserve.Data.Repositories;
using FilesSafeReserve.Data.Repositories.IRepositories;
using FilesSafeReserve.Tests.Factories;
using FluentAssertions;

namespace FilesSafeReserve.Tests.Repositories;

public class LogOperationTests
{
    private async Task<FsrDbContext> GetDbContextAsync()
    {
        var dbContext = TestFsrDbContextFactory.Create();

        // Adding predefined logs models
        dbContext.LogOperations.AddRange(TestLogOperationFactory.CreateList());

        await dbContext.SaveChangesAsync();

        return dbContext;
    }

    private FsrDbContext GetDbContext()
    {
        var dbContext = TestFsrDbContextFactory.Create();

        // Adding predefined logs models
        dbContext.LogOperations.AddRange(TestLogOperationFactory.CreateList());

        dbContext.SaveChanges();

        return dbContext;
    }

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
                PerformTimestamp = DateTime.Now
            };

        // Act
        await repo.AddAsync(modelToAdd);

        // Assert
        var addedModel = (await repo.ToListAsync()).Last();

        addedModel.Should().Be(modelToAdd);
    }

    [Fact]
    public async void DeleteByIdAsync_DeletesLogOperationModel()
    {
        // Arrange
        ILogOperationRepo repo = new LogOperationRepo(await GetDbContextAsync());
        var firstModelIdToDelete = (await repo.ToListAsync()).First().Id;

        // Act
        var guidDeleteResult = await repo.DeleteByIdAsync(firstModelIdToDelete);

        // Assert
        guidDeleteResult.IsSucceeded.Should().BeTrue();
    }

    [Fact]
    public async void DeleteAsync_DeletesLogOperationModel()
    {
        // Arrange
        ILogOperationRepo repo = new LogOperationRepo(await GetDbContextAsync());
        var modelToDelete = (await repo.ToListAsync()).First();

        // Act
        var result = await repo.DeleteAsync(modelToDelete);

        // Assert
        result.IsSucceeded.Should().BeTrue();
    }

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
                PerformTimestamp = DateTime.Now
            };

        // Act
        repo.Add(modelToAdd);

        // Assert
        var addedModel = repo.ToList().Last();

        addedModel.Should().Be(modelToAdd);
    }

    [Fact]
    public void DeleteById_DeletesLogOperationModel()
    {
        // Arrange
        ILogOperationRepo repo = new LogOperationRepo(GetDbContext());
        var firstModelIdToDelete = repo.ToList().First().Id;

        // Act
        var guidDeleteResult = repo.DeleteById(firstModelIdToDelete);

        // Assert
        guidDeleteResult.IsSucceeded.Should().BeTrue();
    }

    [Fact]
    public void Delete_DeletesLogOperationModel()
    {
        // Arrange
        ILogOperationRepo repo = new LogOperationRepo(GetDbContext());
        var modelToDelete = repo.ToList().First();

        // Act
        var result = repo.Delete(modelToDelete);

        // Assert
        result.IsSucceeded.Should().BeTrue();
    }
}
