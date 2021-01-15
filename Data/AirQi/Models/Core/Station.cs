using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AirQi.Repository;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AirQi.Models.Core
{
    [BsonCollection("stations")]
    public class Station : Document
    {
        [BsonElement]
        public double  Aqi { get; set; }
                    
        [BsonElement]
        public string Location { get; set; }

        [BsonElement]
        public string City { get; set; }

        [BsonElement]
        public string Country { get; set; }

        [BsonElement]
        public IEnumerable<Measurement> Measurements { get; set; }
    }
}