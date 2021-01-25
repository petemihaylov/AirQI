using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using ApiBase.AcceptanceTests.Models;

namespace ApiBase.AcceptanceTests.Brokers
{
   public partial class ApiBaseBroker
   {
       private readonly string UsersRelativeUrl = "api/users";

       public async ValueTask<UserDto> CreateUserAsync(UserDto user) =>
           await this.apiFactoryClient.PostContentAsync(UsersRelativeUrl, user);


       public async ValueTask<UserDto> ReadUserByIdAsync(int id) =>
           await this.apiFactoryClient.GetContentAsync<UserDto>($"{UsersRelativeUrl}/{id}");

       public async ValueTask<List<User>> GetUsers() => await  this.apiFactoryClient.GetContentAsync<List<User>>($"{UsersRelativeUrl}");

       public async ValueTask<UserDto> DeleteUserByIdAsync(int id) =>
           await this.apiFactoryClient.DeleteContentAsync<UserDto>($"{UsersRelativeUrl}/{id}");
   }
}
