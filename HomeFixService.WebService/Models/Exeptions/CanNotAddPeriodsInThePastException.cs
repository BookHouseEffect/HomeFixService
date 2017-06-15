using System;

namespace HomeFixService.WebService.Models.Exeptions
{
    public class CanNotAddPeriodsInThePastException : Exception
    {
        DateTime Starts { get; }
        DateTime Ends { get; }

        public CanNotAddPeriodsInThePastException(DateTime start, DateTime ends) : 
            base(String.Format(
                "The interval ({0} - {1}) is before current time {2}, and can not be added.",
                ends.ToString("s"),
                start.ToString("s"),
                DateTime.UtcNow.ToString("s")
                ))
        {
            this.Starts = start;
            this.Ends = ends;
        }
    }
}