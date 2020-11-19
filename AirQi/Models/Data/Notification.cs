using AirQi.Repository;
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
    }
}
