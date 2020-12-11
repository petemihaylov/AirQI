using System.Collections.Generic;
using System.Threading.Tasks;
using ApiJwt.Models;

namespace ApiJwt.Data
***REMOVED***
    public interface IEFRepository
    ***REMOVED***
        Task<IEnumerable<T>> GetAllAsync<T>() where T: BaseEntity;
        
        Task<T> GetByUserAsync<T>(string username, string password) where T : BaseEntity;
   ***REMOVED***
***REMOVED***