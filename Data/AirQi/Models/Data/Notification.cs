using AirQi.Repository.Core;
using MongoDB.Bson.Serialization.Attributes;

namespace AirQi.Models.Data
{
    [BsonCollection("notifications")]
    public class Notification : Document
    {
        [BsonElement]
        public string Title { get; set; }

        [BsonElement]
        public string Description { get; set; }

        [BsonElement]
        public double [] Position { get; set; }
    }
}
