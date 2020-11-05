import React from "react";
import ReactDOM from "react-dom";
import App from "./components/App/index";
import * as serviceWorker from "./serviceWorker";
import ***REMOVED*** Provider***REMOVED*** from "react-redux";
import store from "./store";

ReactDOM.render(
  <Provider store=***REMOVED***store***REMOVED***>
    <App />
  </Provider>,
  document.getElementById("root")
);

// Learn more about service workers: https://bit.ly/CRA-PWA
serviceWorker.register();
