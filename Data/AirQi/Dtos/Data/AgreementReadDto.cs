using System;
using System.Collections.Generic;
using AirQi.Models.Core;

namespace AirQi.Dtos.Core
{
    public class AgreementReadDto
    {
        public string Id { get; set; }

        public List<Station> Stations { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double AqiMin { get; set; }

        public double AqiMax { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}