using FilesSafeReserve.Data.DataBase;
using FilesSafeReserve.Data.Interfaces.Repositories;
using FilesSafeReserve.Data.Models;

namespace FilesSafeReserve.Data.Repositories.IRepositories;

public interface ILogRepo :
    IToListRepoBase<FsrDbContext, LogModel, Guid>,
    IGetByIdRepoBase<FsrDbContext, LogModel, Guid>,
    IAddRepoBase<FsrDbContext, LogModel, Guid>,
    IUpdateRepoBase<FsrDbContext, LogModel, Guid>,
    IDeleteRepoBase<FsrDbContext, LogModel, Guid>,
    IDeleteByIdRepoBase<FsrDbContext, LogModel, Guid>
{

}
