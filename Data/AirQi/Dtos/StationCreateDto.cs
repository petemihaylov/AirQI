using AirQi.Models.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AirQi.Dtos
{
    public class StationCreateDto
    {
        [Required]
        public double  Aqi { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public IEnumerable<Measurement> Measurements { get; set; }

        [Required]
        public double[] Position { get; set; }

    }
}