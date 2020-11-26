﻿using System;
using AirQi.Models.Data;
using System.ComponentModel.DataAnnotations;

namespace AirQi.Dtos
{
    public class MeasurementCreateDto
    {
        [Required]
        public string Parameter { get; set; }

        [Required]
        public double  Value { get; set; }

        [Required]
        public DateTime LastUpdated { get; set; }

        [Required]
        public string Unit { get; set; }
                
        [Required]
        public string SourceName { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }
    }
}
