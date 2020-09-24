using System;
using System.Collections.Generic;
using System.Linq;
using ApiBase.Models;

namespace ApiBase.Data
{
    public class SqlApplicationRepo : IApplicationRepo
    {
        
        private readonly ApplicationContext _context;

        public SqlApplicationRepo(ApplicationContext context)
        {
            this._context = context;
        }

        public void CreateRole(Role role)
        {
            if(role == null)
            {
                throw new ArgumentNullException(nameof(role));
            }
            this._context.Roles.Add(role);
        }

        public void CreateUser(User user)
        {
            if(user == null)
            {
                throw new ArgumentNullException(nameof(user));
            }

            this._context.Users.Add(user);
        
        }

        public IEnumerable<Role> GetAllRoles()
        {
           return this._context.Roles.ToList();
        }

        public IEnumerable<User> GetAllUsers()
        {
           return this._context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.UserId == id);
        }

        public bool SaveChanges()
        {
           return (_context.SaveChanges() >= 0);
        }
    }
}