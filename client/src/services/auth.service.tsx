import axios from "axios";
import User from "../entities/User";

const ***REMOVED*** REACT_APP_JWT_URL, REACT_APP_API_URL***REMOVED*** = process.env;

export default class AuthService ***REMOVED***
  static login(username: string, password: string) ***REMOVED***
    return axios
      .post(REACT_APP_JWT_URL + "/api/token/" || "", ***REMOVED***
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

  static logout() ***REMOVED***
    localStorage.removeItem("user");
 ***REMOVED***

  static register(user: User) ***REMOVED***
    return axios.post(REACT_APP_API_URL + "/api/users/", user);
 ***REMOVED***

  static getCurrentUser(): User ***REMOVED***
    return JSON.parse(localStorage.getItem("user") || "***REMOVED******REMOVED***");
 ***REMOVED***
***REMOVED***
