using HomeFixService.WebService.Services.Helpers;
using System.Collections.Generic;
using HomeFixService.WebService.Models.EntityFramework;
using HomeFixService.WebService.Models.Enums;
using HomeFixService.WebService.Persistence.Implementations;

namespace HomeFixService.WebService.Services.Implementations
{
    public class SearchService : SearchHelper
    {
        private SearchRepository SearchRepository;

        public SearchService()
        {
            SearchRepository = new SearchRepository();
        }

        public List<string> GetCityList(string countryName, string searchTerm)
        {
            if (string.IsNullOrEmpty(countryName) || string.IsNullOrWhiteSpace(countryName))
                throw new System.InvalidOperationException("Country name cannot be null, empty or whitespace");

            return SearchRepository.GetCityList(countryName, RepairSearchTerm(searchTerm));
        }

        public List<string> GetCountryList(string searchTerm)
        {
            return SearchRepository.GetCountryList(RepairSearchTerm(searchTerm));
        }

        public List<Users> GetUsersByCountryCityCriteria(string countryName, string cityName, string searchTerm, int pageSize, int pageNumber)
        {
            return SearchRepository.GetPagedUserListFilteredByCountryAndCityAndRating(
                countryName, cityName, RepairSearchTerm(searchTerm), pageSize, pageNumber);
        }

        public List<Users> GetUsersByProfessionCriteria(ProfessionsEnum profession, string searchTerm, float currentLatitude, float currentLongitude, int pageSize, int pageNumber)
        {
            return SearchRepository.GetPagedUserListFilteredByProfessionAndCurrentLocationAndRating(
                profession, RepairSearchTerm(searchTerm), currentLatitude, currentLongitude, pageSize, pageNumber);
        }

        public List<Users> GetUsersBySearchCriteria(string searchTerm, float currentLatitude, float currentLongitude, int pageSize, int pageNumber)
        {
            return SearchRepository.GetPagesUserListFilteredByCurrentLocationAndRating(
                RepairSearchTerm(searchTerm), currentLatitude, currentLongitude, pageSize, pageNumber);
        }

        private string RepairSearchTerm(string searchTerm)
        {
            var repairedTerm = searchTerm != null ? searchTerm : "";
            repairedTerm = repairedTerm.Trim();
            return repairedTerm;
        }
    }
}