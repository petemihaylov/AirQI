using System;
using System.ComponentModel.DataAnnotations;

namespace ApiBase.Models
***REMOVED***
    public class User
    ***REMOVED***
        [Key]
        public int UserId ***REMOVED*** get; set;***REMOVED***
        
        [MaxLength(250)]
        public string FirstName ***REMOVED*** get; set;***REMOVED***
        
        [MaxLength(250)]
        public string LastName ***REMOVED*** get; set;***REMOVED***

        [Required]
        public string Password ***REMOVED*** get; set;***REMOVED***

        public Role UserRole ***REMOVED*** get; set;***REMOVED***
    
   ***REMOVED***
    
***REMOVED***
