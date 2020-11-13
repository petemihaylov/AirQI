import React, { useState } from "react";
import Navbar from "react-bootstrap/esm/Navbar";
import Nav from "react-bootstrap/esm/Nav";
import { connect } from "react-redux";
import { logout } from "../../actions/auth";

const Navigation = (props: any) => {
  const { user } = props;
  const showModeratorBoard = useState(false);
  const showAdminBoard = useState(false);

  function logOut() {
    props.dispatch(logout());
  }

  return (
    <Navbar bg="light" variant="light">
      <Navbar.Brand href={"/map"}>AirQI</Navbar.Brand>
      <Nav className="mr-auto">
        {/*  Moderator :: Board */}
        {showModeratorBoard && (
          <Nav.Link href={"/mod"} className="nav-link">
            Moderator
          </Nav.Link>
        )}

        {/* Administrator :: Board */}
        {showAdminBoard && (
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
