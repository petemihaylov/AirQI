using System;
using AirQi.Models;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using AirQi.Models.Core;

namespace AirQi.Dtos
***REMOVED***
    public class StationMeasurementCreateDto
    ***REMOVED***

        [Required]
        public double  Aqi ***REMOVED*** get; set;***REMOVED***

        [Required]
        public IEnumerable<Measurement> Measurements ***REMOVED*** get; set;***REMOVED***

        [Required]
        public double[] Position ***REMOVED*** get; set;***REMOVED***

   ***REMOVED***
***REMOVED***
