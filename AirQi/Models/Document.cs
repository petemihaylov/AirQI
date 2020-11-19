using System;
using MongoDB.Bson;
using Aqi.Models.Data;

namespace Aqi.Models
{
    public abstract class Document : IDocument
    {
        public ObjectId Id { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
        public Location Location { get; set; }
    }
}