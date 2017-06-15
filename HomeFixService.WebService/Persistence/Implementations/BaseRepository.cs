using HomeFixService.WebService.Models.Context;
using System;

namespace HomeFixService.WebService.Persistence.Implementations
{
    public abstract class BaseRepository : IDisposable
    {
        protected readonly DatabaseContext DatabaseContext;

        protected BaseRepository()
        {
            DatabaseContext = new DatabaseContext();
        }

        protected BaseRepository(DatabaseContext databaseContext)
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

        public void Dispose()
        {
            DatabaseContext.Dispose();
        }
    }
}