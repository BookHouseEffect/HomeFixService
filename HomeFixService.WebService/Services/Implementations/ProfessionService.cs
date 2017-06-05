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

        ProfessionService() : base()
        {
            this.ProfessionRepository = new ProfessionRepository(
                UsersRepository.GetExistingDatabaseContext());
            this.ServiceRepository = new ServiceRepository(
                UsersRepository.GetExistingDatabaseContext());
        }

        public ProfessionServices AddProfessionService(int userId, int professionId, string serviceName, string serviceUnit, float serviceUnitPrice)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            UserProfessions profession = ProfessionRepository.GetByIdAndUserId(professionId, userId);
            if (profession == null)
                throw new NoEntryFoundException(professionId, userId, typeof(UserProfessions).Name);

            ProfessionServices service = new ProfessionServices
            {
                UserId = user.Id,
                UserProfessionId = profession.Id,
                ServiceName = serviceName,
                ServiceUnit = serviceUnit,
                ServiceUnitPrice = serviceUnitPrice
            };

            ServiceRepository.Add(service);
            return service;
        }

        public UserProfessions AssignProfessionToUser(int userId, Professions profession)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            UserProfessions existingProfession = ProfessionRepository.GetByUserIdAndProfession(userId, profession);
            if (existingProfession != null)
                return existingProfession;
            
            UserProfessions userProfession = new UserProfessions
            {
                UserId = userId,
                TheProfession = profession
            };

            ProfessionRepository.Add(userProfession);
            return userProfession;
        }

        public List<ProfessionServices> GetAllProfessionServices(int userId, int professionId)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            UserProfessions profession = ProfessionRepository.GetByIdAndUserId(professionId, userId);
            if (profession == null)
                throw new NoEntryFoundException(professionId, userId, typeof(UserProfessions).Name);

            return ServiceRepository.GetServicesByUserIdAndProfessionId(user.Id, profession.Id);
        }

        public List<UserProfessions> GetAllUserProfessions(int userId)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            return user.TheProfessionsThatThisUserKnows;
        }

        public List<ProfessionServices> GetAllUserServices(int userId)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            return ServiceRepository.GetByUserId(user.Id);
        }

        public bool RemoveProfessionFromUser(int userId, int professionId)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            UserProfessions userProfession = ProfessionRepository.GetByIdAndUserId(professionId, userId);
            if (userProfession == null)
                throw new NoEntryFoundException(professionId, userId, typeof(UserProfessions).Name);

            ProfessionRepository.Remove(userProfession);
            return true;
        }

        public bool RemoveProfessionService(int userId, int serviceId)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            ProfessionServices service = ServiceRepository.GetByIdAndUserId(serviceId, userId);
            if (service == null)
                throw new NoEntryFoundException(serviceId, userId, typeof(ProfessionServices).Name);

            ServiceRepository.Remove(service);
            return true;
        }

        public ProfessionServices UpdateProfessionService(int userId, int serviceId, string serviceName, string serviceUnit, float serviceUnitPrice)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            ProfessionServices existingService = ServiceRepository.GetByIdAndUserId(serviceId, userId);
            if (existingService == null)
                throw new NoEntryFoundException(serviceId, userId, typeof(ProfessionServices).Name);

            existingService.ServiceName = serviceName;
            existingService.ServiceUnit = serviceUnit;
            existingService.ServiceUnitPrice = serviceUnitPrice;

            ServiceRepository.Update(existingService);
            return existingService;
        }
    }
}