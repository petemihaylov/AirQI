using System;
using AirQi.Models;
using AirQi.Repository.Core;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AirQi.Models.Data
***REMOVED***
    [BsonCollection("service_agreement_results")]
    public class ServiceAgreement : Document
    ***REMOVED***
        [BsonElement]
        public double[] Position ***REMOVED*** get; set;***REMOVED***

        [BsonElement]
        public bool IsAqiAgreementValid ***REMOVED*** get; set;***REMOVED***

        [BsonElement]
        public DateTime StationLastUpdate ***REMOVED*** get; set;***REMOVED***
   ***REMOVED***
***REMOVED***