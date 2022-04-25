using System.ComponentModel.DataAnnotations;

namespace ApiBase.AcceptanceTests.Models
{
    public class User 
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
    }

}
