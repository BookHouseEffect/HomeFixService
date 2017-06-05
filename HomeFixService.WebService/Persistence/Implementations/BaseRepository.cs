using HomeFixService.WebService.Models.Context;

namespace HomeFixService.WebService.Persistence.Implementations
{
    public abstract class BaseRepository
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

        ~BaseRepository()
        {
            DatabaseContext.Dispose();
        }
    }
}