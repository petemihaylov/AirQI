import axios from "axios";

const ***REMOVED*** REACT_APP_JWT_URL, REACT_APP_API_URL***REMOVED*** = process.env;

class AuthService ***REMOVED***
  login(username, password) ***REMOVED***
    console.log(process.env);
    // must be changed according to the TokenController in jwt-api
    return axios
      .post(REACT_APP_JWT_URL, ***REMOVED***
        username,
        password,
     ***REMOVED***)
      .then((response) => ***REMOVED***
        if (response.data.accessToken) ***REMOVED***
          console.log(JSON.stringify(response.data));
          localStorage.setItem("user", JSON.stringify(response.data));
       ***REMOVED***

        return response.data;
     ***REMOVED***)
      .catch((error) => ***REMOVED***
        this.setState(***REMOVED*** errorMessage: error.message***REMOVED***);
        console.error("There was an error!", error);
     ***REMOVED***);
 ***REMOVED***

  logout() ***REMOVED***
    localStorage.removeItem("user");
 ***REMOVED***

  register(username, password, firstName, lastName, userRole) ***REMOVED***
    return axios.post(REACT_APP_API_URL, ***REMOVED***
      username,
      password,
      firstName,
      lastName,
      userRole, 
   ***REMOVED***);
 ***REMOVED***

  getCurrentUser() ***REMOVED***
    return JSON.parse(localStorage.getItem("user"));
 ***REMOVED***
***REMOVED***

export default new AuthService();
