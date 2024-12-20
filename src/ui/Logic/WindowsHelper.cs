﻿using System.Diagnostics;
using Nikse.SubtitleEdit.Core.Common;

namespace Nikse.SubtitleEdit.Logic
{
    internal static class WindowsHelper
    {
        private static long _lastCall;

        internal static void PreventStandBy()
        {
            if (!Configuration.IsRunningOnWindows)
            {
                return;
            }

            if (Stopwatch.GetTimestamp() - _lastCall > 10_000_000 * 60) // one minute
            {
                NativeMethods.SetThreadExecutionState(NativeMethods.ES_CONTINUOUS | NativeMethods.ES_SYSTEM_REQUIRED);
                _lastCall = Stopwatch.GetTimestamp();
            }
        }
    }
}
