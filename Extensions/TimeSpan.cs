using System;

namespace Jolia.Core.Extensions
{
    public static class TimeSpanExtensions
    {
        public static string ToAMPM(this TimeSpan Time)
        {
            return string.Format("{0:hh\\:mm tt}", DateTime.Today.Add(Time))
                .Replace("ص", "AM").Replace("م", "PM");
        }

        public static string ToAMPM(this TimeSpan? Time)
        {
            return Time.HasValue ? string.Format("{0:hh\\:mm tt}", DateTime.Today.Add(Time.Value))
                .Replace("ص", "AM").Replace("م", "PM") : "";
        }
    }
}