using System;
using AirQi.Models;
using AirQi.Repository.Core;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AssetNXT.Models.Core.ServiceAgreement
{
    [BsonCollection("service_agreement_results")]
    public class ServiceAgreement : Document
    {
        [BsonElement]
        public double[] Position { get; set; }

        [BsonElement]
        public bool IsAqiAgreementValid { get; set; }

        [BsonElement]
        public DateTime CreateDate { get; set; }
    }
}