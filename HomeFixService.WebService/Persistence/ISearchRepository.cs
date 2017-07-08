using HomeFixService.WebService.Models.EntityFramework;
using HomeFixService.WebService.Models.Enums;
using System.Collections.Generic;

namespace HomeFixService.WebService.Persistence
{
    interface ISearchRepository
    {
        List<Users> GetPagesUserListFilteredByCurrentLocationAndRating(
            string searchTerm,
            float currentLatitude,
            float currentLongitude,
            int pageSize,
            int pageNumber
        );

        List<Users> GetPagedUserListFilteredByProfessionAndCurrentLocationAndRating(
            ProfessionsEnum profession,
            string searchTerm,
            float currentLatitude,
            float currentLongitude,
            int pageSize,
            int pageNumber
        );

        List<Users> GetPagedUserListFilteredByCountryAndCityAndRating(
            string countryName,
            string cityName,
            string searchTerm,
            int pageSize,
            int pageNumber
        );

        List<string> GetCountryList(
            string searchTerm
        );

        List<string> GetCityList(
            string countryName,
            string searchTerm
        );
    }
}
