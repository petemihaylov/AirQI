import UserService from "../services/user.service";
import User from "../entities/User";

import AuthService from "../services/auth.service";

import ***REMOVED*** FETCH_USERS, DELETE_USER, SET_MESSAGE, CREATE_USER, UPDATE_USER***REMOVED*** from "./types";

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


export const updateUser = (user: User) => (dispatch: any) => ***REMOVED***
  return UserService.updateUser(user).then(
    (response) => ***REMOVED***
      console.log(response);

      dispatch(***REMOVED***
        type: UPDATE_USER,
        payload: user,
     ***REMOVED***);
      
      return Promise.resolve();
   ***REMOVED***,
    (error) => ***REMOVED***
      const message =
        (error.response &&
          error.response.data &&
          error.response.data.message) ||
        error.message ||
        error.toString();
      return Promise.reject();
   ***REMOVED***
  );
***REMOVED***;

export const createUser = (user: User) => (dispatch: any) => ***REMOVED***
  return AuthService.register(user).then(
    (response) => ***REMOVED***
      console.log(response);

      dispatch(***REMOVED***
        type: CREATE_USER,
        payload: user,
     ***REMOVED***);

      dispatch(***REMOVED***
        type: SET_MESSAGE,
        payload: response.data.message,
     ***REMOVED***);

      return Promise.resolve();
   ***REMOVED***,
    (error) => ***REMOVED***
      const message =
        (error.response &&
          error.response.data &&
          error.response.data.message) ||
        error.message ||
        error.toString();

      dispatch(***REMOVED***
        type: SET_MESSAGE,
        payload: message,
     ***REMOVED***);

      return Promise.reject();
   ***REMOVED***
  );
***REMOVED***;

