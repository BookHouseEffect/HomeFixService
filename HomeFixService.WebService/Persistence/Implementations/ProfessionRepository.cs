using HomeFixService.WebService.Models.Context;
using HomeFixService.WebService.Models.EntityFramework;
using HomeFixService.WebService.Models.Enums;
using System.Linq;

namespace HomeFixService.WebService.Persistence.Implementations
{
    public class ProfessionRepository : CrudRepository<UserProfessions>
    {
        public ProfessionRepository() : base() { }

        public ProfessionRepository(DatabaseContext context) : base(context) { }

        public UserProfessions GetByIdAndUserId(int professionId, int userId)
        {
            return DatabaseContext
                .UserProfessions
                .AsNoTracking()
                .Where(
                    x => x.Id == professionId
                    && x.UserId == userId
                ).SingleOrDefault();
        }

        public UserProfessions GetByUserIdAndProfession(int userId, Professions profession)
        {
            return DatabaseContext
                .UserProfessions
                .AsNoTracking()
                .Where(
                    x => x.UserId == userId
                    && x.TheProfession == profession
                ).SingleOrDefault();
        }
    }
}