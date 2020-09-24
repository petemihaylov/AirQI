using System.Collections.Generic;
using ApiBase.Models;

namespace ApiBase.Data
***REMOVED***
    public interface IApplicationRepo
    ***REMOVED***
        bool SaveChanges();

        // User
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void CreateUser(User user);

        // Role

        IEnumerable<Role> GetAllRoles();
        void CreateRole(Role role);
    
   ***REMOVED***
***REMOVED***