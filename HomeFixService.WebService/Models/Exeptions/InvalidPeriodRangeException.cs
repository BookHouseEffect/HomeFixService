using System;

namespace HomeFixService.WebService.Models.Exeptions
{
    public class InvalidPeriodRangeException : Exception
    {
        public DateTime Start { get; }
        public DateTime Ends { get; }

        public InvalidPeriodRangeException(DateTime start, DateTime ends) 
            : base(String.Format("Invalid period range. The period range can not start on: {0} and ends on {1}.",
                start.ToString(), ends.ToString()))
        {
            this.Start = start;
            this.Ends = ends;
        }
    }
}