using System;
using System.ComponentModel.DataAnnotations;

namespace ApiBase.Models
{
    public class Marker : BaseEntity
    {
        [Required]
        public double latitude { get; set; }

        [Required]
        public double longitude { get; set; }
    }

}
