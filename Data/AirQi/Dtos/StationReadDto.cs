using AirQi.Models.Core;
using System;
using MongoDB.Bson;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace AirQi.Dtos
{
    public class StationReadDto 
    {
        public string Id { get; set; }

        public double  Aqi { get; set; }
        
        public string Location { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public IEnumerable<Measurement> Measurements { get; set; }

        public Coordinates Coordinates { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}