using System.ComponentModel.DataAnnotations;
using ApiBase.Models;

namespace ApiBase.Dto
***REMOVED***
    public class UserCreateDto
    ***REMOVED***
        [MaxLength(250)]
        public string FirstName ***REMOVED*** get; set;***REMOVED***
        
        [MaxLength(250)]
        public string LastName ***REMOVED*** get; set;***REMOVED***

        [Required]
        public string Password ***REMOVED*** get; set;***REMOVED***
        public Role UserRole ***REMOVED*** get; set;***REMOVED***
   ***REMOVED***
    
***REMOVED***
