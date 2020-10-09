using System;
using System.ComponentModel.DataAnnotations;

namespace ApiJwt.Models
{
    public class User : BaseEntity
    {


        [MaxLength(250)]
        public string FirstName { get; set; }
        
        [MaxLength(250)]
        public string LastName { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public RoleEnum UserRole { get; set; }
    }

    public enum RoleEnum { Admin, Moderator, User } 
    
}
