using ApiBase.Models;

namespace ApiBase.Dto
{
    public class UserReadDto
    {
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public Role UserRole { get; set; }
    }
    
}
