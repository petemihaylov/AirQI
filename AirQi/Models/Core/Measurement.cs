using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AirQi.Models.Core
***REMOVED***
    [BsonIgnoreExtraElements]
    public class Measurement : Document
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