using FilesSafeReserve.Data.DataBase;
using FilesSafeReserve.Data.Interfaces.Repositories;
using FilesSafeReserve.Data.Models;

namespace FilesSafeReserve.Data.Repositories.IRepositories;

public interface ILogOperationRepo :
    IToListRepoBase<FsrDbContext, LogOperationModel, Guid>,
    IGetByIdRepoBase<FsrDbContext, LogOperationModel, Guid>,
    IAddRepoBase<FsrDbContext, LogOperationModel, Guid>,
    IUpdateRepoBase<FsrDbContext, LogOperationModel, Guid>,
    IDeleteRepoBase<FsrDbContext, LogOperationModel, Guid>,
    IDeleteByIdRepoBase<FsrDbContext, LogOperationModel, Guid>
{

}
