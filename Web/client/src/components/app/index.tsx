import "./css/style.css";
import React from "react";
import Main from "../_layout/main";
import Navigation from "../_layout/navbar";
import Sidebar from "../_layout/sidebar/index";
import ***REMOVED*** BrowserRouter as Router***REMOVED*** from "react-router-dom";

/* Layout :: Components */

function App() ***REMOVED***
  return (
    <Router>
      <Navigation />
      <Main />
      <Sidebar/>
    </Router>
  );
***REMOVED***

export default App;
