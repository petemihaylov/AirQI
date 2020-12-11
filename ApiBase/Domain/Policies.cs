using Microsoft.AspNetCore.Authorization;

namespace ApiBase.Models
***REMOVED***
    public class Policies
    ***REMOVED***
        public const string Admin = "Admin";
        public const string User = "User";

        public static AuthorizationPolicy AdminPolicy()
        ***REMOVED***
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(Admin).Build();
       ***REMOVED***
        public static AuthorizationPolicy UserPolicy()
        ***REMOVED***
            return new AuthorizationPolicyBuilder().RequireAuthenticatedUser().RequireRole(User).Build();
       ***REMOVED***
   ***REMOVED***
***REMOVED***