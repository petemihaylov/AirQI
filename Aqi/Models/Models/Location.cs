using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Aqi.Models.Models
{
    [BsonIgnoreExtraElements]
    public class Location
    {
    
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int IdLocation  { get; set; }

        [BsonElement]
        public double Accuracy { get; set; }
        
        [BsonElement]
        public double Latitude { get; set; }

        [BsonElement]
        public double Longitude { get; set; }

    }
}