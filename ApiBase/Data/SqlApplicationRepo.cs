using System;
using System.Linq;
using ApiBase.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApiBase.Data
{
    public class SqlApplicationRepo : IApplicationRepo
    {
        
        private readonly ApplicationContext _context;
        public SqlApplicationRepo(ApplicationContext context)
        {
            this._context = context;
        }



        public async Task CreateRole(Role role)
        {
            if(role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
          await  this._context.Roles.AddAsync(role);
        }

        public async Task CreateUser(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            await this._context.Users.AddAsync(user);

        }


        public bool Exists(User user)
        {
            return _context.Exists(user);
        }

        public bool Exists(Role role)
        {
            return _context.Exists(role);
        }



        public void DeleteRole(Role role)
        {
            if(role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }

            this._context.Roles.Remove(role);
        }

        public void DeleteUser(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            this._context.Users.Remove(user);
        }



        public IEnumerable<Role> GetAllRoles()
        {
           return this._context.Roles.ToList();
        }

        public IEnumerable<User> GetAllUsers()
        {
           return this._context.Users.ToList();
        }



        public Role GetRoleById(int id)
        {
            return _context.Roles.FirstOrDefault(r => r.RoleId == id);
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == id);
        }



        public async Task<bool> SaveChanges()
        {
           return  (await _context.SaveChangesAsync() >= 0);
        }

        public void UpdateUser(User user) { }
    }
}