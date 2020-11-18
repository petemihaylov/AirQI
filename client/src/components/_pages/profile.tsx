import React from "react";
import { Redirect } from "react-router-dom";
import { connect } from "react-redux";

const Profile = (props: any) => {
  const { user } = props;

  if (!user) {
    return <Redirect to="/login" />;
  }

  return (
    <div className="container">
      <header className="jumbotron">
        <h3>Profile</h3>
        <small>
          <h6>
            Username: <strong>{user.username}</strong>
          </h6>
        </small>
      </header>
      <p>
        <strong>Token:</strong> {user.accessToken.substring(0, 20)} ...{" "}
        {user.accessToken.substr(user.accessToken.length - 20)}
      </p>
      <p>
        <strong>Authorities:</strong> {user.userRole}
      </p>
      <p>
        <strong>Personal name:</strong> {user.firstName} {user.lastName}
      </p>
      <p>
        <strong>Active: </strong>true
      </p>
    </div>
  );
};

function mapStateToProps(state: any) {
  const { user } = state.auth;
  return {
    user,
  };
}

export default connect(mapStateToProps)(Profile);
