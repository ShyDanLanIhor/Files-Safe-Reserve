using FilesSafeReserve.App.Entities.Results.Basic;
using FilesSafeReserve.Domain.Entities;

namespace FilesSafeReserve.App.Services.IServices;

public interface ISmartphoneService
{
    public ValueResult<List<string>> GetDevicesNames();

    public ResultEntity TransferFiles(string deviceName, ShyDirectoryEntity directory);
}
