import React from "react";
import { BrowserRouter as Router } from "react-router-dom";
import Footer from "../_layout/footer";
import NavDrawer from "../_layout/drawer";
import "./css/style.css";
import { Container } from "react-bootstrap";

/* Layout :: Components */

function App() {
  return (
    <Router>
      <NavDrawer />
      {/* <Footer /> */}
    </Router>
  );
}

export default App;
