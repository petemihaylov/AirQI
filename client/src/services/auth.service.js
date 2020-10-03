    import axios from "axios";

const API_URL = "http://localhost:8080/api/auth/";

export default class AuthService ***REMOVED***
  login(username, password) ***REMOVED***
    return axios
      .post(API_URL + "signin", ***REMOVED***
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
