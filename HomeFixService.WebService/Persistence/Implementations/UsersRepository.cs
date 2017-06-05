using HomeFixService.WebService.Models.Context;
using HomeFixService.WebService.Models.EntityFramework;

namespace HomeFixService.WebService.Persistence.Implementations
{
    public class UsersRepository : CrudRepository<Users>
    {
        public UsersRepository() : base() { }

        public UsersRepository(DatabaseContext context) : base(context) { }
    }
}