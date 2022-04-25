using AuthenticationService.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AuthenticationService.Data
{
    public interface IEFRepository
    {
        Task<IEnumerable<T>> GetAllAsync<T>() where T : BaseEntity;

        Task<T> GetByUserAsync<T>(string username, string password) where T : BaseEntity;
    }
}