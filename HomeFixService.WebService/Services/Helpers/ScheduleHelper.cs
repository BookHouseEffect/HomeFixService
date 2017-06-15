using HomeFixService.WebService.Models.EntityFramework;
using System;
using System.Collections.Generic;

namespace HomeFixService.WebService.Services.Helpers
{
    interface ScheduleHelper
    {
        TimeSchedules AddWorkingInterval(
            int userId,
            DayOfWeek startDay,
            TimeSpan startTime,
            DayOfWeek endDay,
            TimeSpan endTime
            );

        TimeSchedules UpdateWokingInterval(
            int userId,
            int scheduleId,
            DayOfWeek startDay,
            TimeSpan startTime,
            DayOfWeek endDay,
            TimeSpan endTime
            );

        List<TimeSchedules> GetAllWorkingIntervals(
            int userId
            );

        bool RemoveWorkingInterval(
            int userId,
            int scheduleId
            );

        BusySchedules AddBusyInterval(
            int userId,
            DateTime startOn,
            DateTime endsOn
            );

        List<BusySchedules> GetAllBusyIntervalsPerPeriod(
            int userId,
            DateTime periodStarts,
            DateTime periodEnds
            );

        BusySchedules UpdateBusyInterval(
            int userId,
            int scheduleId,
            DateTime startOn,
            DateTime endsOn
            );

         bool RemoveBusyInterval(
            int userId,
            int scheduleId
            );
    }
}
