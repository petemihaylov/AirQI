import React from "react";
import { BrowserRouter as Router } from "react-router-dom";
import "./css/style.css";
import Navigation from "../_layout/navbar";
import Main from "../_layout/main";
import Sidebar from "../_layout/sidebar/index";
import Footer from "../_layout/footer";

/* Layout :: Components */

function App() {
  return (
    <Router>
      <Navigation />
      <Main />
      <Sidebar/>
      {/* <Footer /> */}
    </Router>
  );
}

export default App;
