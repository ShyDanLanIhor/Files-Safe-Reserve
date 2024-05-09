using FilesSafeReserve.App.Entities.Results.Basic;

namespace FilesSafeReserve.UI.Data.Managers.IManagers;

public interface IKeyUpManager
{
    public IListenerEntity Listener { get; set; }

    public interface IListenerEntity
    {
        public bool IsListening { get; set; }

        public Task<ResultEntity> StartAsync();

        public Task<ResultEntity> StopAsync();

        public Task<ResultEntity> ToggleAsync();

        public Task<ResultEntity> EnsureStartedAsync();

        public Task<ResultEntity> EnsureStoppedAsync();
    }
}
