using HomeFixService.WebService.Models.EntityFramework;
using System;
using System.Collections.Generic;

namespace HomeFixService.WebService.Services.Helpers
{
    interface ScheduleHelper
    {
        TimeSchedules AddWorkingInterval(
            int userId,
            DayOfWeek workingDay,
            TimeSpan startTime,
            TimeSpan endTime
            );

        TimeSchedules UpdateWokingInterval(
            int userId,
            int scheduleId,
            DayOfWeek workingDay,
            TimeSpan startTime,
            TimeSpan endTime
            );

        List<TimeSchedules> GetAllWorkingIntervalForUser(
            int userId
            );

        bool RemoveUserWorkingInterval(
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

        BusySchedules UpdateUserInterval(
            int userId,
            int scheduleId,
            DateTime startOn,
            DateTime endsOn
            );

         bool RemoveUserBusyInterval(
            int userId,
            int scheduleId
            );
    }
}
