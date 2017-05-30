using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeFixService.WebService.Services.Exeptions
{
    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException()
            :base("The entered password is invalid. No changes have been made.") { }

    }
}