using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiJwt.Models;

namespace ApiJwt.Data
{
    public class SqlRepository : IEFRepository
    {
        
        private readonly ApplicationContext _context;
        public SqlRepository(ApplicationContext context)
        {
            this._context = context;
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : BaseEntity
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByUsernameAsync<T>(string username) where T : BaseEntity
        {
            return await _context.Set<T>().SingleOrDefaultAsync(e => e.Username == username);
        }

   }
}