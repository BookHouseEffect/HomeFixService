using HomeFixService.WebService.Services.Helpers;
using System;
using System.Collections.Generic;
using HomeFixService.WebService.Models.EntityFramework;
using HomeFixService.WebService.Models.Exeptions;
using HomeFixService.WebService.Persistence.Implementations;

namespace HomeFixService.WebService.Services.Implementations
{
    public class FeedbackService : BaseService, FeedbackHelper
    {
        private FeedbackRepository FeedbackRepository;

        FeedbackService() : base()
        {
            this.FeedbackRepository = new FeedbackRepository(
                UsersRepository.GetExistingDatabaseContext());
        }

        public List<Ratings> GetUserRatings(int userId)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            return user.TheRatingsGivenForThisUser;
        }

        public Ratings RateUser(int userId, int points)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            Ratings rate = new Ratings
            {
                UserId = user.Id,
                FeedbackPoints = userId,
                FeedbackDateTime = DateTime.UtcNow
            };

            FeedbackRepository.Add(rate);
            return rate;
        }
    }
}