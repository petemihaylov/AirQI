using AirQi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AirQi.Dtos
***REMOVED***
    public class StationCreateDto
    ***REMOVED***
        [Required]
        public string Location ***REMOVED*** get; set;***REMOVED***

        [Required]
        public string City ***REMOVED*** get; set;***REMOVED***

        [Required]
        public string Country ***REMOVED*** get; set;***REMOVED***

        [Required]
        public IEnumerable<Measurement> Measurements ***REMOVED*** get; set;***REMOVED***

        [Required]
        public Coordinates Coordinates ***REMOVED*** get; set;***REMOVED***

   ***REMOVED***
***REMOVED***