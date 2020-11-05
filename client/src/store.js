import rootReducer from "./reducers";
import ***REMOVED*** createStore, applyMiddleware, compose***REMOVED*** from "redux";
import thunk from "redux-thunk";

const initialState = ***REMOVED******REMOVED***;

const middleware = [thunk];

const store = createStore(
  rootReducer,
  initialState,
  compose(
    applyMiddleware(...middleware),
    window.__REDUX_DEVTOOLS_EXTENSION__ && window.__REDUX_DEVTOOLS_EXTENSION__()
  )
);

export default store;
