import React, ***REMOVED***Component***REMOVED*** from "react";
import ***REMOVED*** Link***REMOVED*** from "react-router-dom";

import AuthService from "../../services/auth.service";

class Navigation extends Component ***REMOVED***
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
    const ***REMOVED***showModeratorBoard, showAdminBoard, currentUser***REMOVED*** = this.state;

    return (
      <div>
        <nav className="navbar navbar-expand nav-bg">
          <Link to=***REMOVED***"/home"***REMOVED*** className="navbar-brand">
            AirQI
          </Link>
          <div className="navbar-nav mr-auto">
            ***REMOVED***/*  Moderator :: Board */***REMOVED***
            <div>
              ***REMOVED***showModeratorBoard && (
                <li className="nav-item">
                  <Link to=***REMOVED***"/mod"***REMOVED*** className="nav-link">
                    Moderator
                  </Link>
                </li>
              )***REMOVED***
            </div>

            ***REMOVED***/* Administrator :: Board */***REMOVED***
            <div>
              ***REMOVED***showAdminBoard && (
                <li className="nav-item">
                  <Link to=***REMOVED***"/admin"***REMOVED*** className="nav-link">
                    Admin
                  </Link>
                </li>
              )***REMOVED***
            </div>

            ***REMOVED***/* User :: Board */***REMOVED***
            <div>
              ***REMOVED***currentUser && (
                <li className="nav-item">
                  <Link to=***REMOVED***"/user"***REMOVED*** className="nav-link">
                    User
                  </Link>
                </li>
              )***REMOVED***
            </div>
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
      </div>
    );
 ***REMOVED***
***REMOVED***;

export default Navigation;
