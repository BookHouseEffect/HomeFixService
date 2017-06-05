using HomeFixService.WebService.Models.Context;
using HomeFixService.WebService.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;

namespace HomeFixService.WebService.Persistence.Implementations
{
    public class BusyScheduleRepository : CrudRepository<BusySchedules>
    {
        public BusyScheduleRepository() : base() { }

        public BusyScheduleRepository(DatabaseContext context) : base(context) { }

        public BusySchedules FindByIdAndUserId(int scheduleId, int userId)
        {
            return DatabaseContext
                .BusySchedules
                .AsNoTracking()
                .Where(
                    x => x.Id == scheduleId
                    && x.UserId == userId
                ).SingleOrDefault();
        }

        public List<BusySchedules> GetAllInPeriod(int userId, DateTime periodStarts, DateTime periodEnds)
        {
            return DatabaseContext
                .BusySchedules
                .AsNoTracking()
                .Where(
                    x => x.UserId == userId
                    &&
                    (
                        (
                            x.BusyPeriodStartOn >= periodStarts
                            && x.BusyPeriodStartOn <= periodEnds
                        )
                        ||
                        (
                            x.BusyPeriodEndsOn >= periodStarts
                            && x.BusyPeriodEndsOn <= periodEnds
                        )
                    )
                ).ToList();
        }
    }
}