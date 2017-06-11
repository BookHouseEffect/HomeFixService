using HomeFixService.WebService.Models.Api;
using HomeFixService.WebService.Models.EntityFramework;
using HomeFixService.WebService.Services.Implementations;
using System;
using System.Web.Http;

namespace HomeFixService.WebService.Controllers
{
    public class AccountController : BaseController
    {
        [AllowAnonymous]
        [HttpPost]
        [Route("api/account/register")]
        public IHttpActionResult Register(RegisterModel model)
        {
            if (!ModelState.IsValid)
                return InternalServerError(new Exception("Invalid model state"));

            Users newUser = null;

            try
            {
                newUser = AccountService.CreateUser(model.FirstName, model.LastName);
                bool validCredentials = AccountService
                    .AssignUserCredentials(newUser.Id, model.UserName, model.Password);
            } catch (Exception ex)
            {
                if (newUser != null && newUser.Id != 0)
                {
                    try {
                        AccountService.RemoveUser(newUser.Id, model.UserName, model.Password);
                    } catch (Exception) { }
                    
                }

                return InternalServerError(ex);
            }

            return Ok("Registration successfull");
        }

       
    }
}
