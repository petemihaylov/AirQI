using System.ComponentModel.DataAnnotations;
using ApiBase.Models;

namespace ApiBase.DTOs
{
    public class UserCreateDto
    {
        [MaxLength(250)]
        public string FirstName { get; set; }
        
        [MaxLength(250)]
        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }
        
        public int RoleId { get; set; }
    }
    
}
