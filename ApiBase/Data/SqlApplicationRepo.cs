using System;
using System.Linq;
using ApiBase.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiBase.Data
***REMOVED***
    public class SqlApplicationRepo : IApplicationRepo
    ***REMOVED***
        
        private readonly ApplicationContext _context;
        public SqlApplicationRepo(ApplicationContext context)
        ***REMOVED***
            this._context = context;
       ***REMOVED***



        public async Task CreateRole(Role role)
        ***REMOVED***
            if(role == null)
            ***REMOVED***
                throw new ArgumentNullException(nameof(role));
           ***REMOVED***
          await  this._context.Roles.AddAsync(role);
       ***REMOVED***

        public async Task CreateUser(User user)
        ***REMOVED***
            if(user == null)
            ***REMOVED***
                throw new ArgumentNullException(nameof(user));
           ***REMOVED***

            await this._context.Users.AddAsync(user);

       ***REMOVED***


        public bool Exists(User user)
        ***REMOVED***
            return _context.Exists(user);
       ***REMOVED***

        public bool Exists(Role role)
        ***REMOVED***
            return _context.Exists(role);
       ***REMOVED***



        public void DeleteRole(Role role)
        ***REMOVED***
            if(role == null)
            ***REMOVED***
                throw new ArgumentNullException(nameof(role));
           ***REMOVED***

            this._context.Roles.Remove(role);
       ***REMOVED***

        public void DeleteUser(User user)
        ***REMOVED***
            if(user == null)
            ***REMOVED***
                throw new ArgumentNullException(nameof(user));
           ***REMOVED***

            this._context.Users.Remove(user);
       ***REMOVED***



        public IEnumerable<Role> GetAllRoles()
        ***REMOVED***
           return this._context.Roles.ToList();
       ***REMOVED***

        public IEnumerable<User> GetAllUsers()
        ***REMOVED***
           return this._context.Users.ToList();
       ***REMOVED***



        public Role GetRoleById(int id)
        ***REMOVED***
            return _context.Roles.FirstOrDefault(r => r.RoleId == id);
       ***REMOVED***

        public User GetUserById(int id)
        ***REMOVED***
            return _context.Users.FirstOrDefault(u => u.UserId == id);
       ***REMOVED***



        public async Task<bool> SaveChanges()
        ***REMOVED***
           return  (await _context.SaveChangesAsync() >= 0);
       ***REMOVED***

        public void UpdateUser(User user) ***REMOVED******REMOVED***
   ***REMOVED***
***REMOVED***