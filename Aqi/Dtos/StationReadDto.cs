using Aqi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aqi.Dtos
{
    public class StationReadDto
    {
        public City City { get; set; }

        public Country Country { get; set; }

        public Location Location { get; set; }
        
        public ICollection<Measurement> Measurements { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}