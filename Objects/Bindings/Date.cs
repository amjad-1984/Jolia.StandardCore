using System;

namespace Jolia.Core.Bindings
{
    public class DateBinding : Transferable
    {
        public DateTime Date { get; set; }
        public string ShortFormat { get; set; }
        public string LongFormat { get; set; }
        public string RelativeText { get; set; }
        public string ShortenRelativeText { get; set; }
        public string DayText { get; set; }
        public string MonthText { get; set; }
        public double RemainingDays { get; set; }
    }
}