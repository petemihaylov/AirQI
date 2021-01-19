import ***REMOVED*** combineReducers***REMOVED*** from "redux";
import auth from "./auth";
import message from "./message";
import users from "./users";
import notifications from "./notifications";
import markers from "./markers";
import profile from "./profile";

const rootReducer = combineReducers(***REMOVED***
  auth,
  message,
  users,
  notifications,
  markers,
  profile
***REMOVED***);

export default rootReducer;
