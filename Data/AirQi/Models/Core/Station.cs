
using AirQi.Models;
using System.Collections.Generic;
using AirQi.Repository.Core;
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
        public double [] Position { get; set; }

        [BsonElement]
        public IEnumerable<Measurement> Measurements { get; set; }
    }
}