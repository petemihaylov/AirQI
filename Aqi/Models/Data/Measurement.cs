using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Aqi.Models.Data
***REMOVED***
    [BsonIgnoreExtraElements]
    public class Measurement
    ***REMOVED***
        [BsonElement]
        public double Pm025 ***REMOVED*** get; set;***REMOVED***

        [BsonElement]
        public double Pm100 ***REMOVED*** get; set;***REMOVED***

        [BsonElement]
        public double Aqi ***REMOVED*** get; set;***REMOVED***

        [BsonElement]
        public double P ***REMOVED*** get; set;***REMOVED***

        [BsonElement]
        public double H ***REMOVED*** get; set;***REMOVED***

        [BsonElement]
        public double T ***REMOVED*** get; set;***REMOVED***

        [BsonElement]
        public double O3 ***REMOVED*** get; set;***REMOVED***

        [BsonElement]
        public double No2 ***REMOVED*** get; set;***REMOVED***


   ***REMOVED***
***REMOVED***