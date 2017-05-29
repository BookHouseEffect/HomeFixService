using HomeFixService.WebService.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
