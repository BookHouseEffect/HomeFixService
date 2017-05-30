using HomeFixService.WebService.Models.Context;
using HomeFixService.WebService.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeFixService.WebService.Persistence.Implementations
{
    public class UsersRepository : CrudRepository<Users>
    {
        public UsersRepository() : base() { }

        public UsersRepository(DatabaseContext context) : base(context) { }
    }
}