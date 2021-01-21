using System.ComponentModel.DataAnnotations;

namespace AirQi.Dtos
***REMOVED***
    public class NotificationCreateDto
    ***REMOVED***
        [MaxLength(250)]
        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Title ***REMOVED*** get; set;***REMOVED***

        [Required(AllowEmptyStrings = false)]
        [DisplayFormat(ConvertEmptyStringToNull = false)]
        public string Description ***REMOVED*** get; set;***REMOVED***
        
        [Required]
        public double [] Position ***REMOVED*** get; set;***REMOVED***
   ***REMOVED***
***REMOVED***