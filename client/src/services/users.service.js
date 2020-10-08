import axios from "axios";
import authHeader from "./auth-header";

const API_URL = "http://localhost:8080/api/test/";

export default class UserService ***REMOVED***
  getPublicContent() ***REMOVED***
    return axios.get(API_URL + "all");
 ***REMOVED***

  getUserBoard() ***REMOVED***
    return axios.get(API_URL + "user", ***REMOVED*** headers: authHeader()***REMOVED***);
 ***REMOVED***

  getModeratorBoard() ***REMOVED***
    return axios.get(API_URL + "mod", ***REMOVED*** headers: authHeader()***REMOVED***);
 ***REMOVED***

  getAdminBoard() ***REMOVED***
    return axios.get(API_URL + "admin", ***REMOVED*** headers: authHeader()***REMOVED***);
 ***REMOVED***
***REMOVED***
