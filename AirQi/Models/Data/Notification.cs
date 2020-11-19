using Aqi.Repository;
using MongoDB.Bson.Serialization.Attributes;

namespace Aqi.Models.Data
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
