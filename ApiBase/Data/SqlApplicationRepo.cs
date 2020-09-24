using System;
using System.Collections.Generic;
using System.Linq;
using ApiBase.Models;

namespace ApiBase.Data
***REMOVED***
    public class SqlApplicationRepo : IApplicationRepo
    ***REMOVED***
        
        private readonly ApplicationContext _context;

        public SqlApplicationRepo(ApplicationContext context)
        ***REMOVED***
            this._context = context;
       ***REMOVED***

        public void CreateRole(Role role)
        ***REMOVED***
            if(role == null)
            ***REMOVED***
                throw new ArgumentNullException(nameof(role));
           ***REMOVED***
            this._context.Roles.Add(role);
       ***REMOVED***

        public void CreateUser(User user)
        ***REMOVED***
            if(user == null)
            ***REMOVED***
                throw new ArgumentNullException(nameof(user));
           ***REMOVED***

            this._context.Users.Add(user);
        
       ***REMOVED***

        public IEnumerable<Role> GetAllRoles()
        ***REMOVED***
           return this._context.Roles.ToList();
       ***REMOVED***

        public IEnumerable<User> GetAllUsers()
        ***REMOVED***
           return this._context.Users.ToList();
       ***REMOVED***

        public User GetUserById(int id)
        ***REMOVED***
            return _context.Users.FirstOrDefault(u => u.UserId == id);
       ***REMOVED***

        public bool SaveChanges()
        ***REMOVED***
           return (_context.SaveChanges() >= 0);
       ***REMOVED***
   ***REMOVED***
***REMOVED***