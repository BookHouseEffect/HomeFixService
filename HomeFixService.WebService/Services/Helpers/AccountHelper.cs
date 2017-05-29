using HomeFixService.WebService.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFixService.WebService.Services.Helpers
{
    interface AccountHelper
    {
        Users CreateUser(
            string firstName,
            string lastName
            );

        Users GetUser(
            int userId
            );

        Users UpdateUserInfo(
            string firstName,
            string lastName
            );

        Credentials AssignUserCredentials(
            int userId,
            string userName,
            string password
            );

        Credentials CheckCredentials(
            int userId,
            string userName,
            string password
            );

        Credentials ChangePassword(
            int userId,
            string userName,
            string oldPassword,
            string newPassword
            );

        bool RemoveUser(
            int userId,
            string userName,
            string password
        );
    }
}
