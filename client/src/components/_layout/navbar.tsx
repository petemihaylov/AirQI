import React, { useState } from "react";
import Navbar from "react-bootstrap/esm/Navbar";
import Nav from "react-bootstrap/esm/Nav";
import { connect } from "react-redux";
import { logout } from "../../actions/auth";
import { useEffect } from "react";

const Navigation = (props: any) => {
  const { user } = props;
  const [moderatorBoard, showModeratorBoard] = useState(false);
  const [adminBoard, showAdminBoard] = useState(false);

  useEffect(() => {
    showModeratorBoard(user && user.userRole === "Moderator");
    showAdminBoard(user && user.userRole === "Admin");
  }, []);

  function logOut() {
    props.dispatch(logout());
  }

  return (
    <Navbar>
      <Navbar.Brand href={"/welcome"}>
        <img src="./logo192.png" width="18px" height="18px" /> AirQI
      </Navbar.Brand>
      <Nav className="mr-auto">
        {/*  Moderator :: Board */}
        {moderatorBoard && (
          <Nav.Link href={"/mod"} className="nav-link">
            Moderator
          </Nav.Link>
        )}

        {/* Administrator :: Board */}
        {adminBoard && (
          <Nav.Link href={"/admin"} className="nav-link">
            Admin
          </Nav.Link>
        )}
      </Nav>

      {user ? (
        <Nav>
          <Nav.Link href={"/profile"} className="nav-link">
            {user.username}
          </Nav.Link>
          <Nav.Link href="/logout" onClick={logOut} className="nav-link">
            LogOut
          </Nav.Link>
        </Nav>
      ) : (
        <Nav>
          <Nav.Link href={"/login"}>Login</Nav.Link>
          <Nav.Link href={"/register"}>Sign Up</Nav.Link>
        </Nav>
      )}
    </Navbar>
  );
};

function mapStateToProps(state: any) {
  const { user } = state.auth;
  return {
    user,
  };
}

export default connect(mapStateToProps)(Navigation);
