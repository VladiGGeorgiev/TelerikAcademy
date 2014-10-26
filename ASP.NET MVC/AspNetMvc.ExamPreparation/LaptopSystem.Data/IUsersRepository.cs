using LaptopSystem.Models;

namespace LaptopSystem.Data
{
    public interface IUsersRepository : IRepository<ApplicationUser>
    {
        ApplicationUser GetUserByUserId(string userId);

        ApplicationUser GetUserByUsername(string username);
    }
}
