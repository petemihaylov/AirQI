using System;
using System.Linq;
using ApiBase.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ApiBase.Data
{
    public class SqlRepository : IEFRepository
    {

        private readonly ApplicationContext _context;
        public SqlRepository(ApplicationContext context)
        {
            this._context = context;
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (_context.SaveChangesAsync().GetAwaiter().GetResult() >= 0);
        }

        public async Task<IEnumerable<T>> GetAllAsync<T>() where T : BaseEntity
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetByIdAsync<T>(int id) where T : BaseEntity
        {
            return await _context.Set<T>().SingleOrDefaultAsync(e => e.Id == id);
        }

        public async Task<T> AddAsync<T>(T entity) where T : BaseEntity
        {
            await _context.Set<T>().AddAsync(entity);
            await SaveChangesAsync();
            return entity;
        }

        public async Task UpdateAsync<T>(T entity) where T : BaseEntity
        {
            _context.Entry(entity).State = EntityState.Modified;
            await this.SaveChangesAsync();
        }

        public async Task DeleteAsync<T>(T entity) where T : BaseEntity
        {
            _context.Set<T>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public bool Exists<T>(T entity) where T : BaseEntity
        {
            return _context.Set<T>().Local.Any(e => e == entity);
        }
    }
}