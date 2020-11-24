import ***REMOVED*** combineReducers***REMOVED*** from "redux";
import auth from "./auth";
import message from "./message";
import users from "./users";
import notifications from "./notifications";


const rootReducer = combineReducers(***REMOVED***
  auth,
  message,
  users,
  notifications
***REMOVED***);

export default rootReducer;
