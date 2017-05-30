using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeFixService.WebService.Services.Exeptions
{
    public class ExistingCredentialsFoundException : Exception
    {
        public int UserId { get; }
        public int CredentialId { get; }
        public string UserName { get; }

        public ExistingCredentialsFoundException(int userId, int credentialId)
            :base(
                 String.Format(
                     "Existing credentials with id={0} found for the user with id={1}. " +
                     "Cannot create new credentials.", 
                     userId, 
                     credentialId)
                 )
        {
            this.UserId = userId;
            this.CredentialId = credentialId;
        }

        public ExistingCredentialsFoundException(string userName)
            : base(
                 String.Format(
                     "The username={0} already exists within the database. " +
                     "Cannot be reassigned.",
                     userName)
                 )
        {
            this.UserName = userName;
        }
    }
}