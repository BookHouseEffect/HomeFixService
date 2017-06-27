using HomeFixService.WebService.Models.Api;
using HomeFixService.WebService.Models.EntityFramework;
using HomeFixService.WebService.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace HomeFixService.WebService.Controllers
{
    public class FeedBackController : BaseController
    {
        private FeedbackService FeedbackService;

        public FeedBackController() : base()
        {
            FeedbackService = new FeedbackService();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/feedback/rate")]
        public IHttpActionResult GetUserRating(int userId)
        {
            double userRating = 0.0;
            try
            {
                userRating = FeedbackService.GetUserRating(userId);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(userRating);
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("api/feedback/rate")]
        public IHttpActionResult RateUser(RateModel model)
        {
            if (!ModelState.IsValid)
                return InternalServerError(new Exception("Invalid model state"));

            double userRating = 0.0;
            Ratings newRating;
            try
            {
                newRating = FeedbackService.RateUser(model.UserId, model.Points);
                userRating = FeedbackService.GetUserRating(model.UserId);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(new KeyValuePair<Ratings, double>(newRating, userRating));
        }
    }
}
