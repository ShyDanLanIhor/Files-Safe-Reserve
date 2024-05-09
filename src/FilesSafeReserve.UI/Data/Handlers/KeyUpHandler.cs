using FilesSafeReserve.App.Entities;
using Microsoft.JSInterop;

namespace FilesSafeReserve.UI.Data.Handlers;

public static class KeyUpHandler
{
    public delegate Task KeyUpEventHandler(ShortcutEntity shortcut);

    public static event KeyUpEventHandler? KeyUpEvent;

    [JSInvokable]
    public static Task HandleKeyUp(ShortcutEntity shortcut)
    {
        if (KeyUpEvent is null) return Task.CompletedTask;

        KeyUpEvent.Invoke(shortcut);

        return Task.CompletedTask;
    }
}
