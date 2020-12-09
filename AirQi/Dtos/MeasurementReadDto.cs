using System;
using AirQi.Models;
using AirQi.Models.Core;

namespace AirQi.Dtos
{
    public class MeasurementReadDto
    {
        
        public double  Aqi { get; set; }
        
        public string Parameter { get; set; }

        public double  Value { get; set; }

        public DateTime LastUpdated { get; set; }

        public string Unit { get; set; }
                
        public string SourceName { get; set; }

        public DateTime CreatedAt { get; set; }

        public Coordinates Coordinates { get; set; }
    }
}