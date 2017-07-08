using HomeFixService.WebService.Models.Api;
using HomeFixService.WebService.Models.EntityFramework;
using HomeFixService.WebService.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using System.Web.Http;

namespace HomeFixService.WebService.Controllers
{
    public class SearchController : ApiController
    {
        private SearchService SearchService;

        public SearchController()
        {
            SearchService = new SearchService();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/search/listCountry")]
        public IHttpActionResult GetCountryList([Optional] string countryCriteria)
        {
            List<string> returnedResult = new List<string>();

            try
            {
                returnedResult = SearchService.GetCountryList(countryCriteria);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(returnedResult);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/search/listCityForCountry")]
        public IHttpActionResult GetCityList(string countryName, [Optional] string cityCriteria)
        {
            List<string> returnedResult = new List<string>();

            try
            {
                returnedResult = SearchService.GetCityList(countryName, cityCriteria);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(returnedResult);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/search/generalSearch")]
        public IHttpActionResult GeneralSearch([FromUri] GeneralSearchModel model)
        {
            if (!ModelState.IsValid)
                return InternalServerError(new Exception("Invalid model state"));

            List<Users> returnedResult = new List<Users>();

            try
            {
                returnedResult = SearchService.GetUsersBySearchCriteria(
                    model.SearchTerm, model.CurrentLatitude, model.CurrentLongitude, 
                    model.PageSize, model.PageNumber);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(returnedResult);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/search/searchByProfession")]
        public IHttpActionResult SearchByProfession([FromUri] ProfessionSearchModel model)
        {
            if (!ModelState.IsValid)
                return InternalServerError(new Exception("Invalid model state"));

            List<Users> returnedResult = new List<Users>();

            try
            {
                returnedResult = SearchService.GetUsersByProfessionCriteria(
                    model.Profession, model.SearchTerm, model.CurrentLatitude, 
                    model.CurrentLongitude, model.PageSize, model.PageNumber);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(returnedResult);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/search/searchByCountryAndCity")]
        public IHttpActionResult SearchByCountryAndCity([FromUri] CountryCitySearchModel model)
        {
            if (!ModelState.IsValid)
                return InternalServerError(new Exception("Invalid model state"));

            List<Users> returnedResult = new List<Users>();

            try
            {
                returnedResult = SearchService.GetUsersByCountryCityCriteria(
                   model.CountryName,model.CityName, model.SearchTerm, model.PageSize, model.PageNumber);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(returnedResult);
        }

    }
}
