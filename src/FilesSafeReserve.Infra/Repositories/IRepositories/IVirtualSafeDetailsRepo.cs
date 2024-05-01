using FilesSafeReserve.App.Models;
using FilesSafeReserve.Infra.DataBase;
using FilesSafeReserve.Infra.Interfaces.Repositories;

namespace FilesSafeReserve.Infra.Repositories.IRepositories;

public interface IVirtualSafeDetailsRepo :
    IRepoToList<FsrDbContext, VirtualSafeDetailsModel, Guid>,
    IRepoGetterById<FsrDbContext, VirtualSafeDetailsModel, Guid>,
    IRepoAdder<FsrDbContext, VirtualSafeDetailsModel, Guid>,
    IRepoUpdater<FsrDbContext, VirtualSafeDetailsModel, Guid>,
    IRepoRemover<FsrDbContext, VirtualSafeDetailsModel, Guid>,
    IRepoRemoverById<FsrDbContext, VirtualSafeDetailsModel, Guid>
{

}
