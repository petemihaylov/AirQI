using System.Collections.Generic;
using System.Linq;
using UserService.Data.Interfaces;
using UserService.Domain;

namespace UserService.Data
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {

        }

        public IEnumerable<User> GetAllUsers()
        {
            return _context.Users;
        }

        public User GetByUsername(string username) => _context.Users.Where(u => u.Username.Equals(username)).First();

        public User UpdateUser(User user) => _context.Users.Update(user).Entity;

        public bool DemandUserExist(string username) => _context.Users.Where(u => u.Username.Equals(username) && u.IsActive == true).Any();

        public User DeleteUser(User user) => _context.Users.Remove(user).Entity;
        public User AddUser(User user) => _context.Users.Add(user).Entity;
    }
}