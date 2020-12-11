using System;
using System.ComponentModel.DataAnnotations;

namespace ApiJwt.Models
***REMOVED***
    public class User : BaseEntity
    ***REMOVED***


        [MaxLength(250)]
        public string FirstName ***REMOVED*** get; set;***REMOVED***
        
        [MaxLength(250)]
        public string LastName ***REMOVED*** get; set;***REMOVED***

        [Required]
        public RoleEnum UserRole ***REMOVED*** get; set;***REMOVED***
   ***REMOVED***

    public enum RoleEnum ***REMOVED*** Admin, Moderator, User***REMOVED*** 
    
***REMOVED***
