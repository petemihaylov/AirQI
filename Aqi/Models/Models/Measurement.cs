using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Aqi.Models.Models
{
    [BsonIgnoreExtraElements]
    public class Measurement
    {
        [BsonElement]
        public double Pm025 { get; set; }

        [BsonElement]
        public double Pm100 { get; set; }

        [BsonElement]
        public double Aqi { get; set; }

        [BsonElement]
        public double P { get; set; }

        [BsonElement]
        public double H { get; set; }

        [BsonElement]
        public double T { get; set; }

        [BsonElement]
        public double O3 { get; set; }

        [BsonElement]
        public double No2 { get; set; }


    }
}