import React from "react";
import ***REMOVED*** BrowserRouter as Router***REMOVED*** from "react-router-dom";
import "./css/style.css";
import Navigation from "../_layout/navbar";
import Main from "../_layout/main";
import Sidebar from "../_layout/sidebar/index";
import Footer from "../_layout/footer";

/* Layout :: Components */

function App() ***REMOVED***
  return (
    <Router>
      <Navigation />
      <Main />
      <Sidebar/>
      ***REMOVED***/* <Footer /> */***REMOVED***
    </Router>
  );
***REMOVED***

export default App;
