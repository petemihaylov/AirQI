using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Aqi.Models.Models
{
    [BsonIgnoreExtraElements]
    public class Measurement
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int IdMeasurement  { get; set; }

        [BsonElement]
        [MaxLength(50)]
        public string Metric { get; set; }

        [BsonElement]
        public double Value { get; set; }


    }
}