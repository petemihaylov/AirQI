using Aqi.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aqi.Dtos
***REMOVED***
    public class StationCreateDto
    ***REMOVED***
        // [Required]
        // public City City ***REMOVED*** get; set;***REMOVED***

        // [Required]
        // public Country Country ***REMOVED*** get; set;***REMOVED***

        // [Required]
        // public Location Location ***REMOVED*** get; set;***REMOVED***

        // [Required]
        // public ICollection<Measurement> Measurements ***REMOVED*** get; set;***REMOVED***

        [Required]
        [DataType(DataType.Date)]
        public DateTime CreatedAt ***REMOVED*** get; set;***REMOVED***

        [Required]
        [DataType(DataType.Date)]
        public DateTime UpdatedAt ***REMOVED*** get; set;***REMOVED***
   ***REMOVED***
***REMOVED***