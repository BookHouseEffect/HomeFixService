using System;

namespace HomeFixService.WebService.Models.Exeptions
{
    public class InvalidPasswordException : Exception
    {
        public InvalidPasswordException()
            :base("The entered password is invalid. No changes have been made.") { }

    }
}