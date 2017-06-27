using HomeFixService.WebService.Services.Helpers;
using System.Collections.Generic;
using HomeFixService.WebService.Models.EntityFramework;
using HomeFixService.WebService.Models.Enums;
using HomeFixService.WebService.Models.Exeptions;
using HomeFixService.WebService.Persistence.Implementations;

namespace HomeFixService.WebService.Services.Implementations
{
    public class ProfessionService : BaseService, ProfessionHelper
    {
        private ProfessionRepository ProfessionRepository;
        private ServiceRepository ServiceRepository;

        public ProfessionService() : base()
        {
            this.ProfessionRepository = new ProfessionRepository(
                UsersRepository.GetExistingDatabaseContext());
            this.ServiceRepository = new ServiceRepository(
                UsersRepository.GetExistingDatabaseContext());
        }

        public ProfessionServices AddProfessionService(int userId, int professionId, string serviceName, string serviceUnit, float serviceUnitPrice, CurrencyEnum currency)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            UserProfessions profession = ProfessionRepository.GetByIdAndUserId(professionId, user.Id);
            if (profession == null)
                throw new NoEntryFoundException(professionId, user.Id, typeof(UserProfessions).Name);

            ProfessionServices service = new ProfessionServices
            {
                UserId = user.Id,
                UserProfessionId = profession.Id,
                ServiceName = serviceName,
                ServiceUnit = serviceUnit,
                ServiceUnitPrice = serviceUnitPrice,
                ServiceUnitId = (int)currency
            };

            ServiceRepository.Add(service);
            return ServiceRepository.GetByIdAndUserId(service.Id, user.Id);
        }

        public UserProfessions AssignProfessionToUser(int userId, ProfessionsEnum profession)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            UserProfessions existingProfession = ProfessionRepository.GetByUserIdAndProfession(user.Id, profession);
            if (existingProfession != null)
                return existingProfession;
            
            UserProfessions userProfession = new UserProfessions
            {
                UserId = user.Id,
                ProfessionId = (int)profession
            };

            ProfessionRepository.Add(userProfession);
            return ProfessionRepository.GetByIdAndUserId(userProfession.Id, user.Id);
        }

        public List<ProfessionServices> GetAllProfessionServices(int userId, int professionId)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            UserProfessions profession = ProfessionRepository.GetByIdAndUserId(professionId, user.Id);
            if (profession == null)
                throw new NoEntryFoundException(professionId, user.Id, typeof(UserProfessions).Name);

            return ServiceRepository.GetServicesByUserIdAndProfessionId(user.Id, profession.Id);
        }

        public List<UserProfessions> GetAllUserProfessions(int userId)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            return ProfessionRepository.GetProfessionsByUserId(user.Id);
        }

        public List<ProfessionServices> GetAllUserServices(int userId)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            return ServiceRepository.GetByUserId(user.Id);
        }

        public List<Currencies> GetCurrenciesList()
        {
            return ServiceRepository.GetListOfCurrencies();
        }

        public List<Professions> GetProfessionsList()
        {
            return ProfessionRepository.GetListOfProfessions();
        }

        public bool RemoveProfessionFromUser(int userId, int professionId)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            UserProfessions userProfession = ProfessionRepository.GetByIdAndUserId(professionId, user.Id);
            if (userProfession == null)
                throw new NoEntryFoundException(professionId, user.Id, typeof(UserProfessions).Name);

            ProfessionRepository.Remove(userProfession);
            return true;
        }

        public bool RemoveProfessionService(int userId, int serviceId)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            ProfessionServices service = ServiceRepository.GetByIdAndUserId(serviceId, user.Id);
            if (service == null)
                throw new NoEntryFoundException(serviceId, user.Id, typeof(ProfessionServices).Name);

            ServiceRepository.Remove(service);
            return true;
        }

        public ProfessionServices UpdateProfessionService(int userId, int serviceId, string serviceName, string serviceUnit, float serviceUnitPrice, CurrencyEnum currency)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            ProfessionServices existingService = ServiceRepository.GetByIdAndUserId(serviceId, user.Id);
            if (existingService == null)
                throw new NoEntryFoundException(serviceId, userId, typeof(ProfessionServices).Name);

            existingService.ServiceName = serviceName;
            existingService.ServiceUnit = serviceUnit;
            existingService.ServiceUnitPrice = serviceUnitPrice;
            existingService.ServiceUnitId = (int)currency;

            ServiceRepository.Update(existingService);
            return ServiceRepository.GetByIdAndUserId(existingService.Id, user.Id); ;
        }
    }
}