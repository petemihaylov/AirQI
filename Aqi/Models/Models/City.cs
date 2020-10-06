using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Aqi.Models.Models
{
    [BsonIgnoreExtraElements]
    public class City
    {
    
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int IdCity  { get; set; }

        [BsonElement]
        [MaxLength(50)]
        public string Name { get; set; }
        
        [BsonElement]
        public Country Country { get; set; }

        [BsonElement]
        public Location Location { get; set; }

    }
}