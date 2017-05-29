using HomeFixService.WebService.Models.EntityFramework;
using HomeFixService.WebService.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeFixService.WebService.Services.Helpers
{
    interface ProfessionHelper
    {
        UserProfessions AssignProfessionToUser(
            int userId,
            Professions profession
            );

        List<UserProfessions> GetAllUserProfessions(
            int userId
            );

        bool RemoveProfessionFromUser(
            int userId,
            int professionId,
            Professions profession
            );

        ProfessionServices AddProfessionService(
            int userId,
            int professionId,
            string serviceName,
            string serviceUnit,
            float serviceUnitPrice
            );

        List<ProfessionServices> GetAllProfessionServices(
            int userId,
            int professionId
            );

        List<ProfessionServices> GetAllUserServices(
            int userId
            );

       ProfessionServices UpdateProfessionService(
            int userId,
            int serviceId,
            string serviceName,
            string serviceUnit,
            float serviceUnitPrice
            );

        bool RemoveProfessionService(
            int userId,
            int serviceId
            );
    }
}
