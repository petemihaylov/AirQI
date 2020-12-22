import UserService from "../services/user.service";
import User from "../entities/User";

import AuthService from "../services/auth.service";

import { FETCH_USERS, DELETE_USER, SET_MESSAGE, CREATE_USER } from "./types";

export const fetchUsers = () => (dispatch: any) => {
  UserService.getModeratorBoard().then(
    (response) => {
      dispatch({
        type: FETCH_USERS,
        payload: response.data,
      });
    },
    (error) => {
      console.log(error);
    }
  );
};


export const deleteUser = (id: number, index: number) => (dispatch: any) => {
  UserService.deleteUser(id).then(
    (response) => {
      dispatch({
        type: DELETE_USER,
        payload: index,
      });
    },
    (error) => {
      console.log(error);
    }
  );
};

export const createUser = (user: User) => (dispatch: any) => {
  return AuthService.register(user).then(
    (response) => {
      console.log(response);

      dispatch({
        type: CREATE_USER,
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
        type: SET_MESSAGE,
        payload: message,
      });

      return Promise.reject();
    }
  );
};

