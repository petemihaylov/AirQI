using System.ComponentModel.DataAnnotations;
using System;

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

        public string UserRole { get; set; }

        public bool IsActive {get; set; }

        public DateTime LastActive {get; set;}
    }

}
