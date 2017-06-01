using HomeFixService.WebService.Models.Context;
using HomeFixService.WebService.Models.EntityFramework;
using System.Linq;

namespace HomeFixService.WebService.Persistence.Implementations
{
    public class AddressRepository : CrudRepository<UserAddresses>
    {
        public AddressRepository() : base() { }

        public AddressRepository(DatabaseContext context) : base(context) { }

        public UserAddresses FindByIdAndUserId(int addressId, int userId)
        {
            return DatabaseContext
                .UserAddresses
                .AsNoTracking()
                .Where(
                    x => x.Id == addressId
                    && x.UserId == userId
                ).SingleOrDefault();
        }
    }
}