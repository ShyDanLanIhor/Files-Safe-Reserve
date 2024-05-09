using FilesSafeReserve.App.Models;

namespace FilesSafeReserve.App.Entities;

public class ShortcutEntity
{
    public KeyEntity Key { get; set; } = new();

    public ModifiersGroupEntity Modifiers { get; set; } = new();

    public static bool operator ==(ShortcutEntity a, ShortcutEntity b)
    {
        if (a is null) return false;

        return a.Key == b.Key
            && a.Modifiers == b.Modifiers;
    }

    public static bool operator !=(ShortcutEntity a, ShortcutEntity b) => !(a == b);

    public static bool operator ==(ShortcutEntity a, ShortcutModel b)
    {
        if (a is null) return false;

        return a.Key.Code == b.KeyCode
            && a.Modifiers.Alt == b.AltPressed
            && a.Modifiers.Control == b.ControlPressed
            && a.Modifiers.Shift == b.ShiftPressed
            && a.Modifiers.Meta == b.MetaPressed;
    }

    public static bool operator !=(ShortcutEntity a, ShortcutModel b) => !(a == b);

    public override bool Equals(object? obj)
    {
        if (obj is ShortcutEntity other)
        {
            return this == other;
        }
        return false;
    }

    public override int GetHashCode() => HashCode.Combine(Key, Modifiers);

    public class KeyEntity
    {
        public int Code { get; set; }
        public string Value { get; set; } = string.Empty;

        public static bool operator ==(KeyEntity a, KeyEntity b)
        {
            if (a is null) return false;

            return a.Code == b.Code;
        }

        public static bool operator !=(KeyEntity a, KeyEntity b) => !(a == b);

        public override bool Equals(object? obj)
        {
            if (obj is KeyEntity other)
            {
                return this == other;
            }
            return false;
        }

        public override int GetHashCode() => HashCode.Combine(Code);
    }

    public class ModifiersGroupEntity
    {
        public ModifierEntity Shift { get; set; } = new();
        public ModifierEntity Control { get; set; } = new();
        public ModifierEntity Meta { get; set; } = new();
        public ModifierEntity Alt { get; set; } = new();

        public static bool operator ==(ModifiersGroupEntity a, ModifiersGroupEntity b)
        {
            if (a is null) return false;

            return a.Shift == b.Shift
                && a.Control == b.Control
                && a.Meta == b.Meta
                && a.Alt == b.Alt;
        }

        public static bool operator !=(ModifiersGroupEntity a, ModifiersGroupEntity b) => !(a == b);
        public override bool Equals(object? obj)
        {
            if (obj is ModifiersGroupEntity other)
            {
                return this == other;
            }
            return false;
        }

        public override int GetHashCode() => HashCode.Combine(Shift, Control, Meta, Alt);

        public class ModifierEntity
        {
            private bool _isPressed = false;

            public bool IsPressed
            {
                get => _isPressed;
                set => _isPressed = value;
            }

            public static bool operator ==(ModifierEntity a, ModifierEntity b)
            {
                if (a is null) return false;

                return a.IsPressed == b.IsPressed;
            }

            public static bool operator !=(ModifierEntity a, ModifierEntity b) => !(a == b);

            public override bool Equals(object? obj)
            {
                if (obj is ModifierEntity other)
                {
                    return this == other;
                }
                return false;
            }

            public override int GetHashCode() => HashCode.Combine(IsPressed);

            public static explicit operator bool(ModifierEntity modifier) => modifier.IsPressed;

            public static implicit operator ModifierEntity(bool value)
                => new() { IsPressed = value };
        }
    }
}
