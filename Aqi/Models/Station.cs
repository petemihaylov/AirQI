using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aqi.Models
{
    public class Station
    {
        
        [Key]
        public int IdStation { get; set; }

        [Required]
        public City City { get; set; }

        [Required]
        public Country Country { get; set; }

        [Required]
        public Location Location { get; set; }

        [Required]
        public ICollection<Measurement> Measurements { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime UpdatedAt { get; set; }

    }
}