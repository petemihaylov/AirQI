using System;
using AirQi.Models.Data;

namespace AirQi.Dtos
{
    public class MeasurementReadDto
    {
        public string Parameter { get; set; }

        public double  Value { get; set; }

        public DateTime LastUpdated { get; set; }

        public string Unit { get; set; }
                
        public string SourceName { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}