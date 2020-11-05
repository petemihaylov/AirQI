import UserService from "../services/user.service";
import { FETCH_USERS, NEW_POST } from "./types";

export const fetchUsers = () => (dispatch) => {
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
