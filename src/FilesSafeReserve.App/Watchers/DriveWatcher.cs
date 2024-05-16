using FilesSafeReserve.App.Entities.Results.Basic;
using FilesSafeReserve.App.Watchers.IWatchers;

namespace FilesSafeReserve.App.Watchers;

public class DriveWatcher : IDriveWatcher, IDisposable
{
    public delegate Task DrivesChangedEventHandler(ICollection<DriveInfo> drives);

    private readonly CancellationTokenSource cancellationTokenSource = new();

    private DriveInfo[] prevDrives = [];

    public event DrivesChangedEventHandler? DrivesChanged;

    private bool _isWatching = false;

    public bool IsWatching 
    { 
        get
        {
            return _isWatching;
        }
        set
        {
            if (_isWatching)
            {
                if (value is false)
                {
                    cancellationTokenSource.Cancel();
                }
            }
            else
            {
                if (value is true)
                {
                    Task.Run(StartWatchingAsync, cancellationTokenSource.Token);
                }
            }
        }
    }

    public IEnumerable<DriveType> Types { get; set; } = [];
    public IEnumerable<string> Names { get; set; } = [];
    public IEnumerable<string> VolumesLabels { get; set; } = [];
    public int Delay { get; set; } = 5000;

    public async Task<ResultEntity> StartAsync()
    {
        if (_isWatching) return false;

        await Task.Run(StartWatchingAsync, cancellationTokenSource.Token);

        return true;
    }

    public async Task<ResultEntity> StopAsync()
    {
        if (!_isWatching) return false;

        await cancellationTokenSource.CancelAsync();

        return true;
    }

    public async Task<ResultEntity> EnsureStartedAsync()
    {
        if (!_isWatching)
        {
            await Task.Run(StartWatchingAsync, cancellationTokenSource.Token);
        }

        return true;
    }

    public async Task<ResultEntity> EnsureStoppedAsync()
    {
        if (_isWatching)
        {
            await cancellationTokenSource.CancelAsync();
        }

        return true;
    }

    private async Task StartWatchingAsync()
    {
        _isWatching = true;

        while (!cancellationTokenSource.IsCancellationRequested)
        {
            await WatchDrivesAsync();

            await Task.Delay(Delay);
        }

        _isWatching = false;
    }

    private async Task WatchDrivesAsync()
    {
        var drives = DriveInfo.GetDrives()
                              .Where(drive => Types.Count() is 0 || Types.Any(type => type == drive.DriveType))
                              .Where(drive => Names.Count() is 0 || Names.Any(name => name == drive.Name))
                              .Where(drive => VolumesLabels.Count() is 0 || VolumesLabels.Any(label => label == drive.VolumeLabel))
                              .ToArray();

        if (    prevDrives.Count() != drives.Count()
            ||  prevDrives.OrderBy(drive => drive.Name)
                          .Zip(drives.OrderBy(drive => drive.Name), 
                          (prevDrive, newDrive) => new
                          {
                              PrevDrive = prevDrive,
                              NewDrive = newDrive,
                          })
                          .Any(pair => pair.PrevDrive.Name != pair.NewDrive.Name
                                    || pair.PrevDrive.VolumeLabel != pair.NewDrive.VolumeLabel
                                    || pair.PrevDrive.DriveType != pair.NewDrive.DriveType
                                    || pair.PrevDrive.DriveFormat != pair.NewDrive.DriveFormat)
            )
        {
            prevDrives = drives;

            if (DrivesChanged is null) return;
            await DrivesChanged.Invoke(drives);
        }
    }

    public void Dispose()
    {
        cancellationTokenSource.Cancel();

        if (DrivesChanged != null)
        {
            foreach (Delegate d in DrivesChanged.GetInvocationList())
            {
                DrivesChanged -= (DrivesChangedEventHandler)d;
            }
        }
    }
}
