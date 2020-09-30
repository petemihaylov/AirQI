using System;
using System.ComponentModel.DataAnnotations;

namespace ApiBase.Models
{
    public class User : BaseEntity
    {
        [MaxLength(250)]
        public string FirstName { get; set; }
        
        [MaxLength(250)]
        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }

        public int RoleId { get; set; }
        public Role UserRole { get; set; }
    
    
    }
    
}
