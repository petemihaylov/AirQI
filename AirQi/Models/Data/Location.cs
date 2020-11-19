using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Aqi.Models.Data
{
    [BsonIgnoreExtraElements]
    public class Location
    {
    
        [BsonElement]
        public double Accuracy { get; set; }
        
        [BsonElement]
        public double Latitude { get; set; }

        [BsonElement]
        public double Longitude { get; set; }

    }
}