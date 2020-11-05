import React, { Component } from "react";
import { BrowserRouter as Router, Switch, Route } from "react-router-dom";
import "./css/style.css";

/* Layout :: Components */
import Navigation from "../Layout/navigation.component";
import Footer from "../Layout/footer.component";

/* Router :: Components */
import Login from "../login.component";
import Register from "../register.component";
import Home from "../home.component";
import Profile from "../profile.component";
import BoardUser from "../board-user.component";
import BoardModerator from "../board-moderator.component";
import BoardAdmin from "../board-admin.component";

class App extends Component {
  render() {
    return (
      <Router>
        <Navigation props={this.state} />
        <main>
          <Switch>
            <Route exact path="/login" component={Login} />
            <Route exact path="/register" component={Register} />
            <Route exact path="/profile" component={Profile} />
            <Route path="/user" component={BoardUser} />
            <Route path="/mod" component={BoardModerator} />
            <Route path="/admin" component={BoardAdmin} />
            <Route path="/home" component={Home} />
          </Switch>
        </main>

        <Footer />
      </Router>
    );
  }
}

export default App;
