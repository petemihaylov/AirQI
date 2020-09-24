
using System.ComponentModel.DataAnnotations;
using ApiBase.Models;

namespace ApiBase.Dto
{
    public class RoleReadDto
    {        
        public int RoleId { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }  

    }
    
}
