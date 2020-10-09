import axios from "axios";

const JWT_URL = "http://localhost:5000/api/token/";
const API_URL = "http://localhost:8080/api/users/";

class AuthService ***REMOVED***

  login(username, password) ***REMOVED***
    // must be changed according to the TokenController in jwt-api
    return axios
      .post(JWT_URL, ***REMOVED***
        username,
        password,
     ***REMOVED***)
      .then((response) => ***REMOVED***
        if (response.data.accessToken) ***REMOVED***
          localStorage.setItem("user", JSON.stringify(response.data));
       ***REMOVED***

        return response.data;
     ***REMOVED***);
 ***REMOVED***

  logout() ***REMOVED***
    localStorage.removeItem("user");
 ***REMOVED***

  register(username, password, firstName, lastName, userRole) ***REMOVED***
    return axios.post(API_URL, ***REMOVED***
      username,
      password,
      firstName,
      lastName,
      userRole
   ***REMOVED***);
 ***REMOVED***

  getCurrentUser() ***REMOVED***
    return JSON.parse(localStorage.getItem("user"));
 ***REMOVED***

***REMOVED***

export default new AuthService();
