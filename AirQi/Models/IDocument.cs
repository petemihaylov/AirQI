using System;
using AirQi.Models.Data;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AirQi.Models
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        ObjectId Id { get; set; }

        DateTime CreatedAt { get; set; }

        DateTime UpdatedAt { get; set; }
        public Location Location { get; set; }
    }
}