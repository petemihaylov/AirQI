using System.ComponentModel.DataAnnotations;
using ApiBase.Models;

namespace ApiBase.Dto
{
    public class UserCreateDto
    {
        [MaxLength(250)]
        public string FirstName { get; set; }
        
        [MaxLength(250)]
        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }
        public Role UserRole { get; set; }
    }
    
}
