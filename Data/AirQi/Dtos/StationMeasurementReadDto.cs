using AirQi.Models.Core;
using System;
using MongoDB.Bson;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace AirQi.Dtos
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