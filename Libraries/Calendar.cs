using Jolia.Core.Extensions;
using Jolia.Core.Resources;
using System;
using static Jolia.Core.Enums;

namespace Jolia.Core.Libraries
{
    public static class Calendar
    {
        public static DateTime StartOfWeek(DateTime date, DayOfWeek startOfWeek)
        {
            int diff = (7 + (date.DayOfWeek - startOfWeek)) % 7;
            return date.AddDays(-1 * diff).Date;
        }

        public static double GetAge(DateTime date)
        {
            return (Application.Now - date).TotalDays;
        }

        public static double GetRemainingDays(DateTime date)
        {
            return (date.Date - Application.Now.Date).TotalDays;
        }

        public static int GetMonthDifference(DateTime startDate, DateTime endDate)
        {
            int monthsApart = 12 * (startDate.Year - endDate.Year) + startDate.Month - endDate.Month;
            return Math.Abs(monthsApart);
        }

        public static string LongDateString(DateTime date)
        {
            return date.ToString("yyyy-MM-dd hh:mm tt");
        }

        public static string ShortTimeString(DateTime date)
        {
            return date.ToString("hh:mm tt");
        }

        public static string ShortDateString(DateTime date)
        {
            return date.ToString("yyyy-MM-dd");
        }

        // TODO: GetEnglishRelativeDate
        public static string GetEnglishRelativeDate(DateTime myDate)
        {
            const int SECOND = 1;
            const int MINUTE = 60 * SECOND;
            const int HOUR = 60 * MINUTE;
            const int DAY = 24 * HOUR;
            const int MONTH = 30 * DAY;

            var ts = new TimeSpan(DateTime.UtcNow.Ticks - myDate.Ticks);
            double delta = Math.Abs(ts.TotalSeconds);

            if (delta < 1 * MINUTE)
                return ts.Seconds == 1 ? "one second ago" : ts.Seconds + " seconds ago";

            if (delta < 2 * MINUTE)
                return "a minute ago";

            if (delta < 45 * MINUTE)
                return ts.Minutes + " minutes ago";

            if (delta < 90 * MINUTE)
                return "an hour ago";

            if (delta < 24 * HOUR)
                return ts.Hours + " hours ago";

            if (delta < 48 * HOUR)
                return "yesterday";

            if (delta < 30 * DAY)
                return ts.Days + " days ago";

            if (delta < 12 * MONTH)
            {
                int months = Convert.ToInt32(Math.Floor((double)ts.Days / 30));
                return months <= 1 ? "one month ago" : months + " months ago";
            }
            else
            {
                int years = Convert.ToInt32(Math.Floor((double)ts.Days / 365));
                return years <= 1 ? "one year ago" : years + " years ago";
            }
        }

        public static string GetRelative(DateTime date)
        {
            if (date == null)
            {
                return "";
            }

            var now = Application.Now;

            var dateDif = now - date;
            long month = GetMonthDifference(now, date);
            long year = month / 12;
            if (year > 0)
            {
                month %= 12;
                return GetDateString(year, month, RCalendar.Year, RCalendar.Month);
            }

            long week = (long)((now - date).TotalDays / 7);
            if (month > 0 && dateDif.TotalDays >= 30)
            {
                week = (long)((now.AddMonths((int)-month) - date).TotalDays / 7);
                return GetDateString(month, week, RCalendar.Month, RCalendar.Week);
            }
            long day = (long)(now - date).TotalDays;
            if (week > 0)
            {
                day = (long)(now.AddDays(-week * 7) - date).TotalDays;
                return GetDateString(week, day, RCalendar.Week, RCalendar.Day);
            }
            long hour = (long)(now - date).TotalHours;
            if (day > 0)
            {
                hour = (long)(now.AddDays(-day) - date).TotalHours;
                return GetDateString(day, hour, RCalendar.Day, RCalendar.Hour);
            }
            long min = (long)(now - date).TotalMinutes;
            if (hour > 0)
            { 
                min = (long)(now.AddHours((int)-hour) - date).TotalMinutes;
                return GetDateString(hour, min, RCalendar.Hour, RCalendar.Minute);
            }

            if (min == 0)
            {
                return RGlobal.Now;
            }
            else
            {
                return string.Format(RCalendar.Since + " {0} {1}", min, RCalendar.Minute);
            }
        }

        public static string DayToString(DayOfWeek weekDay) => GetDay(weekDay).ToDisplayName();

        public static string MonthToString(int Month) => GetMonth(Month).ToDisplayName();

        public static Days GetDay(DayOfWeek weekDay)
        {
            switch (weekDay)
            {
                case DayOfWeek.Sunday:
                    return Days.Sunday;
                case DayOfWeek.Monday:
                    return Days.Monday;
                case DayOfWeek.Tuesday:
                    return Days.Tuesday;
                case DayOfWeek.Wednesday:
                    return Days.Wednesday;
                case DayOfWeek.Thursday:
                    return Days.Thursday;
                case DayOfWeek.Friday:
                    return Days.Friday;
                case DayOfWeek.Saturday:
                    return Days.Saturday;
                default:
                    return Days.Saturday;
            }
        }

        public static Months GetMonth(int Month)
        {
            switch (Month)
            {
                case 1: return Months.January;
                case 2: return Months.February;
                case 3: return Months.March;
                case 4: return Months.April;
                case 5: return Months.May;
                case 6: return Months.June;
                case 7: return Months.July;
                case 8: return Months.August;
                case 9: return Months.September;
                case 10: return Months.October;
                case 11: return Months.November;
                case 12: return Months.December;
                default: return Months.January;
            }
        }

        private static string GetDateString(long firstPart, long secondPart, string firstPartName, string secondPartName)
        {
            return string.Format(RCalendar.Since + " {0} {1} {2}",
                                    firstPart > 1
                                    ? firstPart.ToString()
                                    : string.Empty,
                                    firstPartName,
                                    secondPart > 0
                                    ? string.Format("{0} {1} {2}",
                                                    RCalendar.And,
                                                    secondPart > 1
                                                    ? secondPart.ToString()
                                                    : string.Empty,
                                                    secondPartName)
                                    : string.Empty
                                    );
        }
    }
}
