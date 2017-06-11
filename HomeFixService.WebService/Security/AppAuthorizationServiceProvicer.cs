using HomeFixService.WebService.Models.EntityFramework;
using HomeFixService.WebService.Services.Implementations;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace HomeFixService.WebService.Security
{
    public class AppAuthorizationServiceProvicer : OAuthAuthorizationServerProvider
    {
        private AccountService AccountService;

        public AppAuthorizationServiceProvicer()
        {
            AccountService = new AccountService();
        }

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated(); // TODO ValidateClientAuthentication
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);
            var username = context.UserName;
            var password = context.Password;

            try
            {
                Credentials credentials = AccountService.CheckCredentials(username, password);
                if (credentials == null) {
                    context.SetError("The provided credentials are invalid");
                    return;
                }

                identity.AddClaim(new Claim(ClaimTypes.Sid, credentials.TheUserForThisCredential.Id.ToString()));
                identity.AddClaim(new Claim("username", credentials.UserName));
                identity.AddClaim(new Claim(ClaimTypes.Name, credentials.TheUserForThisCredential.UserFirstName));
                identity.AddClaim(new Claim(ClaimTypes.Surname, credentials.TheUserForThisCredential.UserLastName));
                context.Validated(identity);

            } catch (Exception ex)
            {
                context.SetError("invalid_grant", ex.Message);
            }
        }
    }
}