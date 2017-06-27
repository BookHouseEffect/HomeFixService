using HomeFixService.WebService.Services.Helpers;
using System;
using HomeFixService.WebService.Models.EntityFramework;
using HomeFixService.WebService.Models.Exeptions;
using HomeFixService.WebService.Persistence.Implementations;

namespace HomeFixService.WebService.Services.Implementations
{
    public class FeedbackService : BaseService, FeedbackHelper
    {
        private FeedbackRepository FeedbackRepository;

        public FeedbackService() : base()
        {
            this.FeedbackRepository = new FeedbackRepository(
                UsersRepository.GetExistingDatabaseContext());
        }

        public Double GetUserRating(int userId)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            return (double)user.RatingSum / (double)user.RatingCount;
        }

        public Ratings RateUser(int userId, int points)
        {
            /*
             * TODO ...
             *      check if user is not rating himself, 
             *      check if user is not rating other user with same profession,
             *      authenticate the users that are providing rating by phone number
            */
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            Ratings rate = new Ratings
            {
                UserId = user.Id,
                FeedbackPoints = points,
                FeedbackDateTime = DateTime.UtcNow
            };

            FeedbackRepository.Add(rate);

            user.RatingSum += rate.FeedbackPoints;
            user.RatingCount++;
            UsersRepository.Update(user);

            return rate;
        }
    }
}