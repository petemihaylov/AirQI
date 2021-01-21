import { combineReducers } from "redux";
import auth from "./auth";
import message from "./message";
import users from "./users";
import notifications from "./notifications";
import markers from "./markers";
import profile from "./profile";
import features from "./features";
import slamarkers from "./slamarkers";

const rootReducer = combineReducers({
  auth,
  message,
  users,
  notifications,
  markers,
  profile,
  slamarkers,
  features
});

export default rootReducer;
