using System;
using MongoDB.Bson;
using AirQi.Models.Data;

namespace AirQi.Models
{
    public abstract class Document : IDocument
    {
        public ObjectId Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}