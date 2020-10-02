using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Aqi.Models
***REMOVED***
    public class Station
    ***REMOVED***
        
        [Key]
        public int IdStation ***REMOVED*** get; set;***REMOVED***

        [Required]
        public City City ***REMOVED*** get; set;***REMOVED***

        [Required]
        public Country Country ***REMOVED*** get; set;***REMOVED***

        [Required]
        public Location Location ***REMOVED*** get; set;***REMOVED***

        [Required]
        public ICollection<Measurement> Measurements ***REMOVED*** get; set;***REMOVED***

   ***REMOVED***
***REMOVED***