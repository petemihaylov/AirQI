using System.ComponentModel.DataAnnotations;

namespace Aqi.Models
{
    public class City
    {
    
        [Key]
        public int IdCity  { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }
        
        [Required]
        public Country Country { get; set; }

        [Required]
        public Location Location { get; set; }

    }
}