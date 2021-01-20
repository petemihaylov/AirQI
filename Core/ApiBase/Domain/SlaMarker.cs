using System.ComponentModel.DataAnnotations;
using System;

namespace ApiBase.Models
{
    public class SlaMarker : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Count { get; set; }

        [Required]
        public int MaxValue { get; set; }

        public string LocationBoundaries {get; set; }

    }

}
