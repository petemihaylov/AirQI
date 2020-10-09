using System.ComponentModel.DataAnnotations;

namespace ApiJwt.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
 
        public string Username { get; set; }
    }
}