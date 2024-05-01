using FilesSafeReserve.App.Models;
using FilesSafeReserve.Infra.DataBase;
using FilesSafeReserve.Infra.Interfaces.Repositories;

namespace FilesSafeReserve.Infra.Repositories.IRepositories;

public interface IReservationRepo :
    IRepoToList<FsrDbContext, ReservationModel, Guid>,
    IRepoGetterById<FsrDbContext, ReservationModel, Guid>,
    IRepoAdder<FsrDbContext, ReservationModel, Guid>,
    IRepoUpdater<FsrDbContext, ReservationModel, Guid>,
    IRepoRemover<FsrDbContext, ReservationModel, Guid>,
    IRepoRemoverById<FsrDbContext, ReservationModel, Guid>
{

}
