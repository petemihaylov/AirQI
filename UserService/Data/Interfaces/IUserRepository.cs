using System.Collections.Generic;
using UserService.Domain;

namespace UserService.Data.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        IEnumerable<User> GetAllUsers();

        User GetByUsername(string username);

        User UpdateUser(User user);

        User DeleteUser(User user);

        User AddUser(User user);

        bool DemandUserExist(string username);
    }
}
