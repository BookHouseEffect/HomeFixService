using HomeFixService.WebService.Services.Helpers;
using System;
using System.Collections.Generic;
using HomeFixService.WebService.Models.EntityFramework;
using HomeFixService.WebService.Persistence.Implementations;
using HomeFixService.WebService.Models.Exeptions;
using System.Linq;

namespace HomeFixService.WebService.Services.Implementations
{
    public class ScheduleService : BaseService, ScheduleHelper
    {
        private const int MinutesInOneDay = 1440;
        private const int MinutesInOneWeek = 10080;

        private TimeScheduleRepository TimeScheduleRepository;
        private BusyScheduleRepository BusyScheduleRepository;

        public ScheduleService(): base()
        {
            this.TimeScheduleRepository = new TimeScheduleRepository(
                 UsersRepository.GetExistingDatabaseContext());
            this.BusyScheduleRepository = new BusyScheduleRepository(
                UsersRepository.GetExistingDatabaseContext());
        }

        private int GetMinRange(TimeSchedules schedule)
        {
            return (int)schedule.StartDay * MinutesInOneDay + (int)schedule.StartTime.TotalMinutes;
        }

        private int GetMaxRange(TimeSchedules schedule)
        {
            return (int)schedule.EndDay * MinutesInOneDay + (int)schedule.EndTime.TotalMinutes;
        }

        private List<TimeSchedules> GetOverlappedSchedule(TimeSchedules currentSchedule ,List<TimeSchedules> schedules)
        {
            int minRange = GetMinRange(currentSchedule);
            int maxRange = GetMaxRange(currentSchedule);

            if (maxRange < minRange)
                maxRange += MinutesInOneWeek;

            List<TimeSchedules> overlapped = new List<TimeSchedules>();
            foreach (var sch in schedules)
            {
                if (currentSchedule.Id == sch.Id)
                    continue;

                int schMin = GetMinRange(sch);
                int schMax = GetMaxRange(sch);

                if (schMax < schMin)
                    schMax += MinutesInOneWeek;

                bool predicate =
                       minRange <= schMin && maxRange >= schMax     // goes out of the boundaries in boths way
                    || minRange >= schMin && maxRange <= schMax     // goes inside the boundaries both ways
                    || minRange >= schMin && minRange <= schMax     // left side goes inside
                    || maxRange >= schMin && maxRange <= schMax;    // right side goes inside

                if (predicate) overlapped.Add(sch);
            }

            return overlapped;
        }

        private TimeSchedules SolveOverlappedSchedules(TimeSchedules currentSchedule, List<TimeSchedules> schedules)
        {
            int minRange = GetMinRange(currentSchedule);
            int maxRange = GetMaxRange(currentSchedule);

            if (maxRange < minRange)
                maxRange += MinutesInOneWeek;

            foreach (var sch in schedules)
            {
                int schMin = GetMinRange(sch);
                int schMax = GetMaxRange(sch);

                if (schMax < schMin)
                    schMax += MinutesInOneWeek;

                if (schMin < minRange)
                    minRange = schMin;

                if (schMax > maxRange)
                    maxRange = schMax;
            }

            maxRange %= MinutesInOneWeek;

            TimeSchedules solvedSchedule = new TimeSchedules
            {
                StartDay = (DayOfWeek)(minRange / MinutesInOneDay),
                StartTime = TimeSpan.FromMinutes(minRange % MinutesInOneDay),
                EndDay = (DayOfWeek)(maxRange / MinutesInOneDay),
                EndTime = TimeSpan.FromMinutes(maxRange % MinutesInOneDay)
            };

            return solvedSchedule;
        }

        private BusySchedules SolveOverlappedSchedules(BusySchedules currentSchedule, List<BusySchedules> schedules)
        {
            DateTime minDateTime = currentSchedule.BusyPeriodStartOn;
            DateTime maxDateTime = currentSchedule.BusyPeriodEndsOn;

            foreach (var sch in schedules)
            {
                if (sch.BusyPeriodStartOn.CompareTo(minDateTime) < 0)
                    minDateTime = sch.BusyPeriodStartOn;

                if (sch.BusyPeriodEndsOn.CompareTo(maxDateTime) > 0)
                    maxDateTime = sch.BusyPeriodEndsOn;
            }

            return new BusySchedules {
                BusyPeriodStartOn = minDateTime,
                BusyPeriodEndsOn = maxDateTime
            };
        }

        public BusySchedules AddBusyInterval(int userId, DateTime startOn, DateTime endsOn)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            if (startOn.CompareTo(endsOn) >= 0)
                throw new InvalidPeriodRangeException(startOn, endsOn);

            DateTime current = DateTime.UtcNow;
            if (endsOn.CompareTo(current) <= 0)
                throw new CanNotAddPeriodsInThePastException(startOn, endsOn);

            DateTime real = startOn.CompareTo(current) <= 0 ? current : startOn;

            BusySchedules newSchedule = new BusySchedules
            {
                UserId = user.Id,
                BusyPeriodStartOn = real,
                BusyPeriodEndsOn = endsOn
            };

            List<BusySchedules> existingSchedules = BusyScheduleRepository.GetAllInPeriod(user.Id, real, endsOn);

            if (existingSchedules.Count == 0)
            {
                BusyScheduleRepository.Add(newSchedule);
                return newSchedule;
            }

            newSchedule = SolveOverlappedSchedules(newSchedule, existingSchedules);
            bool added = false;

