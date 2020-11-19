using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Aqi.Repository;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Aqi.Models.Data
***REMOVED***
    [BsonCollection("stations")]
    public class Station : Document
    ***REMOVED***

        [BsonElement]
        [MaxLength(50)]
        public string City ***REMOVED*** get; set;***REMOVED***

        [BsonElement]
        public Country Country ***REMOVED*** get; set;***REMOVED***

        [BsonElement]
        public IEnumerable<Measurement> Measurements ***REMOVED*** get; set;***REMOVED***

   ***REMOVED***
***REMOVED***