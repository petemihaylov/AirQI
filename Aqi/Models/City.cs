using System.ComponentModel.DataAnnotations;

namespace Aqi.Models
***REMOVED***
    public class City
    ***REMOVED***
    
        [Key]
        public int IdCity  ***REMOVED*** get; set;***REMOVED***

        [Required]
        [MaxLength(50)]
        public string Name ***REMOVED*** get; set;***REMOVED***
        
        [Required]
        public Country Country ***REMOVED*** get; set;***REMOVED***

        [Required]
        public Location Location ***REMOVED*** get; set;***REMOVED***

   ***REMOVED***
***REMOVED***