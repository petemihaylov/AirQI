using System.Collections.Generic;
using AirQi.Models;
using AirQi.Models.Core;
using AirQi.Models.Data;
using AirQi.Repository.Core;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AssetNXT.Models.Core.ServiceAgreement
{
    [BsonCollection("agreements")]
    public class Agreement : Document
    {
        [BsonElement]
        public List<Station> Stations { get; set; }

        [BsonElement]
        public string Name { get; set; }

        [BsonElement]
        public string Description { get; set; }

        [BsonElement]
        public double AqiMin { get; set; }

        [BsonElement]
        public double AqiMax { get; set; }
    }
}