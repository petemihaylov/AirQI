using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AirQi.Models.Data
***REMOVED***
    [BsonIgnoreExtraElements]
    public class Measurement
    ***REMOVED***
        [BsonElement]
        public string Parameter ***REMOVED*** get; set;***REMOVED***

        [BsonElement]
        public double  Value ***REMOVED*** get; set;***REMOVED***

        [BsonElement]
        public DateTime LastUpdated ***REMOVED*** get; set;***REMOVED***

        [BsonElement]
        public string Unit ***REMOVED*** get; set;***REMOVED***
                
        [BsonElement]
        public string SourceName ***REMOVED*** get; set;***REMOVED***

   ***REMOVED***
***REMOVED***