using HomeFixService.WebService.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace HomeFixService.WebService.Models.Api
{
    public class PagingModel
    {
        public int PageSize { get; set; } = 10;

        public int PageNumber { get; set; } = 1;
    }

    public class SearchTermModel : PagingModel
    {
        public string SearchTerm { get; set; } = "";
    }

    public class LocationModel : SearchTermModel
    {
        [Required]
        public float CurrentLatitude { get; set; }

        [Required]
        public float CurrentLongitude { get; set; }
    }

    public class GeneralSearchModel : LocationModel { }

    public class CountryCitySearchModel : SearchTermModel
    {
        [Required]
        public string CountryName { get; set; }

        [Required]
        public string CityName { get; set; }
    }

    public class ProfessionSearchModel : LocationModel
    {
        public ProfessionsEnum Profession { get; set; }
    }
}