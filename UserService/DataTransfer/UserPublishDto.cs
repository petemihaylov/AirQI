using System;

namespace UserService.DataTransfer
{
    public class UserPublishDto
    {
        public int Id { get; set; }
        public string Username { get; set; }

        public string Password { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }
        public string UserRole { get; set; }

        public bool IsActive { get; set; }

        public DateTime LastActive { get; set; }
        public string Event { get; set; }
    }
}
