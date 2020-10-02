using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Aqi.Models
***REMOVED***
    public class Measurement
    ***REMOVED***
        [Key]
        public int IdMeasurement  ***REMOVED*** get; set;***REMOVED***

        [Required]
        [MaxLength(50)]
        public string Metric ***REMOVED*** get; set;***REMOVED***

        [Required]
        public double Value ***REMOVED*** get; set;***REMOVED***

        [ForeignKey("Station")]
        public int StationFK ***REMOVED*** get; set;***REMOVED*** 

   ***REMOVED***
***REMOVED***