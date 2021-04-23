using System;

namespace Jolia.Core.Bindings
{
    public class PeriodBinding : Transferable
    {
        public string Name { get; set; }
        public TimeSpan Start { get; set; }
        public TimeSpan End { get; set; }

        public TimeSpan Total => End - Start;
        public bool HasPeriod => Total.TotalMilliseconds != 0;
        public string Text => "من " + Start.ToString("hh\\:mm")
            + " إلى " + End.ToString("hh\\:mm");

        public string NameWithText => Name + ": " + Text;

        public bool CheckDate(System.DateTime date) => 
           HasPeriod && date.TimeOfDay >= Start && date.TimeOfDay <= End;
    }
}
