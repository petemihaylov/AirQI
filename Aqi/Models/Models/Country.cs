using System.ComponentModel.DataAnnotations;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Aqi.Models.Models
***REMOVED***
    [BsonIgnoreExtraElements]
    public class Country
    ***REMOVED***

        [BsonElement]
        [MaxLength(50)]
        public string Name ***REMOVED*** get; set;***REMOVED***

        [BsonElement]
        [MaxLength(3)]
        public string Code ***REMOVED*** get; set;***REMOVED***

   ***REMOVED***
***REMOVED***