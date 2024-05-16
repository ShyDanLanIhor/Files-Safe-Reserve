using FilesSafeReserve.App.Entities.Results.Basic;

namespace FilesSafeReserve.App.Watchers.IWatchers;

public interface IDriveWatcher : IDisposable
{
    public bool IsWatching { get; set; }
    public IEnumerable<DriveType> Types { get; set; }
    public IEnumerable<string> Names { get; set; }
    public IEnumerable<string> VolumesLabels { get; set; }
    public int Delay { get; set; }

    public Task<ResultEntity> StartAsync();

    public Task<ResultEntity> StopAsync();

    public Task<ResultEntity> EnsureStartedAsync();

    public Task<ResultEntity> EnsureStoppedAsync();
}
