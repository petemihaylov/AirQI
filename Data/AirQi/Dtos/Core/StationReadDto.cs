using System;
using System.Collections.Generic;

namespace AirQi.Dtos.Core
{
    public class StationReadDto 
    {
        public string Id { get; set; }

        public double  Aqi { get; set; }
        
        public string Location { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public IEnumerable<MeasurementStationReadDto> Measurements { get; set; }

        public double[] Position { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}