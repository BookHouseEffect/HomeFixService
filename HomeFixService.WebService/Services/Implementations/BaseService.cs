using HomeFixService.WebService.Models.EntityFramework;
using HomeFixService.WebService.Persistence.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HomeFixService.WebService.Services.Implementations
{
    public abstract class BaseService
    {
        protected UsersRepository UsersRepository;

        protected BaseService()
        {
            this.UsersRepository = new UsersRepository();
        }

        protected Users GetUserById(int userId)
        {
            return UsersRepository.FindById(userId);
        }

    }
}