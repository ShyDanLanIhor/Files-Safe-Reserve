using FilesSafeReserve.Data.DataBase;
using FilesSafeReserve.Data.Interfaces.Repositories;
using FilesSafeReserve.Data.Models;

namespace FilesSafeReserve.Data.Repositories.IRepositories;

public interface IReservationRepo :
    IRepoToList<FsrDbContext, ReservationModel, Guid>,
    IRepoGetterById<FsrDbContext, ReservationModel, Guid>,
    IRepoAdder<FsrDbContext, ReservationModel, Guid>,
    IRepoUpdater<FsrDbContext, ReservationModel, Guid>,
    IRepoRemover<FsrDbContext, ReservationModel, Guid>,
    IRepoRemoverById<FsrDbContext, ReservationModel, Guid>
{

}
