using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiBase.Models
{
    public class Role 
    {
        [Key]
        public int RoleId { get; set; }
        
        [MaxLength(250)]
        public string Name { get; set; }


        public User User { get; set; }
    }

    
}
