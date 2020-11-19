using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AirQi.Models.Data
{
    [BsonIgnoreExtraElements]
    public class Measurement
    {
        [BsonElement]
        public double Pm025 { get; set; }

        [BsonElement]
        public double Pm100 { get; set; }

        [BsonElement]
        public double AirQi { get; set; }

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