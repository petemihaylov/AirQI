import { combineReducers } from "redux";
import auth from "./auth";
import message from "./message";
import users from "./users";
import notifications from "./notifications";
import markers from "./markers";


const rootReducer = combineReducers({
  auth,
  message,
  users,
  notifications,
  markers
});

export default rootReducer;
