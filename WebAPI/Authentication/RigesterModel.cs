using System.ComponentModel.DataAnnotations;

namespace WebAPI.Authentication  
***REMOVED***  
    public class RegisterModel  
    ***REMOVED***  
        [Required(ErrorMessage = "Username is required")]  
        public string Username ***REMOVED*** get; set;***REMOVED***  
  
        [EmailAddress]  
        [Required(ErrorMessage = "Email is required")]  
        public string Email ***REMOVED*** get; set;***REMOVED***  
  
        [Required(ErrorMessage = "Password is required")]  
        public string Password ***REMOVED*** get; set;***REMOVED***  
  
   ***REMOVED***  
***REMOVED***