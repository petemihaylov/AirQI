using AirQi.Models;
using AirQi.Models.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AirQi.Dtos
***REMOVED***
    public class StationCreateDto
    ***REMOVED***
        [Required]
        [MaxLength(50)]
        public string City ***REMOVED*** get; set;***REMOVED***

        [Required]
        public Country Country ***REMOVED*** get; set;***REMOVED***

        [Required]
        public Location Location ***REMOVED*** get; set;***REMOVED***

        [Required]
        public ICollection<Measurement> Measurements ***REMOVED*** get; set;***REMOVED***

   ***REMOVED***
***REMOVED***