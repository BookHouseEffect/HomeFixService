using HomeFixService.WebService.Models.Context;
using HomeFixService.WebService.Models.EntityFramework;
using HomeFixService.WebService.Models.Enums;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace HomeFixService.WebService.Persistence.Implementations
{
    public class ProfessionRepository : CrudRepository<UserProfessions>
    {
        public ProfessionRepository() : base() { }

        public ProfessionRepository(DatabaseContext context) : base(context) { }

        public List<Professions> GetListOfProfessions()
        {
            return DatabaseContext
                .Professions
                .ToList();
        }

        public UserProfessions GetByIdAndUserId(int professionId, int userId)
        {
            return DatabaseContext
                .UserProfessions
                .AsNoTracking()
                .Where(
                    x => x.Id == professionId
                    && x.UserId == userId
                ).Include(
                    x => x.TheProfession
                ).SingleOrDefault();
        }

        public UserProfessions GetByUserIdAndProfession(int userId, ProfessionsEnum profession)
        {
            return DatabaseContext
                .UserProfessions
                .AsNoTracking()
                .Where(
                    x => x.UserId == userId
                    && x.ProfessionId == (int)profession
                ).Include(
                    x => x.TheProfession
                ).SingleOrDefault();
        }

        public List<UserProfessions> GetProfessionsByUserId(int userId)
        {
            return DatabaseContext
                .UserProfessions
                .AsNoTracking()
                .Where(
                    x => x.UserId == userId
                ).Include(
                    x => x.TheProfession
                ).ToList();

        }
    }
}