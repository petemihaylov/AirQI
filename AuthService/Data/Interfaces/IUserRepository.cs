using System.Collections.Generic;
using AuthService.Domain;

namespace AuthService.Data.Interfaces
{
    public interface IUserRepository : IGenericRepository<User>
    {
        bool DemandUserExist(string username);
        User GetByUsernameAndPassword(string username, string password);
    }
}
