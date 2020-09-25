using System.ComponentModel.DataAnnotations;

namespace ApiBase.DTOs
{
    public class UserUpdateDto
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