import { combineReducers } from "redux";
import auth from "./auth";
import message from "./message";
import users from "./users";
import notifications from "./notifications";
import markers from "./markers";
import profile from "./profile";
import features from "./features";
import slamarker from "./slamarker";

const rootReducer = combineReducers({
  auth,
  message,
  users,
  notifications,
  markers,
  profile,
  slamarker,
  features
});

export default rootReducer;
