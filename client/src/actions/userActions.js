import UserService from "../services/user.service";
import ***REMOVED*** FETCH_USERS, NEW_POST***REMOVED*** from "./types";

export const fetchUsers = () => (dispatch) => ***REMOVED***
  UserService.getModeratorBoard().then(
    (response) => ***REMOVED***
      dispatch(***REMOVED***
        type: FETCH_USERS,
        data: response.data,
     ***REMOVED***);
   ***REMOVED***,
    (error) => ***REMOVED***
      console.log(error);
   ***REMOVED***
  );
***REMOVED***;
