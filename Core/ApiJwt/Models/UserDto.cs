using System.ComponentModel.DataAnnotations;
using System;

namespace ApiJwt.Models
{
    public class UserDto 
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserRole { get; set; }
        public bool IsActive {get; set; }
        public DateTime LastActive {get; set;}
        public string accessToken {get; set;}
    }
}
