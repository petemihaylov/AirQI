import React from "react";
import ***REMOVED*** Redirect***REMOVED*** from "react-router-dom";
import ***REMOVED*** connect***REMOVED*** from "react-redux";
import ***REMOVED*** Container, Row, Col***REMOVED*** from "react-bootstrap";
import "./css/style.css";

const Profile = (props: any) => ***REMOVED***
  const ***REMOVED*** user***REMOVED*** = props;

  if (!user) ***REMOVED***
    return <Redirect to="/login" />;
 ***REMOVED***

  return (
    <Container className="centered wrapper">
      <Container className="w-75">
        <Row className="mb-5">
          <Col xs=***REMOVED***12***REMOVED*** md=***REMOVED***8***REMOVED*** className="centered">
            <div>
              <h2>
                <b>Edit profile</b>
              </h2>
              <small>
                People on AirQI will get to know you with the info below
              </small>
            </div>
          </Col>
          <Col xs=***REMOVED***6***REMOVED*** md=***REMOVED***4***REMOVED*** className="centered">
            <div>
              <button className="btn btn-sm">Cancel</button>
              <button className="btn btn-dark btn-sm ml-3">Save</button>
            </div>
          </Col>
        </Row>
        <small>Photo</small>
        <Row>
          <Col>
            <img
              className="rounded-circle"
              src="https://www.juxtapoz.com/images/Hannah%20Stouffer/Jesse%2013/Tea-Wei_10.gif"
              alt="Avatar"
              width=***REMOVED***"90px"***REMOVED***
              height=***REMOVED***"90px"***REMOVED***
            ></img>

            <button className="btn btn-outline-dark btn-sm ml-4">Change</button>
          </Col>
        </Row>
        <form>
          <Row>
            <Col>
              <small>First name</small>
              <div className="input-group">
                <input
                  type="text"
                  className="form-control"
                  aria-describedby="first name"
                  defaultValue=***REMOVED***user.firstName***REMOVED***
                  name="firstName"
                />
              </div>
            </Col>
            <Col>
              <small>Last name</small>
              <div className="input-group">
                <input
                  type="text"
                  className="form-control"
                  aria-describedby="last name"
                  defaultValue=***REMOVED***user.lastName***REMOVED***
                />
              </div>
            </Col>***REMOVED***" "***REMOVED***
          </Row>

          <Row>
            <Col>
              <small>Username</small>
              <div className="input-group">
                <input
                  type="text"
                  className="form-control"
                  aria-describedby="username"
                  defaultValue=***REMOVED***user.username***REMOVED***
                />
              </div>
            </Col>
          </Row>

          <Row>
            <Col>
              <small>Access token</small>
              <div className="input-group">
                <input
                  type="text"
                  className="form-control"
                  aria-describedby="token"
                  defaultValue=***REMOVED***
                    user.accessToken.substring(0, 20) +
                    " . . . " +
                    user.accessToken.substr(user.accessToken.length - 20)
                 ***REMOVED***
                />
              </div>
            </Col>
            <Col>
              <small>Authorities</small>
              <div className="input-group">
                <input
                  type="text"
                  className="form-control"
                  aria-describedby="Roles"
                  defaultValue=***REMOVED***user.userRole***REMOVED***
                />
              </div>
            </Col>***REMOVED***" "***REMOVED***
          </Row>
        </form>
      </Container>
    </Container>
  );
***REMOVED***;

function mapStateToProps(state: any) ***REMOVED***
  const ***REMOVED*** user***REMOVED*** = state.auth;
  return ***REMOVED***
    user,
 ***REMOVED***;
***REMOVED***

export default connect(mapStateToProps)(Profile);
