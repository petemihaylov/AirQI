import React, {Component} from "react";
import { Link } from "react-router-dom";

import AuthService from "../../services/auth.service";

class Navigation extends Component {
  constructor(props) {
    super(props);

    this.logOut = this.logOut.bind(this);

    this.state = {
      showModeratorBoard: false,
      showAdminBoard: false,
      currentUser: undefined,
    };
  }

  componentDidMount() {
    const user = AuthService.getCurrentUser();

    if (user) {
      this.setState({
        currentUser: user,
        showModeratorBoard: user.userRole.includes("Moderator"),
        showAdminBoard: user.userRole.includes("Admin"),
      });
    }
  }

  logOut() {
    AuthService.logout();
  }

  render() {
    const {showModeratorBoard, showAdminBoard, currentUser} = this.state;

    return (
      <div>
        <nav className="navbar navbar-expand nav-bg">
          <Link to={"/home"} className="navbar-brand">
            AirQI
          </Link>
          <div className="navbar-nav mr-auto">
            {/*  Moderator :: Board */}
            <div>
              {showModeratorBoard && (
                <li className="nav-item">
                  <Link to={"/mod"} className="nav-link">
                    Moderator
                  </Link>
                </li>
              )}
            </div>

            {/* Administrator :: Board */}
            <div>
              {showAdminBoard && (
                <li className="nav-item">
                  <Link to={"/admin"} className="nav-link">
                    Admin
                  </Link>
                </li>
              )}
            </div>

            {/* User :: Board */}
            <div>
              {currentUser && (
                <li className="nav-item">
                  <Link to={"/user"} className="nav-link">
                    User
                  </Link>
                </li>
              )}
            </div>
          </div>
          {currentUser ? (
            <div className="navbar-nav ml-auto">
              <li className="nav-item">
                <Link to={"/profile"} className="nav-link">
                  {" "}
                  {currentUser.username}{" "}
                </Link>
              </li>
              <li className="nav-item">
                <a href="/login" className="nav-link" onClick={this.logOut}>
                  LogOut
                </a>
              </li>
            </div>
          ) : (
            <div className="navbar-nav ml-auto">
              <li className="nav-item">
                <Link to={"/login"} className="nav-link">
                  Login
                </Link>
              </li>

              <li className="nav-item">
                <Link to={"/register"} className="nav-link">
                  Sign Up
                </Link>
              </li>
            </div>
          )}{" "}
        </nav>
      </div>
    );
  }
};

export default Navigation;
