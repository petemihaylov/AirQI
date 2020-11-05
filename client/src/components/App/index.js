import React, ***REMOVED*** Component***REMOVED*** from "react";
import ***REMOVED*** BrowserRouter as Router, Switch, Route***REMOVED*** from "react-router-dom";
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

class App extends Component ***REMOVED***
  render() ***REMOVED***
    return (
      <Router>
        <Navigation props=***REMOVED***this.state***REMOVED*** />
        <main>
          <Switch>
            <Route exact path="/login" component=***REMOVED***Login***REMOVED*** />
            <Route exact path="/register" component=***REMOVED***Register***REMOVED*** />
            <Route exact path="/profile" component=***REMOVED***Profile***REMOVED*** />
            <Route path="/user" component=***REMOVED***BoardUser***REMOVED*** />
            <Route path="/mod" component=***REMOVED***BoardModerator***REMOVED*** />
            <Route path="/admin" component=***REMOVED***BoardAdmin***REMOVED*** />
            <Route path="/home" component=***REMOVED***Home***REMOVED*** />
          </Switch>
        </main>

        <Footer />
      </Router>
    );
 ***REMOVED***
***REMOVED***

export default App;
