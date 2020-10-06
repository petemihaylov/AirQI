using Aqi.Models;
using System;
using MongoDB.Bson;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MongoDB.Bson.Serialization.Attributes;

namespace Aqi.Dtos
{
    public class StationReadDto
    {
        public ObjectId Id { get; set; }

        // public City City { get; set; }

        // public Country Country { get; set; }

        // public Location Location { get; set; }
        
        // public ICollection<Measurement> Measurements { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}