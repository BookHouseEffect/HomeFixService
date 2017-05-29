using HomeFixService.WebService.Models.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFixService.WebService.Services.Helpers
{
    interface ContactHelper
    {
        UserAddresses AddContactAddress(
            int userId,
            string streetName,
            string city,
            string country
            );

        List<UserAddresses> GetAllUserContactAddresses(
            int userId
            );

        UserAddresses UpdateContactAddress(
            int userId,
            int addressid,
            string streetName,
            string city,
            string country
            );

        bool RemoveUserContactAddress(
            int userId
            );

        Contact AddContactNumber(
            int userId,
            string phoneNumber
            );

        List<Contact> GetAllContactNumbers(
            int userId
            );

        Contact UpdateContactAddress(
            int userId,
            int contactId,
            string phoneNumber
            );

        bool RemoveUserContactNumber(
            int userId,
            int contactId
            );

    }
}
