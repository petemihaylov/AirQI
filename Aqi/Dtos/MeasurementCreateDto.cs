﻿using System;
using Aqi.Models.Data;
using System.ComponentModel.DataAnnotations;

namespace Aqi.Dtos
{
    public class MeasurementCreateDto
    {
        [Required]
        public Location Location { get; set; }

        [Required]
        public double Pm025 { get; set; }

        [Required]
        public double Pm100 { get; set; }

        [Required]
        public double Aqi { get; set; }

        [Required]
        public double P { get; set; }

        [Required]
        public double H { get; set; }

        [Required]
        public double T { get; set; }

        [Required]
        public double O3 { get; set; }

        [Required]
        public double No2 { get; set; }

        [Required]
        public DateTime CreatedAt { get; set; }

        [Required]
        public DateTime UpdatedAt { get; set; }
    }
}
