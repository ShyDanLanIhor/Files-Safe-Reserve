using FilesSafeReserve.App.Entities.Results.Basic;
using FilesSafeReserve.App.Services.IServices;
using FilesSafeReserve.Domain.Entities;
using System.Runtime.InteropServices;
using System.Runtime.Versioning;
using MediaDevices;

namespace FilesSafeReserve.Infra.Services;

public class SmartphoneService : ISmartphoneService
{
    public ValueResult<List<string>> GetDevicesNames()
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            var result = GetDevicesNamesWindows();

            if (result.IsSucceeded is not true) return new();

            return result;
        }
        else
        {
            throw new NotImplementedException("");
        }
    }

    public ResultEntity TransferFiles(string deviceName, ShyDirectoryEntity directory)
    {
        if (RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
        {
            return TransferFilesWindows(deviceName, directory);
        }
        else
        {
            throw new NotImplementedException();
        }
    }

    [SupportedOSPlatform("windows")]
    private static ResultEntity TransferFilesWindows(string deviceName, ShyDirectoryEntity directory)
    {
        try
        {
            var device = MediaDevice.GetDevices().FirstOrDefault(el => el.FriendlyName == deviceName);

            if (device == null) return false;

            device.Connect();

            var photoDir = device.GetDirectoryInfo(@"\Internal shared storage\DCIM\Camera");
            var files = photoDir.EnumerateFiles("*.*", SearchOption.TopDirectoryOnly);

            foreach (var file in files)
            {
                if (directory.Exists)
                {
                    var subdirectory = directory.Info.CreateSubdirectory($"{deviceName} Reservation");
                    using FileStream fs = new($@"{subdirectory.FullName}\{file.Name}", FileMode.Create, FileAccess.Write);
                    device.DownloadFile(file.FullName, fs);
                }
            }
            device.Disconnect();

            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    [SupportedOSPlatform("windows")]
    private static ValueResult<List<string>> GetDevicesNamesWindows()
    {
        List<string> names = [];

        var devices = MediaDevice.GetDevices();
        foreach (var device in devices)
        {
            device.Connect();

            if (device.PowerSource is PowerSource.Battery)
                names.Add(device.FriendlyName);

            device.Disconnect();
        }

        return names;
    }
}
