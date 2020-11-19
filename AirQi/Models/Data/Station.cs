using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AirQi.Repository;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AirQi.Models.Data
{
    [BsonCollection("stations")]
    public class Station : Document
    {

        [BsonElement]
        [MaxLength(50)]
        public string City { get; set; }

        [BsonElement]
        public Country Country { get; set; }

        [BsonElement]
        public IEnumerable<Measurement> Measurements { get; set; }

    }
}