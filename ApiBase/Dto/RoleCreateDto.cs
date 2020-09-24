
using System.ComponentModel.DataAnnotations;
using ApiBase.Models;

namespace ApiBase.Dto
{
    public class RoleCreateDto
    {     
           
        [MaxLength(250)]
        public string Name { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }  

    }
    
}
