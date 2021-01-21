import "./css/style.css";
import React from "react";
import Main from "../layout/main";
import Navigation from "../layout/navbar";
import Sidebar from "../layout/sidebar/index";
import { BrowserRouter as Router } from "react-router-dom";

/* Layout :: Components */

function App() {
  return (
    <Router>
      <Navigation />
      <Main />
      <Sidebar/>
    </Router>
  );
}

export default App;
