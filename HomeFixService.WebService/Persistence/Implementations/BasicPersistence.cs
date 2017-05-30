using HomeFixService.WebService.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeFixService.WebService.Persistence.Implementations
{
    public abstract class BasicPersistence
    {
        protected readonly DatabaseContext DatabaseContext;

        protected BasicPersistence()
        {
            DatabaseContext = new DatabaseContext();
        }

        protected BasicPersistence(DatabaseContext databaseContext)
        {
            if (databaseContext != null)
                DatabaseContext = databaseContext;
            else
                DatabaseContext = new DatabaseContext();
        }

        public DatabaseContext GetExistingDatabaseContext()
        {
            return this.DatabaseContext;
        }

        ~BasicPersistence()
        {
            DatabaseContext.Dispose();
        }
    }
}