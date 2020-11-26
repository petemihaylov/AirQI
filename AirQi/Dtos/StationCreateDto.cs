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
        public string Location { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Country { get; set; }

        [Required]
        public IEnumerable<Measurement> Measurements { get; set; }

        [Required]
        public Coordinates Coordinates { get; set; }

    }
}