using Jolia.Core.Bindings;
using Jolia.Core.Resources;
using System;

namespace Jolia.Core.Extensions
{
    public static class DateExtensions
    {
        public static DateBinding Bind(this DateTime value)
        {
            var relative = Libraries.Calendar.GetRelative(value);
            var shortenRelative = relative;
            if (shortenRelative.Contains($" {RGlobal.And} "))
            {
                var index = shortenRelative.IndexOf($" {RGlobal.And} ");
                shortenRelative = shortenRelative.Substring(0, index);
            }

            return new DateBinding
            {
                Date = value,
                ShortFormat = Libraries.Calendar.ShortDateString(value),
                LongFormat = Libraries.Calendar.LongDateString(value),
                RelativeText = relative,
                DayText = Libraries.Calendar.GetDay(value.DayOfWeek).ToDisplayName(),
                MonthText = Libraries.Calendar.GetMonth(value.Month).ToDisplayName(),
                RemainingDays  = Libraries.Calendar.GetRemainingDays(value),
                ShortenRelativeText = shortenRelative
            };
        }
    }
}