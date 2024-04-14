﻿using FilesSafeReserve.Data.DataBase;
using FilesSafeReserve.Data.Models;
using FilesSafeReserve.Data.Repositories;
using FilesSafeReserve.Data.Repositories.IRepositories;
using FilesSafeReserve.Tests.Factories;
using FluentAssertions;

namespace FilesSafeReserve.Tests.Repositories;

public class VirtualSafeRepoTests
{
    private async Task<FsrDbContext> GetDbContextAsync()
    {
        var dbContext = TestFsrDbContextFactory.Create();

        // Adding predefined virtual safe models
        dbContext.VirtualSafes.AddRange(TestVirtualSafeFactory.CreateList());

        await dbContext.SaveChangesAsync();

        return dbContext;
    }

    private FsrDbContext GetDbContext()
    {
        var dbContext = TestFsrDbContextFactory.Create();

        // Adding predefined virtual safe models
        dbContext.VirtualSafes.AddRange(TestVirtualSafeFactory.CreateList());

        dbContext.SaveChanges();

        return dbContext;
    }

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

    [Fact]
    public async void DeleteByIdAsync_DeletesVirtualSafeModel()
    {
        // Arrange
        IVirtualSafeRepo repo = new VirtualSafeRepo(await GetDbContextAsync());
        var firstModelIdToDelete = (await repo.ToListAsync()).First().Id;

        // Act
        var guidDeleteResult = await repo.DeleteByIdAsync(firstModelIdToDelete);

        // Assert
        guidDeleteResult.IsSucceeded.Should().BeTrue();
    }

    [Fact]
    public async void DeleteAsync_DeletesVirtualSafeModel()
    {
        // Arrange
        IVirtualSafeRepo repo = new VirtualSafeRepo(await GetDbContextAsync());
        var modelToDelete = (await repo.ToListAsync()).First();

        // Act
        var result = await repo.DeleteAsync(modelToDelete);

        // Assert
        result.IsSucceeded.Should().BeTrue();
    }

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

    [Fact]
    public void DeleteById_DeletesVirtualSafeModel()
    {
        // Arrange
        IVirtualSafeRepo repo = new VirtualSafeRepo(GetDbContext());
        var firstModelIdToDelete = repo.ToList().First().Id;

        // Act
        var guidDeleteResult = repo.DeleteById(firstModelIdToDelete);

        // Assert
        guidDeleteResult.IsSucceeded.Should().BeTrue();
    }

    [Fact]
    public void Delete_DeletesVirtualSafeModel()
    {
        // Arrange
        IVirtualSafeRepo repo = new VirtualSafeRepo(GetDbContext());
        var modelToDelete = repo.ToList().First();

        // Act
        var result = repo.Delete(modelToDelete);

        // Assert
        result.IsSucceeded.Should().BeTrue();
    }
}

