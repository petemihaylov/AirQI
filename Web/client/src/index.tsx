import React from "react";
import ReactDOM from "react-dom";
import App from "./components/app/index";
import "bootstrap/dist/css/bootstrap.min.css";
import ***REMOVED*** Provider***REMOVED*** from "react-redux";
import store from "./store";

ReactDOM.render(
  <Provider store=***REMOVED***store***REMOVED***>
    <App />

  </Provider>,
  document.getElementById("root")
);
