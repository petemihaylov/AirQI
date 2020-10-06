using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Aqi.Models.Models
***REMOVED***
    [BsonIgnoreExtraElements]
    public class City
    ***REMOVED***
    
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int IdCity  ***REMOVED*** get; set;***REMOVED***

        [BsonElement]
        [MaxLength(50)]
        public string Name ***REMOVED*** get; set;***REMOVED***
        
        [BsonElement]
        public Country Country ***REMOVED*** get; set;***REMOVED***

        [BsonElement]
        public Location Location ***REMOVED*** get; set;***REMOVED***

   ***REMOVED***
***REMOVED***