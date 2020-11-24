import { combineReducers } from "redux";
import auth from "./auth";
import message from "./message";
import users from "./users";
import notifications from "./notifications";


const rootReducer = combineReducers({
  auth,
  message,
  users,
  notifications
});

export default rootReducer;
