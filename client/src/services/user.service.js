import axios from "axios";
import authHeader from "./auth-header";

// const API_URL = "http://apibase.westeurope.azurecontainer.io/api/users/";


 const API_URL = "http://localhost:8080/api/users/";

class UserService ***REMOVED***
    getPublicContent() ***REMOVED***
        return axios.get(API_URL);
   ***REMOVED***

    getUserBoard() ***REMOVED***
        return axios.get(API_URL, ***REMOVED***headers: authHeader()***REMOVED***);
   ***REMOVED***

    getModeratorBoard() ***REMOVED***
        return axios.get(API_URL, ***REMOVED***headers: authHeader()***REMOVED***);
   ***REMOVED***

    getAdminBoard() ***REMOVED***
        return axios.get(API_URL, ***REMOVED***headers: authHeader()***REMOVED***);
   ***REMOVED***
***REMOVED***

export default new UserService();
