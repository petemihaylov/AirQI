import { combineReducers } from "redux";
import auth from "./auth";
import message from "./message";
import users from "./users";
import notifications from "./notifications";
import markers from "./markers";
import profile from "./profile";

const rootReducer = combineReducers({
  auth,
  message,
  users,
  notifications,
  markers,
  profile
});

export default rootReducer;
