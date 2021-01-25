using System;
using System.Collections.Generic;
using MongoDB.Bson;

namespace AirQi.Models
{
    public abstract class Document : IDocument
    {
        public ObjectId Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}