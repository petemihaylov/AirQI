import axios from "axios";
import authHeader from "./auth-header";

const ***REMOVED*** REACT_APP_API_URL***REMOVED*** = process.env;

class UserService ***REMOVED***
    getPublicContent() ***REMOVED***
        return axios.get(REACT_APP_API_URL + "/users/");
   ***REMOVED***

    getUserBoard() ***REMOVED***
        return axios.get(REACT_APP_API_URL + "/users/", ***REMOVED*** headers: authHeader()***REMOVED***);
   ***REMOVED***

    getModeratorBoard() ***REMOVED***
        return axios.get(REACT_APP_API_URL + "/users/", ***REMOVED*** headers: authHeader()***REMOVED***);
   ***REMOVED***

    getAdminBoard() ***REMOVED***
        return axios.get(REACT_APP_API_URL + "/users/", ***REMOVED*** headers: authHeader()***REMOVED***);
   ***REMOVED***
***REMOVED***

export default new UserService();
