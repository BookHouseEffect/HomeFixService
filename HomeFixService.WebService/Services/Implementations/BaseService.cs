using HomeFixService.WebService.Models.EntityFramework;
using HomeFixService.WebService.Persistence.Implementations;

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