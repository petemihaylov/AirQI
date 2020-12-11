using System.ComponentModel.DataAnnotations;
using ApiBase.Models;

namespace ApiBase.DTOs
***REMOVED***
    public class UserDto
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
