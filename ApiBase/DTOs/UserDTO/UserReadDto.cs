using ApiBase.Models;

namespace ApiBase.DTOs
{
    public class UserReadDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public int RoleId { get; set; }
    }
    
}
