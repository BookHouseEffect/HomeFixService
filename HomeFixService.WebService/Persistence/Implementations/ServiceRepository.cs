using HomeFixService.WebService.Models.Context;
using HomeFixService.WebService.Models.EntityFramework;
using System.Collections.Generic;
using System.Linq;

namespace HomeFixService.WebService.Persistence.Implementations
{
    public class ServiceRepository : CrudRepository<ProfessionServices>
    {
        public ServiceRepository() : base() { }

        public ServiceRepository(DatabaseContext context) : base(context) { }

        public List<ProfessionServices> GetByUserId(int userId)
        {
            return DatabaseContext
                .ProfessionServices
                .AsNoTracking()
                .Where(
                    x => x.UserId == userId
                ).ToList();
        }

        public ProfessionServices GetByIdAndUserId(int serviceId, int userId)
        {
            return DatabaseContext
                .ProfessionServices
                .AsNoTracking()
                .Where(
                    x => x.Id == serviceId
                    && x.UserId == userId
                ).SingleOrDefault();
        }

        public List<ProfessionServices> GetServicesByUserIdAndProfessionId(int userId, int professionId)
        {
            return DatabaseContext
                .ProfessionServices
                .AsNoTracking()
                .Where(
                    x => x.UserId == userId
                    && x.UserProfessionId == professionId
                ).ToList();
        }
    }
}