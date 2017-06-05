using HomeFixService.WebService.Models.Context;
using HomeFixService.WebService.Models.EntityFramework;

namespace HomeFixService.WebService.Persistence.Implementations
{
    public class FeedbackRepository : CrudRepository<Ratings>
    {
        public FeedbackRepository() : base() { }

        public FeedbackRepository(DatabaseContext context) : base(context) { }
    }
}