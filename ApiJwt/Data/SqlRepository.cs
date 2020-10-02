using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ApiJwt.Models;

namespace ApiJwt.Data
***REMOVED***
    public class SqlRepository : IEFRepository
    ***REMOVED***
        
        private readonly ApplicationContext _context;
        public SqlRepository(ApplicationContext context)
        ***REMOVED***
            this._context = context;
       ***REMOVED***

        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : BaseEntity
        ***REMOVED***
            return await _context.Set<T>().ToListAsync();
       ***REMOVED***

        public async Task<T> GetByUsernameAsync<T>(string firstName) where T : BaseEntity
        ***REMOVED***
            return await _context.Set<T>().SingleOrDefaultAsync(e => e.FirstName == firstName);
       ***REMOVED***

  ***REMOVED***
***REMOVED***