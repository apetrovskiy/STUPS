namespace Tmx.Interfaces.ExtensionMethods
{
    using System;

    public static class ExtensionMethods
    {
        public static string GetTimeTaken(this DateTime finishTime, DateTime startTime)
        {
            TimeSpan resultSpan;
            if (DateTime.MinValue == startTime)
                return string.Format("{0:00}:{1:00}:{2:00}", 0, 0, 0);
            if (DateTime.MinValue < finishTime)
                resultSpan = finishTime - startTime;
            else
                resultSpan = DateTime.Now - startTime;
            return string.Format("{0:00}:{1:00}:{2:00}", (int)resultSpan.TotalHours % 60, (int)resultSpan.TotalMinutes % 60, (int)resultSpan.TotalSeconds % 60);
        }
    }
}