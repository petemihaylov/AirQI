using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using AirQi.Models.Core;

namespace AssetNXT.Dtos.Core
{
    public class AgreementCreateDto
    {
        [MaxLength(250)]
        [Required]
        public List<Station> Stations { get; set; }

        [MaxLength(250)]
        [Required]
        public string Name { get; set; }

        [Required(AllowEmptyStrings = true)]
        public string Description { get; set; }

        [Required]
        public double AqiMin { get; set; }

        [Required]
        public double AqiMax { get; set; }
    }
}