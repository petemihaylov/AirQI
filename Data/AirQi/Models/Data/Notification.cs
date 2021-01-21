using AirQi.Repository.Core;
using MongoDB.Bson.Serialization.Attributes;

namespace AirQi.Models.Data
***REMOVED***
    [BsonCollection("notifications")]
    public class Notification : Document
    ***REMOVED***
        [BsonElement]
        public string Title ***REMOVED*** get; set;***REMOVED***

        [BsonElement]
        public string Description ***REMOVED*** get; set;***REMOVED***

        [BsonElement]
        public double [] Position ***REMOVED*** get; set;***REMOVED***
   ***REMOVED***
***REMOVED***
