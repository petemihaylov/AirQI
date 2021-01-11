import axios from "axios";
import User from "../entities/User";
import authHeader from "./auth.header";

const ***REMOVED*** REACT_APP_API_URL***REMOVED*** = process.env;

class UserService ***REMOVED***
  getPublicContent = async () => ***REMOVED***
    return axios.get(REACT_APP_API_URL + "/api/users/", ***REMOVED***
      headers: authHeader(),
   ***REMOVED***);
 ***REMOVED***;

  getUserBoard = async () => ***REMOVED***
    return axios.get(REACT_APP_API_URL + "/api/users/", ***REMOVED***
      headers: authHeader(),
   ***REMOVED***);
 ***REMOVED***;

  getModeratorBoard = async () => ***REMOVED***
    return axios.get(REACT_APP_API_URL + "/api/users/", ***REMOVED***
      headers: authHeader(),
   ***REMOVED***);
 ***REMOVED***;

  getAdminBoard = async () => ***REMOVED***
    return axios.get(REACT_APP_API_URL + "/api/users/", ***REMOVED***
      headers: authHeader(),
   ***REMOVED***);
 ***REMOVED***;

  createUser = async (user: User) => ***REMOVED***
    return axios.post(REACT_APP_API_URL + "/api/users/", user, ***REMOVED***
      headers: authHeader(),
   ***REMOVED***);
 ***REMOVED***;

  updateUser = async (user: User) =>***REMOVED***
      return axios.put(REACT_APP_API_URL + "/api/users/", user, ***REMOVED***
        headers: authHeader(),
     ***REMOVED***);
 ***REMOVED***
  deleteUser = async (id: number) => ***REMOVED***
    return axios.delete(REACT_APP_API_URL + "/api/users/" + id, ***REMOVED***
      headers: authHeader(),
   ***REMOVED***);
 ***REMOVED***;
***REMOVED***

export default new UserService();
