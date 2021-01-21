using System;
using AirQi.Models;
using AirQi.Repository.Core;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AssetNXT.Models.Core.ServiceAgreement
***REMOVED***
    [BsonCollection("service_agreement_results")]
    public class ServiceAgreement : Document
    ***REMOVED***
        [BsonElement]
        public double[] Position ***REMOVED*** get; set;***REMOVED***

        [BsonElement]
        public bool IsAqiAgreementValid ***REMOVED*** get; set;***REMOVED***

        [BsonElement]
        public DateTime CreateDate ***REMOVED*** get; set;***REMOVED***
   ***REMOVED***
***REMOVED***