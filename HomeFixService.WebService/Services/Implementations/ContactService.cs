using HomeFixService.WebService.Services.Helpers;
using System.Collections.Generic;
using HomeFixService.WebService.Models.EntityFramework;
using HomeFixService.WebService.Persistence.Implementations;
using HomeFixService.WebService.Models.Exeptions;
using System.Linq;

namespace HomeFixService.WebService.Services.Implementations
{
    public class ContactService : BaseService, ContactHelper
    {
        private AddressRepository AddressRepository;
        private ContactRepository ContactRepository;

        public ContactService() : base()
        {
            this.AddressRepository = new AddressRepository(
                UsersRepository.GetExistingDatabaseContext());
            this.ContactRepository = new ContactRepository(
                UsersRepository.GetExistingDatabaseContext());
        }

        public UserAddresses AddContactAddress(int userId, string streetName, string city, string country)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            UserAddresses address = new UserAddresses
            {
                UserId = user.Id,
                StreetName = streetName,
                City = city,
                Country = country
            };

            AddressRepository.Add(address);
            return address;
        }

        public Contacts AddContactNumber(int userId, string phoneNumber)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            Contacts existingContact = user.TheContactsForThisUser.Where(x => x.PhoneNumber.Equals(phoneNumber)).FirstOrDefault();
            if (existingContact != null)
                return existingContact;

            Contacts contact = new Contacts { UserId = user.Id, PhoneNumber = phoneNumber };
            ContactRepository.Add(contact);
            return contact;
        }

        public List<UserAddresses> GetAllContactAddresses(int userId)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            return user.TheAddressesThatThisUserWorksOn;
        }

        public List<Contacts> GetAllContactNumbers(int userId)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            return user.TheContactsForThisUser;
        }

        public bool RemoveContactAddress(int userId, int addressId)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            UserAddresses address = AddressRepository.FindByIdAndUserId(addressId, user.Id);
            if (address == null)
                throw new NoEntryFoundException(addressId, userId, typeof(UserAddresses).Name);

            AddressRepository.Remove(address);
            return true;
        }

        public bool RemoveContactNumber(int userId, int contactId)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            Contacts contact = ContactRepository.FindByIdAndUserId(contactId, user.Id);
            if (contact == null)
                throw new NoEntryFoundException(contactId, userId, typeof(Contacts).Name);

            ContactRepository.Remove(contact);
            return true;
        }

        public UserAddresses UpdateContactAddress(int userId, int addressId, string streetName, string city, string country)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            UserAddresses address = AddressRepository.FindByIdAndUserId(addressId, user.Id);
            if (address == null)
                throw new NoEntryFoundException(addressId, userId, typeof(UserAddresses).Name);

            address.StreetName = streetName;
            address.City = city;
            address.Country = country;
            AddressRepository.Update(address);

            return address;
        }

        public Contacts UpdateContactNumber(int userId, int contactId, string phoneNumber)
        {
            Users user = GetUserById(userId);
            if (user == null)
                throw new NoEntryFoundException(userId, typeof(Users).Name);

            Contacts contact = ContactRepository.FindByIdAndUserId(contactId, user.Id);
            if (contact == null)
                throw new NoEntryFoundException(contactId, userId, typeof(Contacts).Name);

            contact.PhoneNumber = phoneNumber;
            ContactRepository.Update(contact);

            return contact;
        }
    }
}