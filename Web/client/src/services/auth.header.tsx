export default function authHeader() ***REMOVED*** 
  
  const user = JSON.parse(localStorage.getItem("user") || '***REMOVED******REMOVED***');

  if (user && user.accessToken) ***REMOVED***
    return ***REMOVED*** Authorization: "Bearer " + user.accessToken***REMOVED***;
 ***REMOVED*** else ***REMOVED***
    return ***REMOVED******REMOVED***;
 ***REMOVED***
***REMOVED***
