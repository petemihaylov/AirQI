import ***REMOVED*** createStore, applyMiddleware***REMOVED*** from "redux";
import ***REMOVED*** composeWithDevTools***REMOVED*** from "redux-devtools-extension";
import thunk from "redux-thunk";
import rootReducer from "./reducers";

const middleware = [thunk];

const store = createStore(
  rootReducer,
  composeWithDevTools(applyMiddleware(...middleware))
);

export default store;
