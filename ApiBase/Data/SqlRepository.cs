using System;
using System.Linq;
using ApiBase.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApiBase.Data
***REMOVED***
    public class SqlRepository : IEFRepository
    ***REMOVED***
        
        private readonly ApplicationContext _context;
        public SqlRepository(ApplicationContext context)
        ***REMOVED***
            this._context = context;
       ***REMOVED***

        public async Task<bool> SaveChangesAsync()
        ***REMOVED***
           return  (_context.SaveChangesAsync().GetAwaiter().GetResult() >= 0);
       ***REMOVED***

        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : BaseEntity
        ***REMOVED***
            return await _context.Set<T>().ToListAsync();
       ***REMOVED***

        public async Task<T> GetByIdAsync<T>(int id) where T : BaseEntity
        ***REMOVED***
            return await _context.Set<T>().SingleOrDefaultAsync(e => e.Id == id);
       ***REMOVED***

        public async Task<T> AddAsync<T>(T entity) where T : BaseEntity
        ***REMOVED***
            await _context.Set<T>().AddAsync(entity);
            await SaveChangesAsync();
            return entity;
       ***REMOVED***

        public async Task UpdateAsync<T>(T entity) where T : BaseEntity
        ***REMOVED***
            _context.Entry(entity).State = EntityState.Modified;
            await this.SaveChangesAsync();
       ***REMOVED***

        public async Task DeleteAsync<T>(T entity) where T : BaseEntity
        ***REMOVED***
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
       ***REMOVED***

        public bool Exists<T>(T entity) where T : BaseEntity
        ***REMOVED***
            return _context.Set<T>().Local.Any(e => e == entity);
       ***REMOVED***
   ***REMOVED***
***REMOVED***