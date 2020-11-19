using AirQi.Models;
using AirQi.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AirQi.Dtos
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

    }
}