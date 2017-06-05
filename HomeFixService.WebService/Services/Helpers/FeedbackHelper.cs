using HomeFixService.WebService.Models.EntityFramework;
using System.Collections.Generic;

namespace HomeFixService.WebService.Services.Helpers
{
    interface FeedbackHelper
    {
        Ratings RateUser(
            int userId,
            int points
            );

        List<Ratings> GetUserRatings(
            int userId
            );
    }
}
