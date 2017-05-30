using HomeFixService.WebService.Models.Context;
using HomeFixService.WebService.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeFixService.WebService.Persistence.Implementations
{
    public class ArchiveRepository : CrudRepository<UserPasswordsHistory>
    {
        public ArchiveRepository() : base() { }

        public ArchiveRepository(DatabaseContext context) : base(context) { }

        public IEnumerable<UserPasswordsHistory> GetByUserIdAndCredentialsId(int userId, int credentialsId)
        {
            return DatabaseContext.UserPasswordsHistory.AsNoTracking()
                .Where(x => x.UserId == userId && x.CredentialsId == credentialsId)
                .OrderByDescending(x => x.ExpiredOn)
                .Take(5)
                .ToList();
        }
    }
}