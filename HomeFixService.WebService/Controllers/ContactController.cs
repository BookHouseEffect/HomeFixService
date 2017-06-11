using HomeFixService.WebService.Models.Api;
using HomeFixService.WebService.Models.EntityFramework;
using HomeFixService.WebService.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace HomeFixService.WebService.Controllers
{
    [Authorize]
    public class ContactController : BaseController
    {
        private ContactService ContactService;

        public ContactController()
        {
            ContactService = new ContactService();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/contact/number")]
        public IHttpActionResult GetAllContacts(int userId)
        {
            List<Contacts> existingContact;
            try
            {
                existingContact = ContactService.GetAllContactNumbers(userId);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(existingContact);
        }

        [HttpPost]
        [Route("api/contact/number")]
        public IHttpActionResult AddContactNumber(PhoneModel model)
        {
            if (!ModelState.IsValid)
                return InternalServerError(new Exception("Invalid model state"));

            Contacts newContact;
            try
            {
                Users currentUser = GetUser();
                newContact = ContactService.AddContactNumber(currentUser.Id, model.PhoneNumber);

            } catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(newContact);
        }

        [HttpPut]
        [Route("api/contact/number")]
        public IHttpActionResult UpdateContactNumber(int id, PhoneModel model)
        {
            if (!ModelState.IsValid)
                return InternalServerError(new Exception("Invalid model state"));

            Contacts updatedContact;
            try
            {
                Users currentUser = GetUser();
                updatedContact = ContactService.UpdateContactNumber(currentUser.Id, id, model.PhoneNumber);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(updatedContact);
        }

        [HttpDelete]
        [Route("api/contact/number")]
        public IHttpActionResult DeleteContactNumber(int id)
        {
            try
            {
                Users currentUser = GetUser();
                ContactService.RemoveContactNumber(currentUser.Id, id);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(true);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("api/contact/address")]
        public IHttpActionResult GetAllAddresses(int userId)
        {
            List<UserAddresses> existingContact;
            try
            {
                existingContact = ContactService.GetAllContactAddresses(userId);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(existingContact);
        }

        [HttpPost]
        [Route("api/contact/address")]
        public IHttpActionResult AddContactAddress(AddressModel model)
        {
            if (!ModelState.IsValid)
                return InternalServerError(new Exception("Invalid model state"));

            UserAddresses newAddress;
            try
            {
                Users currentUser = GetUser();
                newAddress = ContactService.AddContactAddress(
                    currentUser.Id, model.StreetName, model.City, model.Country);

            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(newAddress);
        }

        [HttpPut]
        [Route("api/contact/address")]
        public IHttpActionResult UpdateContactAddress(int id, AddressModel model)
        {
            if (!ModelState.IsValid)
                return InternalServerError(new Exception("Invalid model state"));

            UserAddresses updatedAddress;
            try
            {
                Users currentUser = GetUser();
                updatedAddress = ContactService.UpdateContactAddress(
                    currentUser.Id, id, model.StreetName, model.City, model.Country);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(updatedAddress);
        }

        [HttpDelete]
        [Route("api/contact/address")]
        public IHttpActionResult DeleteContactAddress(int id)
        {
            try
            {
                Users currentUser = GetUser();
                ContactService.RemoveContactAddress(currentUser.Id, id);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }

            return Ok(true);
        }
    }
}
