using HomeFixService.WebService.Models.Api;
using HomeFixService.WebService.Models.EntityFramework;
using HomeFixService.WebService.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace HomeFixService.WebService.Controllers
{
    public class ProfessionController : BaseController
    {
        private ProfessionService ProfessionService;

        public ProfessionController() : base()
        {
            ProfessionService = new ProfessionService();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/profession/professionList")]
        public IHttpActionResult GetAllProfessions()
        {
            List<Professions> professionsList;
            try
            {
                professionsList = ProfessionService.GetProfessionsList();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(professionsList);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/profession/type")]
        public IHttpActionResult GetAllAssignedProfessions(int userId)
        {
            List<UserProfessions> assignedProfessions;
            try
            {
                assignedProfessions = ProfessionService.GetAllUserProfessions(userId);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(assignedProfessions);
        }

        [HttpPost]
        [Route("api/profession/type")]
        public IHttpActionResult AssignProfession(ProfessionModel model)
        {
            if (!ModelState.IsValid)
                return InternalServerError(new Exception("Invalid model state"));

            UserProfessions newProfessionAssignment;
            try
            {
                Users currentUser = GetUser();
                newProfessionAssignment = ProfessionService.AssignProfessionToUser(currentUser.Id, model.ProfessionToAssign);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(newProfessionAssignment);
        }

        [HttpDelete]
        [Route("api/profession/type")]
        public IHttpActionResult DeleteAsignedProfession(int id)
        {
            try
            {
                Users currentUser = GetUser();
                ProfessionService.RemoveProfessionFromUser(currentUser.Id, id);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(true);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/profession/currencyList")]
        public IHttpActionResult GetAllCurrencies()
        {
            List<Currencies> currencyList;
            try
            {
                currencyList = ProfessionService.GetCurrenciesList();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(currencyList);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/profession/service")]
        public IHttpActionResult GetAllUserServices(int userId)
        {
            List<ProfessionServices> serviceList;
            try
            {
                serviceList = ProfessionService.GetAllUserServices(userId);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(serviceList);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/profession/service")]
        public IHttpActionResult GetAllUserServicesByProfession(int userId, int professionId)
        {
            List<ProfessionServices> serviceList;
            try
            {
                serviceList = ProfessionService.GetAllProfessionServices(userId, professionId);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(serviceList);
        }

        [HttpPost]
        [Route("api/profession/service")]
        public IHttpActionResult AddProfessionService(AddProfessionServiceModel model)
        {
            if (!ModelState.IsValid)
                return InternalServerError(new Exception("Invalid model state"));

            ProfessionServices newProfessionService;
            try
            {
                Users currentUser = GetUser();
                newProfessionService = ProfessionService.AddProfessionService(
                    currentUser.Id, model.UserProfessionId, model.ServiceName, 
                    model.ServiceUnit, model.ServiceUnitPrice, model.Currency);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(newProfessionService);
        }

        [HttpPut]
        [Route("api/profession/service")]
        public IHttpActionResult UpDateProfessionService(int id, ProfessionServiceModel model)
        {
            if (!ModelState.IsValid)
                return InternalServerError(new Exception("Invalid model state"));

            ProfessionServices updatedProfessionService;
            try
            {
                Users currentUser = GetUser();
                updatedProfessionService = ProfessionService.UpdateProfessionService(
                    currentUser.Id, id, model.ServiceName, model.ServiceUnit, model.ServiceUnitPrice, model.Currency);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(updatedProfessionService);
        }

        [HttpDelete]
        [Route("api/profession/service")]
        public IHttpActionResult DeleteProfessionService(int id)
        {
            try
            {
                Users currentUser = GetUser();
                ProfessionService.RemoveProfessionService(currentUser.Id, id);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(true);
        }
    }
}
