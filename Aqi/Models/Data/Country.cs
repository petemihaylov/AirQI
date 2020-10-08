using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Aqi.Models.Data
{
    [BsonIgnoreExtraElements]
    public class Country
    {

        [BsonElement]
        [MaxLength(50)]
        public string Name { get; set; }

        [BsonElement]
        [MaxLength(3)]
        public string Code { get; set; }

    }
}