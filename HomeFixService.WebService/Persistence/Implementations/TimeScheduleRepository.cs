using HomeFixService.WebService.Models.Context;
using HomeFixService.WebService.Models.EntityFramework;
using System.Linq;

namespace HomeFixService.WebService.Persistence.Implementations
{
    public class TimeScheduleRepository : CrudRepository<TimeSchedules>
    {
        public TimeScheduleRepository() : base() { }

        public TimeScheduleRepository(DatabaseContext context) : base(context) { }

        public TimeSchedules FindByIdAndUserId(int scheduleId, int userId)
        {
            return DatabaseContext
                .TimeSchedules
                .AsNoTracking()
                .Where(
                    x => x.Id == scheduleId
                    && x.UserId == userId
                ).SingleOrDefault();
        }
    }
}