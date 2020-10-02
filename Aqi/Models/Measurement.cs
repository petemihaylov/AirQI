using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aqi.Models
{
    public class Measurement
    {
        [Key]
        public int IdMeasurement  { get; set; }

        [Required]
        [MaxLength(50)]
        public string Metric { get; set; }

        [Required]
        public double Value { get; set; }

        [ForeignKey("Station")]
        public int StationFK { get; set; } 

    }
}