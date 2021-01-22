using System.Collections.Generic;
using AirQi.Models.Core;
using AirQi.Repository.Core;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AirQi.Models.Data
***REMOVED***
    [BsonCollection("agreements")]
    public class Agreement : Document
    ***REMOVED***
        [BsonElement]
        public List<Station> Stations ***REMOVED*** get; set;***REMOVED***

        [BsonElement]
        public string Name ***REMOVED*** get; set;***REMOVED***

        [BsonElement]
        public string Description ***REMOVED*** get; set;***REMOVED***

        [BsonElement]
        public double AqiMin ***REMOVED*** get; set;***REMOVED***

        [BsonElement]
        public double AqiMax ***REMOVED*** get; set;***REMOVED***
   ***REMOVED***
***REMOVED***