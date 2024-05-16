using FilesSafeReserve.UI.Data.Handlers;
using static FilesSafeReserve.App.Watchers.DriveWatcher;
using static FilesSafeReserve.UI.Data.Handlers.KeyUpHandler;

namespace FilesSafeReserve.UI.Data.Stores;

public class KeyUpStore : IDisposable
{
    private static readonly Dictionary<string, KeyUpEventHandler> dictionary = [];

    public static ExecutableState WithName(string name)
    {
        return new ExecutableState(name);
    }

    public static void Remove(string name)
    {
        if (dictionary.ContainsKey(name)) return;

        KeyUpEvent -= dictionary[name];
        dictionary.Remove(name);
    }

    public static void Remove(Predicate<KeyValuePair<string, KeyUpEventHandler>> predicate)
    {
        if (predicate is not null)
        {
            foreach (var item in dictionary)
            {
                if (predicate(item))
                {
                    KeyUpEvent -= dictionary[item.Key];
                    dictionary.Remove(item.Key);
                }
            }
        }
    }

    public void Dispose() => KeyUpHandler.Dispose();

    public class ExecutableState(string name)
    {
        public string Name { get; set; } = name ?? throw new ArgumentException("Handler name can not be null");

        public bool Exists { get => dictionary.ContainsKey(name); }

        public void Add(KeyUpEventHandler handler)
        {
            if (Exists) return;

            KeyUpEvent += handler;
            dictionary.Add(name, handler);
        }

        public void Remove()
        {
            if (Exists is false) return;

            KeyUpEvent -= dictionary[Name];
            dictionary.Remove(name);
        }
    }
}
