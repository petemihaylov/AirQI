import "./css/style.css";
import React from "react";
import Main from "../_layout/main";
import Navigation from "../_layout/navbar";
import Sidebar from "../_layout/sidebar/index";
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
