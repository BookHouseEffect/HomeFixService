using HomeFixService.WebService.Models.Context;
using HomeFixService.WebService.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeFixService.WebService.Persistence.Implementations
{
    public class ContactRepository : CrudRepository<Contacts>
    {
        public ContactRepository() : base() { }

        public ContactRepository(DatabaseContext context) : base(context) { }

        public Contacts FindByIdAndUserId(int contactId, int userId)
        {
            return DatabaseContext
                .Contacts
                .AsNoTracking()
                .Where(
                    x => x.Id == contactId
                    && x.UserId == userId
                ).SingleOrDefault();
        }
    }
}