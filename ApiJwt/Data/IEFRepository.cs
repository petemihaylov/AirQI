using System.Collections.Generic;
using System.Threading.Tasks;
using ApiJwt.Models;

namespace ApiJwt.Data
{
    public interface IEFRepository
    {
        Task<IEnumerable<T>> GetAllAsync<T>() where T: BaseEntity;
        
        Task<T> GetByUserAsync<T>(string username, string password) where T : BaseEntity;
    }
}