using System;
using System.Collections.Generic;
using AirQi.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AirQi.Models.Core
{
    public interface IDocument
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        ObjectId Id { get; set; }

        DateTime CreatedAt { get; set; }

        DateTime UpdatedAt { get; set; }

        double[] Position { get; set; }
    }
}