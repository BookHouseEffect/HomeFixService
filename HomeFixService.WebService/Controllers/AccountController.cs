using HomeFixService.WebService.Models.Api;
using HomeFixService.WebService.Models.EntityFramework;
using HomeFixService.WebService.Services.Implementations;
using System;
using System.Web.Http;

namespace HomeFixService.WebService.Controllers
{
    [Authorize]
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
            }
            catch (Exception ex)
            {
                if (newUser != null && newUser.Id != 0)
                {
                    try {
                        AccountService.RemoveUser(newUser.Id, model.UserName, model.Password);
                    }
                    catch (Exception) { }
                    
                }

                return InternalServerError(ex);
            }

            return Ok(newUser);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/account/user")]
        public IHttpActionResult GetUserInfo(int userId)
        {
            Users currentUser;
            try
            {
                currentUser = AccountService.GetUser(userId);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(currentUser);
        }

        [HttpPost]
        [Route("api/account/user")]
        public IHttpActionResult UpdateUserInfo(UserModel model)
        {
            if (!ModelState.IsValid)
                return InternalServerError(new Exception("Invalid model state"));

            Users currentUser;
            try
            {
                currentUser = GetUser();
                currentUser = AccountService.UpdateUserInfo(currentUser.Id, model.FirstName, model.LastName);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(currentUser);
        }

        [HttpDelete]
        [Route("api/account/user")]
        public IHttpActionResult RemoveUser(RemoveModel model)
        {
            if (!ModelState.IsValid)
                return InternalServerError(new Exception("Invalid model state"));

            Users currentUser;
            bool removedUser = false;
            try
            {
                currentUser = GetUser();
                removedUser = AccountService.RemoveUser(currentUser.Id, model.UserName, model.Password);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(removedUser);
        }

        [HttpPost]
        [Route("api/account/changePassword")]
        public IHttpActionResult ChangeUserPassword(ChangePasswordModel model)
        {
            if (!ModelState.IsValid)
                return InternalServerError(new Exception("Invalid model state"));

            Users currentUser;
            bool passwordChanged = false;
            try
            {
                currentUser = GetUser();
                passwordChanged = AccountService.ChangePassword(currentUser.Id, model.UserName, model.OldPassword, model.NewPassword);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(passwordChanged);
        }
    }
}
