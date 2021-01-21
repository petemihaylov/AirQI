using System;
using System.Collections.Generic;

namespace AirQi.Dtos.Core
{
    public class StationMeasurementReadDto 
    {
        public string Id { get; set; }

        public double  Aqi { get; set; }

        public IEnumerable<MeasurementReadDto> Measurements { get; set; }

        public double[] Position { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}