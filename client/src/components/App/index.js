import React, { Component } from "react";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import Dashboard from "../Dashboard";
import RegisterForm from "../RegisterForm";

class App extends Component {
  render() {
    return (
      <Router>
        <Switch>
          <Route exact path="/">
            <Dashboard />
          </Route>
          <Route path="/register" component={RegisterForm} />
        </Switch>
      </Router>
    );
  }
}

export default App;
