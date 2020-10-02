using System.ComponentModel.DataAnnotations;

namespace Aqi.Models
{
    public class Country
    {
    
        [Key]
        public int IdCountry { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        [Required]
        [MaxLength(3)]
        public string Code { get; set; }

    }
}