import { combineReducers } from "redux";
import auth from "./auth";
import message from "./message";
import users from "./users";

const rootReducer = combineReducers({
  auth,
  message,
  users
});

export default rootReducer;
