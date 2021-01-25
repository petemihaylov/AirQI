using System.ComponentModel.DataAnnotations;
using ApiBase.Models;
using System;

namespace ApiBase.DTOs
{
    public class UserDto
    {
        
        public int Id { get; set; }

        [Required]
        public string Username { get; set; }

        [Required]
        public string Password { get; set; }

        [MaxLength(250)]
        public string FirstName { get; set; }
        
        [MaxLength(250)]
        public string LastName { get; set; }
        
        public string UserRole { get; set; }

        public bool IsActive {get; set; }

        public DateTime LastActive {get; set;}
    }
    
}
