using System;
using System.ComponentModel.DataAnnotations;

namespace ApiBase.Models
***REMOVED***
    public class Role 
    ***REMOVED***
        [Key]
        public int RoleId ***REMOVED*** get; set;***REMOVED***
        
        [MaxLength(250)]
        public string Name ***REMOVED*** get; set;***REMOVED***

        
        public int UserId ***REMOVED*** get; set;***REMOVED***
        public User User ***REMOVED*** get; set;***REMOVED***  
   ***REMOVED***
    
***REMOVED***
