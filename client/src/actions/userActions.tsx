import UserService from "../services/user.service";
import User from "../entities/User";

import { FETCH_USERS, NEW_USER, DELETE_USER } from "./types";

export const fetchUsers = () => (dispatch: any) => {
  UserService.getModeratorBoard().then(
    (response) => {
      dispatch({
        type: FETCH_USERS,
        data: response.data,
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
  console.log("Create User action");
};


