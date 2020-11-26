using System;
using AirQi.Models.Data;
using System.ComponentModel.DataAnnotations;

namespace AirQi.Dtos
***REMOVED***
    public class MeasurementCreateDto
    ***REMOVED***
        [Required]
        public string Parameter ***REMOVED*** get; set;***REMOVED***

        [Required]
        public double  Value ***REMOVED*** get; set;***REMOVED***

        [Required]
        public DateTime LastUpdated ***REMOVED*** get; set;***REMOVED***

        [Required]
        public string Unit ***REMOVED*** get; set;***REMOVED***
                
        [Required]
        public string SourceName ***REMOVED*** get; set;***REMOVED***

        [Required]
        public DateTime CreatedAt ***REMOVED*** get; set;***REMOVED***

        [Required]
        public DateTime UpdatedAt ***REMOVED*** get; set;***REMOVED***
   ***REMOVED***
***REMOVED***
