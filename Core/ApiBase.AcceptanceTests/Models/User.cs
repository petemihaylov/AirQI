using System.ComponentModel.DataAnnotations;

namespace ApiBase.AcceptanceTests.Models
***REMOVED***
    public class User 
    ***REMOVED***
        public int Id ***REMOVED*** get; set;***REMOVED***

        [Required]
        public string Username ***REMOVED*** get; set;***REMOVED***

        [Required]
        public string Password ***REMOVED*** get; set;***REMOVED***

        [MaxLength(250)]
        public string FirstName ***REMOVED*** get; set;***REMOVED***

        [MaxLength(250)]
        public string LastName ***REMOVED*** get; set;***REMOVED***
        public string UserRole ***REMOVED*** get; set;***REMOVED***
   ***REMOVED***

***REMOVED***
