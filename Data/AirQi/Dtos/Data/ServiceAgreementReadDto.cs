using System;

namespace AirQi.Dtos.Data
{
    public class ServiceAgreementReadDto
    {

        public double[] Position { get; set; }

        public bool IsAqiAgreementValid { get; set; }

        public DateTime CreateDate { get; set; }

        public DateTime UpdateAt { get; set; }
    }
}