using AirQi.Models;
using System;
using MongoDB.Bson;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;
using AirQi.Models.Data;

namespace AirQi.Dtos
{
    public class StationReadDto 
    {
        public string Id { get; set; }

        public string City { get; set; }
  
        public Country Country { get; set; }
      
        public Location Location { get; set; }
      
        public ICollection<Measurement> Measurements { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}