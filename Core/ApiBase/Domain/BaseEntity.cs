using System.ComponentModel.DataAnnotations;

namespace ApiBase.Models
{
    public abstract class BaseEntity
    {
        [Key]
        public int Id { get; set; }

    }
}