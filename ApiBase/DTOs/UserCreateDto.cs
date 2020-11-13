using System.ComponentModel.DataAnnotations;
using ApiBase.Models;

namespace ApiBase.DTOs
{
    public class UserCreateDto
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [MaxLength(250)]
        public string FirstName { get; set; }
        
        [MaxLength(250)]
        public string LastName { get; set; }
        public string UserRole { get; set; }
    }
    
}
