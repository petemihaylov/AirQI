import {
  REGISTER_SUCCESS,
  REGISTER_FAIL,
  LOGIN_SUCCESS,
  LOGIN_FAIL,
  LOGOUT,
  ADD_PROFILE,
  SET_MESSAGE,
} from "./types";

import AuthService from "../services/auth.service";
import UserService from "../services/user.service";
import User from "../entities/User";

export const register = (user: User) => (dispatch: any) => {
  return AuthService.register(user).then(
    (response) => {
      console.log(response);

      dispatch({
        type: REGISTER_SUCCESS,
        payload: user,
      });

      dispatch({
        type: SET_MESSAGE,
        payload: response.data.message,
      });

      return Promise.resolve();
    },
    (error) => {
      const message =
        (error.response &&
          error.response.data &&
          error.response.data.message) ||
        error.message ||
        error.toString();

      dispatch({
        type: REGISTER_FAIL,
      });

      dispatch({
        type: SET_MESSAGE,
        payload: message,
      });

      return Promise.reject();
    }
  );
};

export const login = (username: string, password: string) => (
  dispatch: any
) => {
  return AuthService.login(username, password)
    .then(
      (response) => {
        dispatch({
          type: LOGIN_SUCCESS,
          payload: { user: response },
        });

        return Promise.resolve();
      },
      (error) => {
        const message =
          (error.response &&
            error.response.data &&
            error.response.data.message) ||
          error.message ||
          error.toString();

        dispatch({
          type: LOGIN_FAIL,
        });

        dispatch({
          type: SET_MESSAGE,
          payload: message,
        });

        return Promise.reject();
      }
    )
};

export const logout = () => (dispatch: any) => {
  dispatch({
    type: LOGOUT,
  });
  AuthService.logout();
};
