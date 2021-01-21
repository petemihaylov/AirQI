
using AirQi.Models;
using System.Collections.Generic;
using AirQi.Repository.Core;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AirQi.Models.Core
***REMOVED***
    [BsonCollection("stations")]
    public class Station : Document
    ***REMOVED***
        [BsonElement]
        public double  Aqi ***REMOVED*** get; set;***REMOVED***
                    
        [BsonElement]
        public string Location ***REMOVED*** get; set;***REMOVED***

        [BsonElement]
        public string City ***REMOVED*** get; set;***REMOVED***

        [BsonElement]
        public string Country ***REMOVED*** get; set;***REMOVED***

        [BsonElement]
        public double [] Position ***REMOVED*** get; set;***REMOVED***

        [BsonElement]
        public IEnumerable<Measurement> Measurements ***REMOVED*** get; set;***REMOVED***
   ***REMOVED***
***REMOVED***