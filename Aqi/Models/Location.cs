using System.ComponentModel.DataAnnotations;

namespace Aqi.Models
{
    public class Location
    {
    
        [Key]
        public int IdLocation  { get; set; }

        [Required]
        public double Accuracy { get; set; }
        
        [Required]
        public double Latitude { get; set; }

        [Required]
        public double Longitude { get; set; }

    }
}