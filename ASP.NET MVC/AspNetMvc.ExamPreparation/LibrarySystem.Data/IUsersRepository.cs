using LibrarySystem.Models;

namespace LibrarySystem.Data
{
    public interface IUsersRepository : IRepository<ApplicationUser>
    {
        ApplicationUser GetUserByUserId(string userId);

        ApplicationUser GetUserByUsername(string username);
    }
}
