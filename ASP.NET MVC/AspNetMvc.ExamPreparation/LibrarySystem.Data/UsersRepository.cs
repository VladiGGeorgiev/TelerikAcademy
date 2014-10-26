using System.Linq;
using LibrarySystem.Models;

namespace LibrarySystem.Data
{
    class UsersRepository : GenericRepository<ApplicationUser>, IUsersRepository
    {
        public UsersRepository(ApplicationDbContext context)
            : base(context)
        {
        }

        public ApplicationUser GetUserByUserId(string userId)
        {
            return base.DbSet.Find(userId);
        }

        public ApplicationUser GetUserByUsername(string username)
        {
            return base.DbSet.FirstOrDefault(x => x.UserName == username);
        }
    }
}
