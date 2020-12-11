using System.ComponentModel.DataAnnotations;

namespace ApiJwt.Models
{
    public class UserDto 
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserRole { get; set; }
        public string accessToken {get; set;}
    }
}
