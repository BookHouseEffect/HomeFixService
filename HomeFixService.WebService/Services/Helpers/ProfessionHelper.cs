using HomeFixService.WebService.Models.EntityFramework;
using HomeFixService.WebService.Models.Enums;
using System.Collections.Generic;

namespace HomeFixService.WebService.Services.Helpers
{
    interface ProfessionHelper
    {
        List<Professions> GetProfessionsList();

        UserProfessions AssignProfessionToUser(
            int userId,
            ProfessionsEnum profession
            );

        List<UserProfessions> GetAllUserProfessions(
            int userId
            );

        bool RemoveProfessionFromUser(
            int userId,
            int professionId
            );

        ProfessionServices AddProfessionService(
            int userId,
            int professionId,
            string serviceName,
            string serviceUnit,
            float serviceUnitPrice,
            CurrencyEnum currency
            );

        List<Currencies> GetCurrenciesList();

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
            float serviceUnitPrice,
            CurrencyEnum currency
            );

        bool RemoveProfessionService(
            int userId,
            int serviceId
            );
    }
}
