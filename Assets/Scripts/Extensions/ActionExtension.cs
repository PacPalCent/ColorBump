using System;

namespace Extensions
{
    public static class ActionExtension
    {
        public static void Call(this Action action)
        {
            if (action != null)
            {
                action();
            }
        }

        public static void Call<T>(this Action<T> action, T value)
        {
            if (action != null)
            {
                action(value);
            }
        }
    }
}