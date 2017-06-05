﻿using System;

namespace HomeFixService.WebService.Models.Exeptions
{
    public class NewPasswordCannotBeAsOneOfOldPasswordsException : Exception
    {
        public NewPasswordCannotBeAsOneOfOldPasswordsException()
            :base("The new password can not be as one of the old passwords. No changes have been applied.")
        {

        }
    }
}