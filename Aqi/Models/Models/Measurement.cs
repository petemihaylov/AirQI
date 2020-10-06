using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Aqi.Models.Models
***REMOVED***
    [BsonIgnoreExtraElements]
    public class Measurement
    ***REMOVED***
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public int IdMeasurement  ***REMOVED*** get; set;***REMOVED***

        [BsonElement]
        [MaxLength(50)]
        public string Metric ***REMOVED*** get; set;***REMOVED***

        [BsonElement]
        public double Value ***REMOVED*** get; set;***REMOVED***


   ***REMOVED***
***REMOVED***