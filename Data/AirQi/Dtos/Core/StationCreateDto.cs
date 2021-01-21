using AirQi.Models.Core;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace AirQi.Dtos.Core
***REMOVED***
    public class StationCreateDto
    ***REMOVED***
        [Required]
        public double  Aqi ***REMOVED*** get; set;***REMOVED***

        [Required]
        public string Location ***REMOVED*** get; set;***REMOVED***

        [Required]
        public string City ***REMOVED*** get; set;***REMOVED***

        [Required]
        public string Country ***REMOVED*** get; set;***REMOVED***

        [Required]
        public IEnumerable<Measurement> Measurements ***REMOVED*** get; set;***REMOVED***

        [Required]
        public double[] Position ***REMOVED*** get; set;***REMOVED***

   ***REMOVED***
***REMOVED***