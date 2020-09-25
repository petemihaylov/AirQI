
using System.ComponentModel.DataAnnotations;
using ApiBase.Models;

namespace ApiBase.DTOs
{
    public class RoleCreateDto
    {     
           
        [MaxLength(250)]
        public string Name { get; set; }

    }
    
}
