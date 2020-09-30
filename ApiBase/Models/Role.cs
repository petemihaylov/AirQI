using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ApiBase.Models
{
    public class Role : BaseEntity
    {
        
        [MaxLength(250)]
        public string Name { get; set; }

        public User User { get; set; }
    }

    
}
