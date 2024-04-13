using FilesSafeReserve.Data.DataBase;
using FilesSafeReserve.Data.Models;
using FilesSafeReserve.Data.Repositories;
using FilesSafeReserve.Tests.Factories;
using FluentAssertions;

namespace FilesSafeReserve.Tests.Repositories;

/// <summary>
/// Unit tests for the <see cref="VirtualSafeRepo"/> class.
/// </summary>
public class VirtualSafeRepoTests
{
    /// <summary>
    /// Gets a new instance of <see cref="FsrDbContext"/> with predefined virtual safe models for testing.
    /// </summary>
    /// <returns>A task that represents the asynchronous operation. The task result contains the database context.</returns>
    private async Task<FsrDbContext> GetDbContext()
    {
        var dbContext = TestFsrDbContextFactory.Create();

        // Adding predefined virtual safe models
        dbContext.VirtualSafeModels.Add(
            new VirtualSafeModel
            {
                Name = "Test Name 1",
                Description = "Test Description 1",
                Path = @"C:\Users\username\Documents"
            });
        dbContext.VirtualSafeModels.Add(
            new VirtualSafeModel
            {
                Name = "Test Name 2",
                Description = "Test Description 2",
                Path = @"C:\Users\username\Documents"
            });
        dbContext.VirtualSafeModels.Add(
            new VirtualSafeModel
            {
                Name = "Test Name 3",
                Description = "Test Description 3",
                Path = @"C:\Users\username\Documents"
            });

        await dbContext.SaveChangesAsync();

        return dbContext;
    }

    /// <summary>
    /// Tests the <see cref="VirtualSafeRepo.GetAll"/> method.
    /// </summary>
    [Fact]
    public async void GetAll_ReturnsListOfVirtualSafeModels()
    {
        // Arrange
        VirtualSafeRepo repo = new(await GetDbContext());

        // Act
        var models = await repo.GetAll();

        // Assert
        models.Should().NotBeNull();
        models.Should().BeOfType<List<VirtualSafeModel>>();
    }

    /// <summary>
    /// Tests the <see cref="VirtualSafeRepo.GetById(Guid)"/> and <see cref="VirtualSafeRepo.GetById(string)"/> methods.
    /// </summary>
    [Fact]
    public async void GetById_ReturnsVirtualSafeModel()
    {
        // Arrange
        VirtualSafeRepo repo = new(await GetDbContext());
        var models = await repo.GetAll();

        // Act
        var modelGuid = await repo.GetById(models.First().Id);
        var modelString = await repo.GetById(models.Last().Id.ToString());

        // Assert
        modelGuid.IsSucceeded.Should().BeTrue();
        modelString.IsSucceeded.Should().BeTrue();

        modelGuid.Value.Should().Be(models.First());
        modelString.Value.Should().Be(models.Last());
    }

    /// <summary>
    /// Tests the <see cref="VirtualSafeRepo.Update"/> method.
    /// </summary>
    [Fact]
    public async void Update_UpdatesVirtualSafeModel()
    {
        // Arrange
        VirtualSafeRepo repo = new(await GetDbContext());
        var models = await repo.GetAll();

        var modelToChange = models.First();
        modelToChange.Name = "Changed";
        modelToChange.Description = "Changed";
        modelToChange.Path = "Changed";

        // Act
        await repo.Update(modelToChange);

        // Assert
        var changedModel = models.First();

        changedModel.Should().Be(modelToChange);
    }

    /// <summary>
    /// Tests the <see cref="VirtualSafeRepo.Add"/> method.
    /// </summary>
    [Fact]
    public async void Add_AddsVirtualSafeModel()
    {
        // Arrange
        VirtualSafeRepo repo = new(await GetDbContext());
        VirtualSafeModel modelToAdd =
            new()
            {
                Name = "New Test Name",
                Description = "New Test Description",
                Path = @"C:\Users\username\Documents"
            };

        // Act
        await repo.Add(modelToAdd);

        // Assert
        var addedModel = (await repo.GetAll()).Last();

        addedModel.Should().Be(modelToAdd);
    }

    /// <summary>
    /// Tests the <see cref="VirtualSafeRepo.DeleteById(Guid)"/> and <see cref="VirtualSafeRepo.DeleteById(string)"/> methods.
    /// </summary>
    [Fact]
    public async void DeleteById_DeletesVirtualSafeModel()
    {
        // Arrange
        VirtualSafeRepo repo = new(await GetDbContext());
        var firstModelIdToDelete = (await repo.GetAll()).First().Id;
        var lastModelIdToDelete = (await repo.GetAll()).Last().Id.ToString();

        // Act
        var guidDeleteResult = await repo.DeleteById(firstModelIdToDelete);
        var strDeleteResult = await repo.DeleteById(lastModelIdToDelete);

        // Assert
        guidDeleteResult.IsSucceeded.Should().BeTrue();
        strDeleteResult.IsSucceeded.Should().BeTrue();
    }

    /// <summary>
    /// Tests the <see cref="VirtualSafeRepo.Delete"/> method.
    /// </summary>
    [Fact]
    public async void Delete_DeletesVirtualSafeModel()
    {
        // Arrange
        VirtualSafeRepo repo = new(await GetDbContext());
        var modelToDelete = (await repo.GetAll()).First();

        // Act
        var result = await repo.Delete(modelToDelete);

        // Assert
        result.IsSucceeded.Should().BeTrue();
    }
}

