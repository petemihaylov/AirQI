using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using AirQi.Models.Core;

namespace AirQi.Dtos.Core
{
    public class StationMeasurementCreateDto
    {

        [Required]
        public double  Aqi { get; set; }

        [Required]
        public IEnumerable<Measurement> Measurements { get; set; }

        [Required]
        public double[] Position { get; set; }

    }
}
