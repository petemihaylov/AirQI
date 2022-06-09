using AuthService.Data.Interfaces;
using AuthService.Domain;
using System.Linq;

namespace AuthService.Data
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context) { }

        public User GetByUsernameAndPassword(string username, string password)
        {
            try
            {
                return _context.Users.Where(u => u.Username.Equals(username) && u.Password.Equals(password) && u.IsActive == true).First();
            }
            catch (System.Exception e)
            {

                throw new System.Exception($"User cannot be found! {e}");
            }
        }

        public bool DemandUserExist(string username) => _context.Users.Where(u => u.Username.Equals(username) && u.IsActive == true).Any();
    }
}