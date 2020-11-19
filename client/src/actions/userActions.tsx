import UserService from "../services/user.service";
import User from "../entities/User";

import ***REMOVED*** FETCH_USERS, NEW_USER, DELETE_USER***REMOVED*** from "./types";

export const fetchUsers = () => (dispatch: any) => ***REMOVED***
  UserService.getModeratorBoard().then(
    (response) => ***REMOVED***
      dispatch(***REMOVED***
        type: FETCH_USERS,
        payload: response.data,
     ***REMOVED***);
   ***REMOVED***,
    (error) => ***REMOVED***
      console.log(error);
   ***REMOVED***
  );
***REMOVED***;

export const deleteUser = (id: number, index: number) => (dispatch: any) => ***REMOVED***
  UserService.deleteUser(id).then(
    (response) => ***REMOVED***
      dispatch(***REMOVED***
        type: DELETE_USER,
        payload: index,
     ***REMOVED***);
   ***REMOVED***,
    (error) => ***REMOVED***
      console.log(error);
   ***REMOVED***
  );
***REMOVED***;

export const createUser = (user: User) => (dispatch: any) => ***REMOVED***
  console.log("Create User action");
***REMOVED***;


