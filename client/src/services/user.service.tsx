import axios from "axios";
import User from "../entities/User";
import authHeader from "./auth.header";

const ***REMOVED*** REACT_APP_API_URL***REMOVED*** = process.env;

class UserService ***REMOVED***
  getPublicContent() ***REMOVED***
    return axios.get(REACT_APP_API_URL + "/api/users/", ***REMOVED***
      headers: authHeader(),
   ***REMOVED***);
 ***REMOVED***

  getUserBoard() ***REMOVED***
    return axios.get(REACT_APP_API_URL + "/api/users/", ***REMOVED***
      headers: authHeader(),
   ***REMOVED***);
 ***REMOVED***

  getModeratorBoard() ***REMOVED***
    return axios.get(REACT_APP_API_URL + "/api/users/", ***REMOVED***
      headers: authHeader(),
   ***REMOVED***);
 ***REMOVED***

  getAdminBoard() ***REMOVED***
    return axios.get(REACT_APP_API_URL + "/api/users/", ***REMOVED***
      headers: authHeader(),
   ***REMOVED***);
 ***REMOVED***

  createUser(user: User) ***REMOVED***
    return axios.post(REACT_APP_API_URL + "/api/users/", user, ***REMOVED***
      headers: authHeader(),
   ***REMOVED***);
 ***REMOVED***

  deleteUser(id: number) ***REMOVED***
    return axios.delete(REACT_APP_API_URL + "/api/users/" + id, ***REMOVED***
      headers: authHeader(),
   ***REMOVED***);
 ***REMOVED***
***REMOVED***

export default new UserService();
