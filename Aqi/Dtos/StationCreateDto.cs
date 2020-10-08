using Aqi.Models;
using Aqi.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aqi.Dtos
{
    public class StationCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string City { get; set; }

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