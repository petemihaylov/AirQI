import axios from "axios";

const API_URL = "http://20.50.209.228/api/token/";

export default class AuthService ***REMOVED***
  login(username, password) ***REMOVED***
    // must be changed according to the TokenController in jwt-api
    return axios
      .post(API_URL, ***REMOVED***
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

  register(username, email, password) ***REMOVED***
    return axios.post(API_URL + "signup", ***REMOVED***
      username,
      email,
      password,
   ***REMOVED***);
 ***REMOVED***

  getCurrentUser() ***REMOVED***
    return JSON.parse(localStorage.getItem("user"));
 ***REMOVED***
***REMOVED***
