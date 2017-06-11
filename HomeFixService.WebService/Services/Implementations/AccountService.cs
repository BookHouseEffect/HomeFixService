using HomeFixService.WebService.Services.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using HomeFixService.WebService.Models.EntityFramework;
using HomeFixService.WebService.Persistence.Implementations;
using HomeFixService.WebService.Models.Exeptions;
using HomeFixService.WebService.Security;

namespace HomeFixService.WebService.Services.Implementations
{
    public class AccountService : BaseService, AccountHelper
    {
        
        private CredentialsRepository CredentialsRepository;
        private ArchiveRepository ArchiveRepository;

        public AccountService() : base()
        {
            this.CredentialsRepository = new CredentialsRepository(
                this.UsersRepository.GetExistingDatabaseContext());
            this.ArchiveRepository = new ArchiveRepository(
                this.UsersRepository.GetExistingDatabaseContext());
        }


        public bool AssignUserCredentials(int userId, string userName, string password)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            Credentials existingCredentials = CredentialsRepository.FindByUserId(userId);
            if (existingCredentials != null)
                throw new ExistingCredentialsFoundException(userId, existingCredentials.Id);

            existingCredentials = CredentialsRepository.FindByUserName(userName);
            if (existingCredentials != null)
                throw new ExistingCredentialsFoundException(userName);


            HashedAndSaltedPassword hashAndSaltPassword = 
                PasswordHelper.CryptPassword(password);

            Credentials newCredentials = new Credentials
            {
                UserId = userId,
                UserName = userName,
                PasswordHash = hashAndSaltPassword.PasswordHash,
                PasswordSalt = hashAndSaltPassword.PasswordSalt
            };

            CredentialsRepository.Add(newCredentials);
            return true;
        }

        public bool ChangePassword(int userId, string userName, string oldPassword, string newPassword)
        {
            if (oldPassword == newPassword)
                throw new NewPasswordCannotBeAsOneOfOldPasswordsException();

            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            Credentials credentials = CredentialsRepository.FindByUserNameAndUserId(userId, userName);
            if (credentials == null)
                throw new NoEntryFoundException(userId, typeof(Credentials).Name);

            bool validPassword = CheckUserPassword(credentials, oldPassword);
            if (!validPassword)
                throw new InvalidPasswordException();

            bool value = CheckForPasswordHistory(userId, credentials.Id, newPassword);
            if (!value)
                return false;

            UserPasswordsHistory history = new UserPasswordsHistory
            {
                CredentialsId = credentials.Id,
                UserId = user.Id,
                PasswordHash = credentials.PasswordHash,
                PasswordSalt = credentials.PasswordSalt,
                ExpiredOn = DateTime.UtcNow
            };
            ArchiveRepository.Add(history);

            HashedAndSaltedPassword newPasswordHash = PasswordHelper.CryptPassword(newPassword);
            credentials.PasswordHash = newPasswordHash.PasswordHash;
            credentials.PasswordHash = newPasswordHash.PasswordSalt;
            CredentialsRepository.Update(credentials);

            return true;
        }

        public Credentials CheckCredentials(string userName, string password)
        {
            Credentials credentials = CredentialsRepository.FindByUserName(userName);
            if (credentials == null)
                throw new NoEntryFoundException(userName, typeof(Credentials).Name);

            if (credentials.TheUserForThisCredential == null)
                throw new NoEntryFoundException(userName, typeof(Users).Name);

            bool validPassword = CheckUserPassword(credentials, password);
            if (!validPassword)
                throw new InvalidPasswordException();

            return credentials;
        }

        public Users CreateUser(string firstName, string lastName)
        {
            Users user = new Users {
                UserFirstName = firstName,
                UserLastName = lastName
            };
            UsersRepository.Add(user);
            return user;
        }

        public Users GetUser(int userId)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);
            return user;
        }

        public bool RemoveUser(int userId, string userName, string password)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            Credentials credentials = CredentialsRepository.FindByUserNameAndUserId(userId, userName);
            if (credentials == null)
                throw new NoEntryFoundException(userId, typeof(Credentials).Name);

            bool validPassword = CheckUserPassword(credentials, password);
            if (!validPassword)
                throw new InvalidPasswordException();

            UsersRepository.Remove(user);
            return true;
        }

        public Users UpdateUserInfo(int userId, string firstName, string lastName)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            user.UserFirstName = firstName;
            user.UserLastName = firstName;
            UsersRepository.Update(user);
            return user;
        }

        private bool CheckUserPassword(Credentials credentials, string password)
        {
            HashedAndSaltedPassword passwordHash = new
                HashedAndSaltedPassword
            {
                PasswordHash = credentials.PasswordHash,
                PasswordSalt = credentials.PasswordSalt
            };
            return PasswordHelper.PasswordCompare(passwordHash, password);
        }

        private bool CheckForPasswordHistory(int userId, int credentialsId, string newPassword)
        {
            List<UserPasswordsHistory> userHistory =
                ArchiveRepository.GetByUserIdAndCredentialsId(userId, credentialsId).ToList();

            HashedAndSaltedPassword hash = new HashedAndSaltedPassword();
            foreach (UserPasswordsHistory history in userHistory)
            {
                hash.PasswordHash = history.PasswordHash;
                hash.PasswordSalt = history.PasswordSalt;
                bool check = PasswordHelper.PasswordCompare(hash, newPassword);
                if (check)
                    throw new NewPasswordCannotBeAsOneOfOldPasswordsException();
            }

            return true;
        }
    }
}