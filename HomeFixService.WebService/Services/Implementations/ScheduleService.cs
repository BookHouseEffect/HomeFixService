using HomeFixService.WebService.Services.Helpers;
using System;
using System.Collections.Generic;
using HomeFixService.WebService.Models.EntityFramework;
using HomeFixService.WebService.Persistence.Implementations;
using HomeFixService.WebService.Models.Exeptions;

namespace HomeFixService.WebService.Services.Implementations
{
    public class ScheduleService : BaseService, ScheduleHelper
    {
        private TimeScheduleRepository TimeScheduleRepository;
        private BusyScheduleRepository BusyScheduleRepository;

        public ScheduleService(): base()
        {
            this.TimeScheduleRepository = new TimeScheduleRepository(
                UsersRepository.GetExistingDatabaseContext());
            this.BusyScheduleRepository = new BusyScheduleRepository(
                UsersRepository.GetExistingDatabaseContext());
        }

        public BusySchedules AddBusyInterval(int userId, DateTime startOn, DateTime endsOn)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            //TODO Expand if already have common parts

            BusySchedules schedule = new BusySchedules
            {
                UserId = user.Id,
                BusyPeriodStartOn = startOn,
                BusyPeriodEndsOn = endsOn
            };

            BusyScheduleRepository.Add(schedule);
            return schedule;
        }

        public TimeSchedules AddWorkingInterval(int userId, DayOfWeek workingDay, TimeSpan startTime, TimeSpan endTime)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            //TODO Expand if already have common parts

            TimeSchedules schedule = new TimeSchedules
            {
                UserId = user.Id,
                WorkingDayOfWeek = workingDay,
                StartTime = startTime,
                EndTime = endTime
            };

            TimeScheduleRepository.Add(schedule);
            return schedule;
        }

        public List<BusySchedules> GetAllBusyIntervalsPerPeriod(int userId, DateTime periodStarts, DateTime periodEnds)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            return BusyScheduleRepository.GetAllInPeriod(user.Id, periodStarts, periodEnds);
        }

        public List<TimeSchedules> GetAllWorkingIntervalForUser(int userId)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            return user.TheTimeScheduleForThisUser;
        }

        public bool RemoveUserBusyInterval(int userId, int scheduleId)
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

        public bool RemoveUserWorkingInterval(int userId, int scheduleId)
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

        public BusySchedules UpdateUserInterval(int userId, int scheduleId, DateTime startOn, DateTime endsOn)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            BusySchedules existing = BusyScheduleRepository.FindByIdAndUserId(scheduleId, user.Id);
            if (existing == null)
                throw new NoEntryFoundException(scheduleId, userId, typeof(BusySchedules).Name);

            //TODO check if the interval has begin, or has end

            existing.BusyPeriodStartOn = startOn;
            existing.BusyPeriodEndsOn = endsOn;

            BusyScheduleRepository.Update(existing);
            return existing;
        }

        public TimeSchedules UpdateWokingInterval(int userId, int scheduleId, DayOfWeek workingDay, TimeSpan startTime, TimeSpan endTime)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            TimeSchedules existing = TimeScheduleRepository.FindByIdAndUserId(scheduleId, user.Id);
            if (existing == null)
                throw new NoEntryFoundException(scheduleId, userId, typeof(TimeSchedules).Name);

            //TODO check for overlapping periods

            existing.WorkingDayOfWeek = workingDay;
            existing.StartTime = startTime;
            existing.EndTime = endTime;

            TimeScheduleRepository.Update(existing);
            return existing;
        }
    }
}