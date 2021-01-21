import "./css/style.css";
import React from "react";
import Main from "../layout/main";
import Navigation from "../layout/navbar";
import Sidebar from "../layout/sidebar/index";
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
