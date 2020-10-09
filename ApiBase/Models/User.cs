using System;
using System.ComponentModel.DataAnnotations;

namespace ApiBase.Models
{
    public class User : BaseEntity
    {
        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [MaxLength(250)]
        public string FirstName { get; set; }
        
        [MaxLength(250)]
        public string LastName { get; set; }
        public RoleEnum UserRole {get; set; }
    }
    
}
