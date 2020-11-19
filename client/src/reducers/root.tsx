import ***REMOVED*** combineReducers***REMOVED*** from "redux";
import auth from "./auth";
import message from "./message";
import users from "./users";

const rootReducer = combineReducers(***REMOVED***
  auth,
  message,
  users
***REMOVED***);

export default rootReducer;
