using System.ComponentModel.DataAnnotations;

namespace ApiJwt.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }
        
        [MaxLength(250)]
        public string FirstName { get; set; }
    }
}