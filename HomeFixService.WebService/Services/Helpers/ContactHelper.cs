using HomeFixService.WebService.Models.EntityFramework;
using System.Collections.Generic;

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

        List<UserAddresses> GetAllContactAddresses(
            int userId
            );

        UserAddresses UpdateContactAddress(
            int userId,
            int addressid,
            string streetName,
            string city,
            string country
            );

        bool RemoveContactAddress(
            int userId,
            int addressId
            );

        Contacts AddContactNumber(
            int userId,
            string phoneNumber
            );
        
        List<Contacts> GetAllContactNumbers(
            int userId
            );

        Contacts UpdateContactNumber(
            int userId,
            int contactId,
            string phoneNumber
            );

        bool RemoveContactNumber(
            int userId,
            int contactId
            );

    }
}
