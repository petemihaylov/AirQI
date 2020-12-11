using System.Collections.Generic;
using System.Threading.Tasks;
using ApiBase.Models;

namespace ApiBase.Data
{
    public interface IEFRepository
    {
        Task<IEnumerable<T>> GetAllAsync<T>() where T: BaseEntity;
        Task<T> GetByIdAsync<T>(int id) where T: BaseEntity;
        Task<T> AddAsync<T>(T entity) where T: BaseEntity;
        Task UpdateAsync<T>(T entity) where T: BaseEntity;
        Task DeleteAsync<T>(T entity) where T: BaseEntity;
        bool Exists<T>(T entity) where T: BaseEntity;   
    }
}