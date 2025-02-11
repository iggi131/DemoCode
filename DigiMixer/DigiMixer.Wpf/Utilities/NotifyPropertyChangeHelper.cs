﻿using System.ComponentModel;

namespace DigiMixer.Wpf.Utilities;

public static class NotifyPropertyChangedHelper
{
    /// <summary>
    /// Adds a handler, returning whether or not this has caused the underlying handler
    /// to go from "unsubscribed" to "subscribed".
    /// </summary>
    /// <param name="value">The handler to add.</param>
    /// <returns>true if there were previously no handlers, but now there's at least one; false otherwise.</returns>
    public static bool AddHandler(ref PropertyChangedEventHandler field, PropertyChangedEventHandler value)
    {
        if (value is null)
        {
            return false;
        }
        // TODO: Make this thread-safe.
        bool ret = field is null;
        field += value;
        return ret;
    }

    /// <summary>
    /// Adds a handler, returning whether or not this has caused the underlying handler
    /// to go from "subscribed" to "unsubscribed".
    /// </summary>
    /// <param name="value">The handler to add.</param>
    /// <returns>true if there were previously no handlers, but now there's at least one; false otherwise.</returns>
    public static bool RemoveHandler(ref PropertyChangedEventHandler field, PropertyChangedEventHandler value)
    {
        if (value is null || field is null)
        {
            return false;
        }
        field -= value;
        return field is null;
    }
}
