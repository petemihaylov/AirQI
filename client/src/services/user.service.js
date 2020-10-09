import axios from "axios";
import authHeader from "./auth-header";

const API_URL = "https://localhost:8080/api/users/";

class UserService ***REMOVED***
    getPublicContent() ***REMOVED***
        return axios.get(API_URL);
   ***REMOVED***

    getUserBoard() ***REMOVED***
        return axios.get(API_URL, ***REMOVED***headers: authHeader()***REMOVED***);
   ***REMOVED***

    getModeratorBoard() ***REMOVED***
        return axios.get(API_URL + "mod", ***REMOVED***headers: authHeader()***REMOVED***);
   ***REMOVED***

    getAdminBoard() ***REMOVED***
        return axios.get(API_URL + "admin", ***REMOVED***headers: authHeader()***REMOVED***);
   ***REMOVED***
***REMOVED***

export default new UserService();
