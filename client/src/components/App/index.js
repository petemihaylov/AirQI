import React, ***REMOVED*** Component***REMOVED*** from "react";
import ***REMOVED*** BrowserRouter as Router, Link, Switch, Route***REMOVED*** from "react-router-dom";
import AuthService from "../../services/auth.service";
import "./css/style.css";

import Login from "../login.component";
import Register from "../register.component";
import Home from "../home.component";
import Profile from "../profile.component";
import BoardUser from "../board-user.component";
import BoardModerator from "../board-moderator.component";
import BoardAdmin from "../board-admin.component";

class App extends Component ***REMOVED***
  constructor(props) ***REMOVED***
    super(props);

    this.logOut = this.logOut.bind(this);

    this.state = ***REMOVED***
      showModeratorBoard: false,
      showAdminBoard: false,
      currentUser: undefined,
   ***REMOVED***;
 ***REMOVED***

  componentDidMount() ***REMOVED***
    const user = AuthService.getCurrentUser();

    if (user) ***REMOVED***
      this.setState(***REMOVED***
        currentUser: user,
        showModeratorBoard: user.userRole.includes("Moderator"),
        showAdminBoard: user.userRole.includes("Admin"),
     ***REMOVED***);
   ***REMOVED***
 ***REMOVED***

  logOut() ***REMOVED***
    AuthService.logout();
 ***REMOVED***

  render() ***REMOVED***
    const ***REMOVED*** currentUser, showModeratorBoard, showAdminBoard***REMOVED*** = this.state;

    return (
      <Router>
        <nav className="navbar navbar-expand nav-bg">
          <Link to=***REMOVED***"/home"***REMOVED*** className="navbar-brand">
            AirQI
          </Link>
          <div className="navbar-nav mr-auto">
            ***REMOVED***showModeratorBoard && (
              <li className="nav-item">
                <Link to=***REMOVED***"/mod"***REMOVED*** className="nav-link">
                  Moderator
                </Link>
              </li>
            )***REMOVED***
            ***REMOVED***showAdminBoard && (
              <li className="nav-item">
                <Link to=***REMOVED***"/admin"***REMOVED*** className="nav-link">
                  Admin
                </Link>
              </li>
            )***REMOVED***
            ***REMOVED***currentUser && (
              <li className="nav-item">
                <Link to=***REMOVED***"/user"***REMOVED*** className="nav-link">
                  User
                </Link>
              </li>
            )***REMOVED******REMOVED***" "***REMOVED***
          </div>
          ***REMOVED***currentUser ? (
            <div className="navbar-nav ml-auto">
              <li className="nav-item">
                <Link to=***REMOVED***"/profile"***REMOVED*** className="nav-link">
                  ***REMOVED***" "***REMOVED***
                  ***REMOVED***currentUser.username***REMOVED******REMOVED***" "***REMOVED***
                </Link>
              </li>
              <li className="nav-item">
                <a href="/login" className="nav-link" onClick=***REMOVED***this.logOut***REMOVED***>
                  LogOut
                </a>
              </li>
            </div>
          ) : (
            <div className="navbar-nav ml-auto">
              <li className="nav-item">
                <Link to=***REMOVED***"/login"***REMOVED*** className="nav-link">
                  Login
                </Link>
              </li>

              <li className="nav-item">
                <Link to=***REMOVED***"/register"***REMOVED*** className="nav-link">
                  Sign Up
                </Link>
              </li>
            </div>
          )***REMOVED******REMOVED***" "***REMOVED***
        </nav>

        <div className="app-container">
          <Switch>
            <Route exact path="/login" component=***REMOVED***Login***REMOVED*** />
            <Route exact path="/register" component=***REMOVED***Register***REMOVED*** />
            <Route exact path="/profile" component=***REMOVED***Profile***REMOVED*** />
            <Route path="/user" component=***REMOVED***BoardUser***REMOVED*** />
            <Route path="/mod" component=***REMOVED***BoardModerator***REMOVED*** />
            <Route path="/admin" component=***REMOVED***BoardAdmin***REMOVED*** />
            <Route path="/home" component=***REMOVED***Home***REMOVED*** />
          </Switch>
        </div>
      </Router>
    );
 ***REMOVED***
***REMOVED***

export default App;
