import React from "react";
import ***REMOVED*** Redirect***REMOVED*** from "react-router-dom";
import ***REMOVED*** connect***REMOVED*** from "react-redux";

const Profile = (props: any) => ***REMOVED***
  const ***REMOVED*** user***REMOVED*** = props;

  if (!user) ***REMOVED***
    return <Redirect to="/login" />;
 ***REMOVED***

  return (
    <div className="container">
      <header className="jumbotron">
        <h3>Profile</h3>
        <small>
          <h6>
            Username: <strong>***REMOVED***user.username***REMOVED***</strong>
          </h6>
        </small>
      </header>
      <p>
        <strong>Token:</strong> ***REMOVED***user.accessToken.substring(0, 20)***REMOVED*** ...***REMOVED***" "***REMOVED***
        ***REMOVED***user.accessToken.substr(user.accessToken.length - 20)***REMOVED***
      </p>
      <p>
        <strong>Authorities:</strong> ***REMOVED***user.userRole***REMOVED***
      </p>
      <p>
        <strong>Personal name:</strong> ***REMOVED***user.firstName***REMOVED*** ***REMOVED***user.lastName***REMOVED***
      </p>
      <p>
        <strong>Active: </strong>true
      </p>
    </div>
  );
***REMOVED***;

function mapStateToProps(state: any) ***REMOVED***
  const ***REMOVED*** user***REMOVED*** = state.auth;
  return ***REMOVED***
    user,
 ***REMOVED***;
***REMOVED***

export default connect(mapStateToProps)(Profile);
