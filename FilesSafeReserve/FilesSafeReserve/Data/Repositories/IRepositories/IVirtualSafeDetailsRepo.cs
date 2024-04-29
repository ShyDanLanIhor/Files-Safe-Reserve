using FilesSafeReserve.Data.DataBase;
using FilesSafeReserve.Data.Interfaces.Repositories;
using FilesSafeReserve.Data.Models;

namespace FilesSafeReserve.Data.Repositories.IRepositories;

public interface IVirtualSafeDetailsRepo :
    IRepoToList<FsrDbContext, VirtualSafeDetailsModel, Guid>,
    IRepoGetterById<FsrDbContext, VirtualSafeDetailsModel, Guid>,
    IRepoAdder<FsrDbContext, VirtualSafeDetailsModel, Guid>,
    IRepoUpdater<FsrDbContext, VirtualSafeDetailsModel, Guid>,
    IRepoRemover<FsrDbContext, VirtualSafeDetailsModel, Guid>,
    IRepoRemoverById<FsrDbContext, VirtualSafeDetailsModel, Guid>
{

}
