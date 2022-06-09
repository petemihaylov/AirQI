using System;
using System.ComponentModel.DataAnnotations;

namespace UserService.Domain
{
    public class User
    {
        [Key]
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

        public bool IsActive { get; set; }

        public DateTime LastActive { get; set; }
    }
}
