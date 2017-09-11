using HomeFixService.WebService.Models.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using HomeFixService.WebService.Models.EntityFramework;
using HomeFixService.WebService.Models.Enums;
using System.Data.Entity.SqlServer;

namespace HomeFixService.WebService.Persistence.Implementations
{
    public class SearchRepository : BaseRepository, ISearchRepository
    {
        public SearchRepository() : base() { }

        public SearchRepository(DatabaseContext context) : base(context) { }

        private IQueryable<Users> GeneralSearchTerm(IQueryable<Users> query, string searchTerm)
        {
            if (string.IsNullOrEmpty(searchTerm) || string.IsNullOrWhiteSpace(searchTerm))
                return query;

            string[] splittedSearchTerm = searchTerm.Split(' ');

            return
                query.Where(
                    x => splittedSearchTerm.Any(s => x.UserFirstName.Contains(s))
                      || splittedSearchTerm.Any(s => x.UserLastName.Contains(s))
                      || splittedSearchTerm.Any(
                         s => x.TheAddressesThatThisUserWorksOn
                            .Any(
                                y => y.City.Contains(s)
                                  || y.Country.Contains(s)
                                  || y.StreetName.Contains(s)
                            )
                        )
                      || splittedSearchTerm.Any(
                         s => x.TheContactsForThisUser
                            .Any(
                                y => y.PhoneNumber.Contains(s)
                            )
                        )
                      || splittedSearchTerm.Any(
                         s => x.TheProfessionsThatThisUserKnows
                            .Any(
                                y => y.TheProfession.ProfessionName.Contains(s)
                                  || y.TheProfession.ProfessionDescription.Contains(s)
                                  || y.TheServicesConnectedWithThisProfession
                                        .Any(
                                            z => z.ServiceName.Contains(s)
                                        )
                            )
                        )
                );
        }

        private IQueryable<Users> PagingQuery(IQueryable<Users> query, int pageNumber, int pageSize)
        {
            return
                query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);
        }

        private IQueryable<Users> DistanceQuery(IQueryable<Users> query, float latitude, float longitude)
        {
            var R = 6371; //Result in kilometers
            var PiOver180 = Math.PI / 180.0;
            return
                query.Select
                (
                    x => new
                    {
                        User = x,
                        Distance =
                            x.TheAddressesThatThisUserWorksOn
                            .Select(
                                y => new
                                {
                                    Distance = SqlFunctions.SquareRoot(
                                             SqlFunctions.Square(PiOver180 * (y.Longitude - longitude) *
                                                SqlFunctions.Cos(PiOver180 * (y.Latitude + latitude) / 2.0)) +
                                             SqlFunctions.Square(PiOver180 * (y.Latitude - latitude))
                                        ) * R
                                }
                            ).OrderBy(y => y.Distance)
                            .FirstOrDefault()
                            .Distance
                    }
                ).OrderBy(x => x.Distance)
                .ThenByDescending(x => (x.User.RatingCount != 0 ? (x.User.RatingSum / x.User.RatingCount) : 0))
                .Select(x => x.User);
        }

        public List<Users> GetPagedUserListFilteredByCountryAndCityAndRating(string countryName, string cityName, string searchTerm, int pageSize, int pageNumber)
        {
            IQueryable<Users> firstQuery =
                DatabaseContext
                    .Users
                    .Where(
                        x => x.TheAddressesThatThisUserWorksOn
                                .Any(
                                    y => y.Country.Contains(countryName)
                                        && y.City.Contains(cityName)
                                )
                    );

            return
                PagingQuery(
                    GeneralSearchTerm(firstQuery, searchTerm)
                        .OrderByDescending(x => (x.RatingCount != 0 ? (x.RatingSum / x.RatingCount) : 0))
                    , pageNumber, pageSize
                ).ToList();
        }


        public List<Users> GetPagedUserListFilteredByProfessionAndCurrentLocationAndRating(ProfessionsEnum profession, string searchTerm, float currentLatitude, float currentLongitude, int pageSize, int pageNumber)
        {
            IQueryable<Users> firstQuery =
                DatabaseContext
                    .Users
                    .Where(
                        x => x.TheProfessionsThatThisUserKnows
                                .Any(
                                    y => y.ProfessionId == (int)profession
                                )
                    );

            IQueryable<Users> searchTermFilteredQuery = GeneralSearchTerm(firstQuery, searchTerm);
            IQueryable<Users> locationAdjustedQuery = DistanceQuery(searchTermFilteredQuery, currentLatitude, currentLongitude);

            return PagingQuery(locationAdjustedQuery, pageNumber, pageSize).ToList();
        }

        public List<Users> GetPagesUserListFilteredByCurrentLocationAndRating(string searchTerm, float currentLatitude, float currentLongitude, int pageSize, int pageNumber)
        {
            return
                PagingQuery(
                    DistanceQuery(
                        GeneralSearchTerm(DatabaseContext.Users, searchTerm),
                    currentLatitude, currentLongitude),
                pageNumber, pageSize)
                .ToList();
        }

        public List<string> GetCountryList(string searchTerm)
        {
            return
                DatabaseContext
                    .UserAddresses
                    .Where(
                        x => x.Country.Contains(searchTerm)
                    ).Select(
                        p => p.Country
                    )
                    .Distinct()
                    .OrderBy(x => x)
                    .ToList();
        }

        public List<string> GetCityList(string countryName, string searchTerm)
        {
            return
                DatabaseContext
                    .UserAddresses
                    .Where(
                        x => x.Country.ToLower().Equals(countryName.ToLower())
                        && x.City.Contains(searchTerm)
                    ).Select(
                        p => p.City
                    ).Distinct()
                    .OrderBy(x => x)
                    .ToList();
        }
    }
}