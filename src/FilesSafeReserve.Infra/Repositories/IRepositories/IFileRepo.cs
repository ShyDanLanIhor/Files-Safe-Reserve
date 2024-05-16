﻿using FilesSafeReserve.App.Entities.Results.Basic;
using FilesSafeReserve.App.Models;
using FilesSafeReserve.Infra.DataBase;
using FilesSafeReserve.Infra.Interfaces.Repositories;

namespace FilesSafeReserve.Infra.Repositories.IRepositories;

public interface IFileRepo :
    IRepoToList<FsrDbContext, FileModel, Guid>,
    IRepoGetterById<FsrDbContext, FileModel, Guid>,
    IRepoAdder<FsrDbContext, FileModel, Guid>,
    IRepoUpdater<FsrDbContext, FileModel, Guid>,
    IRepoRemover<FsrDbContext, FileModel, Guid>,
    IRepoRemoverById<FsrDbContext, FileModel, Guid>
{
    public Task<ValueResult<FileModel?>> GetByPathAsync(string path);

    public ValueResult<FileModel?> GetByPath(string path);
}