            foreach (var sch in existingSchedules)
            {
                if (!added && sch.BusyPeriodStartOn.CompareTo(newSchedule.BusyPeriodStartOn) == 0 )
                {
                    sch.BusyPeriodStartOn = newSchedule.BusyPeriodStartOn;
                    sch.BusyPeriodEndsOn = newSchedule.BusyPeriodEndsOn;
                    BusyScheduleRepository.Update(sch);
                    added = true;
                    newSchedule = sch;
                } else 
                    BusyScheduleRepository.Remove(sch);
            }

            return newSchedule;
        }

        public TimeSchedules AddWorkingInterval(int userId, DayOfWeek startDay, TimeSpan startTime, DayOfWeek endDay, TimeSpan endTime)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            TimeSchedules schedule = new TimeSchedules
            {
                UserId = user.Id,
                StartDay = startDay,
                StartTime = startTime,
                EndDay = endDay,
                EndTime = endTime
            };

            List<TimeSchedules> overlapping = GetOverlappedSchedule(schedule, user.TheTimeScheduleForThisUser);

            if (overlapping.Count == 0)
            {
                TimeScheduleRepository.Add(schedule);
                return schedule;
            }

            TimeSchedules newSchedule = SolveOverlappedSchedules(schedule, overlapping);

            newSchedule.UserId = user.Id;
            TimeScheduleRepository.Add(newSchedule);

            foreach (var sch in overlapping)
                TimeScheduleRepository.Remove(sch);

            return newSchedule;
        }

        public List<BusySchedules> GetAllBusyIntervalsPerPeriod(int userId, DateTime periodStarts, DateTime periodEnds)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            return BusyScheduleRepository.GetAllInPeriod(user.Id, periodStarts, periodEnds);
        }

        public List<TimeSchedules> GetAllWorkingIntervals(int userId)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            return user.TheTimeScheduleForThisUser;
        }

        public bool RemoveBusyInterval(int userId, int scheduleId)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            BusySchedules existing = BusyScheduleRepository.FindByIdAndUserId(scheduleId, user.Id);
            if (existing == null)
                throw new NoEntryFoundException(scheduleId, userId, typeof(BusySchedules).Name);

            BusyScheduleRepository.Remove(existing);
            return true;
        }

        public bool RemoveWorkingInterval(int userId, int scheduleId)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            TimeSchedules existing = TimeScheduleRepository.FindByIdAndUserId(scheduleId, user.Id);
            if (existing == null)
                throw new NoEntryFoundException(scheduleId, userId, typeof(TimeSchedules).Name);

            TimeScheduleRepository.Remove(existing);
            return true;
        }

        public BusySchedules UpdateBusyInterval(int userId, int scheduleId, DateTime startOn, DateTime endsOn)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            if (startOn.CompareTo(endsOn) >= 0)
                throw new InvalidPeriodRangeException(startOn, endsOn);

            DateTime current = DateTime.UtcNow;
            if (endsOn.CompareTo(current) <= 0)
                throw new CanNotAddPeriodsInThePastException(startOn, endsOn);

            DateTime real = startOn.CompareTo(current) <= 0 ? current : startOn;

            List<BusySchedules> existingSchedules = BusyScheduleRepository.GetAllInPeriod(user.Id, real, endsOn);
            BusySchedules existing = null;
            
            if (existingSchedules.Count != 0)
                existing = existingSchedules.Where(x => x.Id == scheduleId).SingleOrDefault();

            if (existing == null)
                existing = BusyScheduleRepository.FindByIdAndUserId(scheduleId, user.Id);

            if (existing == null)
                throw new NoEntryFoundException(scheduleId, userId, typeof(BusySchedules).Name);

            existing.BusyPeriodStartOn = real;
            existing.BusyPeriodEndsOn = endsOn;

            if (existingSchedules.Count == 0)
            {            
                BusyScheduleRepository.Update(existing);
                return existing;
            }

            BusySchedules newSchedule = SolveOverlappedSchedules(existing, existingSchedules);
            existing.BusyPeriodStartOn = newSchedule.BusyPeriodStartOn;
            existing.BusyPeriodEndsOn = newSchedule.BusyPeriodEndsOn;
            BusyScheduleRepository.Update(existing);

            foreach (var sch in existingSchedules)
            {
                if (sch.Id != existing.Id)
                    BusyScheduleRepository.Remove(sch);
            }

            return existing;
        }

        public TimeSchedules UpdateWokingInterval(int userId, int scheduleId, DayOfWeek startDay, TimeSpan startTime, DayOfWeek endDay, TimeSpan endTime)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            List<TimeSchedules> userSchedules = user.TheTimeScheduleForThisUser;
            TimeSchedules existing = userSchedules.Where(x => x.Id == scheduleId).SingleOrDefault();
            if (existing == null)
                throw new NoEntryFoundException(scheduleId, userId, typeof(TimeSchedules).Name);

            existing.StartDay = startDay;
            existing.StartTime = startTime;
            existing.EndDay = endDay;
            existing.EndTime = endTime;

            List<TimeSchedules> overlapping = GetOverlappedSchedule(existing, userSchedules);

            if (overlapping.Count == 0)
            {
                TimeScheduleRepository.Update(existing);
                return existing;
            }

            TimeSchedules newSchedule = SolveOverlappedSchedules(existing, overlapping);

            existing.StartDay = newSchedule.StartDay;
            existing.StartTime = newSchedule.StartTime;
            existing.EndDay = newSchedule.EndDay;
            existing.EndTime = newSchedule.EndTime;
            TimeScheduleRepository.Update(existing);

            foreach (var sch in overlapping)
                TimeScheduleRepository.Remove(sch);

            return existing;
        }
    }
}