using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AirQi.Models
***REMOVED***
    [BsonIgnoreExtraElements]
    public class Coordinates
    ***REMOVED***
        
        [BsonElement]
        public double Latitude ***REMOVED*** get; set;***REMOVED***

        [BsonElement]
        public double Longitude ***REMOVED*** get; set;***REMOVED***

   ***REMOVED***
***REMOVED***