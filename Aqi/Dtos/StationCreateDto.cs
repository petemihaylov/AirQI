using Aqi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aqi.Dtos
{
    public class StationCreateDto
    {
        // [Required]
        // public City City { get; set; }

        // [Required]
        // public Country Country { get; set; }

        // [Required]
        // public Location Location { get; set; }

        // [Required]
        // public ICollection<Measurement> Measurements { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime CreatedAt { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime UpdatedAt { get; set; }
    }
}