import ***REMOVED***
  REGISTER_SUCCESS,
  REGISTER_FAIL,
  LOGIN_SUCCESS,
  LOGIN_FAIL,
  LOGOUT,
  SET_MESSAGE,
***REMOVED*** from "./types";

import AuthService from "../services/auth.service";
import User from "../entities/User";

export const register = (user: User) => (dispatch: any) => ***REMOVED***
  return AuthService.register(user).then(
    (response) => ***REMOVED***
      dispatch(***REMOVED***
        type: REGISTER_SUCCESS,
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
        type: REGISTER_FAIL,
     ***REMOVED***);

      dispatch(***REMOVED***
        type: SET_MESSAGE,
        payload: message,
     ***REMOVED***);

      return Promise.reject();
   ***REMOVED***
  );
***REMOVED***;

export const login = (username: string, password: string) => (
  dispatch: any
) => ***REMOVED***
  return AuthService.login(username, password).then(
    (response) => ***REMOVED***
      dispatch(***REMOVED***
        type: LOGIN_SUCCESS,
        payload: ***REMOVED*** user: response***REMOVED***,
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
        type: LOGIN_FAIL,
     ***REMOVED***);

      dispatch(***REMOVED***
        type: SET_MESSAGE,
        payload: message,
     ***REMOVED***);

      return Promise.reject();
   ***REMOVED***
  );
***REMOVED***;

export const logout = () => (dispatch: any) => ***REMOVED***
  dispatch(***REMOVED***
    type: LOGOUT,
 ***REMOVED***);
  AuthService.logout();
***REMOVED***;
