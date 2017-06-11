using HomeFixService.WebService.Models.EntityFramework;
using HomeFixService.WebService.Services.Implementations;
using System.Collections.Generic;
using System.Security.Claims;
using System.Web.Http;
using System.Linq;

namespace HomeFixService.WebService.Controllers
{
    public abstract class BaseController : ApiController
    {
        protected AccountService AccountService;

        public BaseController()
        {
            AccountService = new AccountService();
        }

        protected Users GetUser()
        {
            IEnumerable<Claim> claims = GetClaims();
            if (claims == null)
                return null;

            var sidClaim = claims.Where(x => x.Type.Equals(ClaimTypes.Sid)).FirstOrDefault();
            if (sidClaim == null)
                return null;

            int userId;
            int.TryParse(sidClaim.Value, out userId);

            if (userId == 0)
                return null;

            return AccountService.GetUser(userId);
        }

        protected IEnumerable<Claim> GetClaims()
        {
            if (User == null)
                return null;

            if (User.Identity == null)
                return null;

            if (!User.Identity.IsAuthenticated)
                return null;

            var identity = (ClaimsIdentity)User.Identity;
            IEnumerable<Claim> claims = identity.Claims;

            return claims;
        }
    }
}
