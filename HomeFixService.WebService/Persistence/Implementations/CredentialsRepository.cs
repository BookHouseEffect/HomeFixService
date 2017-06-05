using HomeFixService.WebService.Models.Context;
using HomeFixService.WebService.Models.EntityFramework;
using System.Linq;

namespace HomeFixService.WebService.Persistence.Implementations
{
    public class CredentialsRepository : CrudRepository<Credentials>
    {
        public CredentialsRepository() : base() { }

        public CredentialsRepository(DatabaseContext context) : base(context) { }

        public Credentials FindByUserName(string userName)
        {
            return DatabaseContext
                .Credentials
                .AsNoTracking()
                .Where(
                    x => x.UserName == userName
                ).SingleOrDefault();
        }

        public Credentials FindByUserNameAndUserId(int userId, string userName)
        {
            return DatabaseContext
                .Credentials
                .AsNoTracking()
                .Where(
                    x => x.UserId == userId 
                    && x.UserName == userName
                ).SingleOrDefault();
        }
    }
}