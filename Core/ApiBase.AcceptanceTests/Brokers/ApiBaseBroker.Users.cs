using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApiBase.AcceptanceTests.Models;

namespace ApiBase.AcceptanceTests.Brokers
***REMOVED***
   public partial class ApiBaseBroker
   ***REMOVED***
       private readonly string UsersRelativeUrl = "api/users";

       public async ValueTask<UserDto> CreateUserAsync(UserDto user) =>
           await this.apiFactoryClient.PostContentAsync(UsersRelativeUrl, user);


       public async ValueTask<UserDto> ReadUserByIdAsync(int id) =>
           await this.apiFactoryClient.GetContentAsync<UserDto>($"***REMOVED***UsersRelativeUrl***REMOVED***/***REMOVED***id***REMOVED***");

       public async ValueTask<List<User>> GetUsers() => await  this.apiFactoryClient.GetContentAsync<List<User>>($"***REMOVED***UsersRelativeUrl***REMOVED***");

       public async ValueTask<UserDto> DeleteUserByIdAsync(int id) =>
           await this.apiFactoryClient.DeleteContentAsync<UserDto>($"***REMOVED***UsersRelativeUrl***REMOVED***/***REMOVED***id***REMOVED***");
  ***REMOVED***
***REMOVED***
