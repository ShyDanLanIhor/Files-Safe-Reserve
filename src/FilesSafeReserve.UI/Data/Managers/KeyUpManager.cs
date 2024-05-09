using FilesSafeReserve.App.Entities.Results.Basic;
using FilesSafeReserve.UI.Data.Managers.IManagers;
using Microsoft.JSInterop;
using static FilesSafeReserve.UI.Data.Managers.IManagers.IKeyUpManager;

namespace FilesSafeReserve.UI.Data.Managers;

public class KeyUpManager(IJSRuntime js) : IKeyUpManager
{
    IListenerEntity IKeyUpManager.Listener { get; set; } = new ListenerEntity(js);

    public class ListenerEntity(IJSRuntime js) : IListenerEntity
    {
        public bool IsListening { get; set; }

        async Task<ResultEntity> IListenerEntity.EnsureStartedAsync()
        {
            if (!IsListening)
                await js.InvokeVoidAsync("startKeyListener");

            IsListening = true;

            return true;
        }

        async Task<ResultEntity> IListenerEntity.EnsureStoppedAsync()
        {
            if (IsListening)
                await js.InvokeVoidAsync("stopKeyListener");

            IsListening = false;

            return true;
        }

        async Task<ResultEntity> IListenerEntity.StartAsync()
        {
            if (IsListening) return false;

            await js.InvokeVoidAsync("startKeyListener");

            IsListening = true;

            return true;
        }

        async Task<ResultEntity> IListenerEntity.StopAsync()
        {
            if (IsListening is false) return false;

            await js.InvokeVoidAsync("stopKeyListener");

            IsListening = false;

            return true;
        }

        async Task<ResultEntity> IListenerEntity.ToggleAsync()
        {
            IsListening = !IsListening;

            if (IsListening)
                await js.InvokeVoidAsync("stopKeyListener");
            else
                await js.InvokeVoidAsync("startKeyListener");

            return true;
        }
    }
}
