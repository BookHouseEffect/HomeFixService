using System;
using System.ComponentModel.DataAnnotations;

namespace HomeFixService.WebService.Models.Api
{
    public class TimeModel {

        protected const int OneDayInMinutes = 1440;

        [Required]
        [Range(minimum: -12, maximum: +14)]
        public int UtcHours { get; set; }

        [Required]
        [Range(minimum: 0, maximum: 45)]
        public int UtcMinutes { get; set; }

        [Required]
        [Range(minimum: 0, maximum: 23)]
        public int StartHours { get; set; }

        [Required]
        [Range(minimum: 0, maximum: 23)]
        public int EndHours { get; set; }

        [Required]
        [Range(minimum: 0, maximum: 59)]
        public int StartMinutes { get; set; }

        [Required]
        [Range(minimum: 0, maximum: 59)]
        public int EndMinutes { get; set; }

        protected int GetUtcTimeInMinutes()
        {
            return this.UtcHours * 60 + (this.UtcHours < 0 ? -1 : 1) * this.UtcMinutes;
        }

        protected int GetStartTimeInMinutes()
        {
            int utcTime = this.GetUtcTimeInMinutes();
            int startTime = this.StartHours * 60 + this.StartMinutes;
            return startTime - utcTime;
        }

        protected int GetEndTimeInMinutes()
        {
            int utcTime = this.GetUtcTimeInMinutes();
            int endTime = this.EndHours * 60 + this.EndMinutes;
            return endTime - utcTime;
        }

        public TimeSpan GetUtcStartTimeSpan()
        {
            int coordinatedTime = this.GetStartTimeInMinutes();

            if (coordinatedTime < 0)
                return TimeSpan.FromMinutes(coordinatedTime + OneDayInMinutes);

            if (coordinatedTime > OneDayInMinutes)
                return TimeSpan.FromMinutes(coordinatedTime - OneDayInMinutes);

            return TimeSpan.FromMinutes(coordinatedTime);
        }

        public TimeSpan GetUtcEndTimeSpan()
        {
            int coordinatedTime = this.GetEndTimeInMinutes();

            if (coordinatedTime < 0)
                return TimeSpan.FromMinutes(coordinatedTime + OneDayInMinutes);

            if (coordinatedTime > OneDayInMinutes)
                return TimeSpan.FromMinutes(coordinatedTime - OneDayInMinutes);

            return TimeSpan.FromMinutes(coordinatedTime);
        }
    }

    public class DayTimeModel : TimeModel
    {

        [Required]
        public DayOfWeek StartDay { get; set; }

        [Required]
        public DayOfWeek EndDay { get; set; }

        private DayOfWeek GetPreviousDay(DayOfWeek day)
        {
            if (day == (DayOfWeek)0)
                return (DayOfWeek)6;

            return (DayOfWeek)(day - 1);
        }

        private DayOfWeek GetNextDay(DayOfWeek day)
        {
            if (day == (DayOfWeek)6)
                return (DayOfWeek)0;

            return (DayOfWeek)(day + 1);
        }

        public DayOfWeek GetUtcStartDay()
        {
            int coordinatedTime = this.GetStartTimeInMinutes();

            if (coordinatedTime < 0)
                return GetPreviousDay(this.StartDay);

            if (coordinatedTime > OneDayInMinutes)
                return GetNextDay(this.StartDay);

            return this.StartDay;
        }

        public DayOfWeek GetUtcEndtDay()
        {
            int coordinatedTime = this.GetEndTimeInMinutes();

            if (coordinatedTime < 0)
                return GetPreviousDay(this.EndDay);

            if (coordinatedTime > OneDayInMinutes)
                return GetNextDay(this.EndDay);

            return this.EndDay;
        }
    }

    public class DateTimeModel : TimeModel
    {
        [Required]
        [Range(minimum: 1, maximum: 9999)]
        public int StartYear { get; set; }

        [Required]
        [Range(minimum: 1, maximum: 9999)]
        public int EndYear { get; set; }

        [Required]
        [Range(minimum:1, maximum:12)]
        public int StartMonth { get; set; }

        [Required]
        [Range(minimum: 1, maximum: 12)]
        public int EndMonth { get; set; }

        [Required]
        [Range(minimum:1, maximum:31)]
        public int StartDay { get; set; }

        [Required]
        [Range(minimum: 1, maximum: 31)]
        public int EndDay { get; set; }

        private bool IsLapYear(int year)
        {
            if (year % 400 == 0
                || year % 4 == 0 && year % 100 != 0)
                return true;
            return false;
        }

        private int GetDaysInMonth(int month, int year)
        {
            int days = 0;

            switch (month)
            {
                case 1:
                case 3:
                case 5:
                case 7:
                case 8:
                case 10:
                case 12:
                    days = 31;
                    break;

                case 4:
                case 6:
                case 9:
                case 11:
                    days = 30;
                    break;

                case 2:
                    days = IsLapYear(year) ? 29 : 28;
                    break;
            }

            return days;
        }

        public DateTime GetStartDateTime()
        {
            TimeSpan startTime = this.GetUtcStartTimeSpan();

            int coordinatedTime = this.GetStartTimeInMinutes();
            int changeDay = coordinatedTime < 0 ? -1 : coordinatedTime > OneDayInMinutes ? 1 : 0;
            int changeMonth = this.StartDay + changeDay <= 0 ? -1 :
                this.StartDay + changeDay > this.GetDaysInMonth(StartMonth, StartYear) ? 1 : 0;
            int changeYear = this.StartMonth + changeMonth <= 0 ? -1 :
                this.StartMonth + changeMonth > 12 ? 1 : 0;

            int newYear = this.StartYear + changeYear;
            int newMonth = (this.StartMonth - 1 + changeMonth + 12) % 12 + 1;
            int daysInNewMonth = this.GetDaysInMonth(newMonth, newYear);
            int newDay = (this.StartDay - 1 + changeDay + daysInNewMonth) % daysInNewMonth + 1;

            return new DateTime(
                newYear,
                newMonth,
                newDay,
                startTime.Hours,
                startTime.Minutes,
                startTime.Seconds);
        }

        public DateTime GetEndDateTime()
        {
            TimeSpan endTime = this.GetUtcEndTimeSpan();

            int coordinatedTime = this.GetEndTimeInMinutes();
            int changeDay = coordinatedTime < 0 ? -1 : coordinatedTime > OneDayInMinutes ? 1 : 0;
            int changeMonth = this.EndDay + changeDay <= 0 ? -1 :
                this.EndDay + changeDay > this.GetDaysInMonth(EndMonth, EndYear) ? 1 : 0;
            int changeYear = this.EndMonth + changeMonth <= 0 ? -1 :
                this.EndMonth + changeMonth > 12 ? 1 : 0;

            int newYear = this.EndYear + changeYear;
            int newMonth = (this.EndMonth  - 1 + changeMonth + 12) % 12 + 1;
            int daysInNewMonth = this.GetDaysInMonth(newMonth, newYear);
            int newDay = (this.EndDay - 1 + changeDay + daysInNewMonth) % daysInNewMonth + 1;

            return new DateTime(
                newYear,
                newMonth,
                newDay,
                endTime.Hours,
                endTime.Minutes,
                endTime.Seconds);
        }
    }
}