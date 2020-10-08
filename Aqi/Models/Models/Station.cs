using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Aqi.Repository;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Aqi.Models.Models
{
    [BsonCollection("station")]
    public class Station : Document
    {

        [BsonElement]
        [MaxLength(50)]
        public string City { get; set; }

        [BsonElement]
        public Country Country { get; set; }

        [BsonElement]
        public Location Location { get; set; }

        [BsonElement]
        public IEnumerable<Measurement> Measurements { get; set; }

    }
}