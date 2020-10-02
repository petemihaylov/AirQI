using System.ComponentModel.DataAnnotations;

namespace Aqi.Models
***REMOVED***
    public class Country
    ***REMOVED***
    
        [Key]
        public int IdCountry ***REMOVED*** get; set;***REMOVED***

        [Required]
        [MaxLength(50)]
        public string Name ***REMOVED*** get; set;***REMOVED***

        [Required]
        [MaxLength(3)]
        public string Code ***REMOVED*** get; set;***REMOVED***

   ***REMOVED***
***REMOVED***