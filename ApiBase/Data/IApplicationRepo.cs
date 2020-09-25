using System.Collections.Generic;
using System.Threading.Tasks;
using ApiBase.Models;

namespace ApiBase.Data
{
    public interface IApplicationRepo
    {
        Task<bool> SaveChanges();

        // User
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        Task CreateUser(User user);
        void UpdateUser(User user); 
        void DeleteUser(User user);
        bool Exists(User user);


        // Role
        Role GetRoleById(int id);
        IEnumerable<Role> GetAllRoles();
        Task CreateRole(Role role);
        void DeleteRole(Role role);
        bool Exists(Role role);
    
    }
}