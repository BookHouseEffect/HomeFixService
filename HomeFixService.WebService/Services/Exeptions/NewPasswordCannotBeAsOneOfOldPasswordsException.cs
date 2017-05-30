using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeFixService.WebService.Services.Exeptions
{
    public class NewPasswordCannotBeAsOneOfOldPasswordsException : Exception
    {
        public NewPasswordCannotBeAsOneOfOldPasswordsException()
            :base("The new password can not be as one of the old passwords. No changes have been applied.")
        {

        }
    }
}