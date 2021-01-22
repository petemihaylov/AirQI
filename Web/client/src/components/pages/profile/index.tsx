import React, ***REMOVED*** useCallback***REMOVED*** from "react";
import ***REMOVED*** Redirect***REMOVED*** from "react-router-dom";
import ***REMOVED*** connect***REMOVED*** from "react-redux";
import ***REMOVED*** Container, Row, Col***REMOVED*** from "react-bootstrap";
import ***REMOVED*** useForm***REMOVED*** from "react-hook-form";
import ProfileImage from "./image";
import "./css/style.css";
import ***REMOVED*** updateUser***REMOVED*** from "../../../actions/userActions";
import ***REMOVED*** update***REMOVED*** from "../../../actions/auth";
import User from "../../../entities/User";
import Auth from "../../../entities/Auth";

interface CreateFormData ***REMOVED***
  username: string;
  password: string;
  firstName: string;
  lastName: string;
  userRole: string;
***REMOVED***

const Profile = (props: any) => ***REMOVED***
  const ***REMOVED*** register, handleSubmit, errors***REMOVED*** = useForm<CreateFormData>();
  const ***REMOVED*** user***REMOVED*** = props;

  const onSubmit = useCallback((data: CreateFormData) => ***REMOVED***
    const ***REMOVED*** username, firstName, lastName, password, userRole***REMOVED*** = data;
    var newUser = new User(
      username,
      firstName,
      lastName,
      new Date(),
      true,
      password,
      userRole
    );
    newUser.id = props.user.id;

    var newAuth = new Auth(
      props.user.id,
      username,
      firstName,
      lastName,
      new Date(),
      true,
      password,
      userRole,
      props.user.accessToken
    );
    props.dispatch(updateUser(newUser));
    props.dispatch(update(newAuth));

    console.log(password);
 ***REMOVED***, []);

  if (!user) ***REMOVED***
    return <Redirect to="/login" />;
 ***REMOVED***

  return (
    <Container className="centered wrapper">
      <Container className="w-75">
        <Row>
          <Col></Col>
          <Col>
            <ProfileImage />
          </Col>
          <Col></Col>
        </Row>

        <form onSubmit=***REMOVED***handleSubmit(onSubmit)***REMOVED***>
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

          <Row>
            <Col>
              <small>First name</small>
              <div className="input-group-sm">
                <input
                  type="text"
                  ref=***REMOVED***register(***REMOVED*** required: true***REMOVED***)***REMOVED***
                  className="form-control"
                  aria-describedby="first name"
                  defaultValue=***REMOVED***user.firstName***REMOVED***
                  name="firstName"
                />
              </div>
              ***REMOVED***errors.firstName?.type === "required" && (
                <div>
                  <small className="text-danger"> This is required</small>
                </div>
              )***REMOVED***
            </Col>
            <Col>
              <small>Last name</small>
              <div className="input-group-sm">
                <input
                  type="text"
                  name="lastName"
                  ref=***REMOVED***register(***REMOVED*** required: true***REMOVED***)***REMOVED***
                  className="form-control"
                  aria-describedby="last name"
                  defaultValue=***REMOVED***user.lastName***REMOVED***
                />
              </div>
              ***REMOVED***errors.lastName?.type === "required" && (
                <div>
                  <small className="text-danger"> This is required</small>
                </div>
              )***REMOVED***
            </Col>***REMOVED***" "***REMOVED***
          </Row>

          <Row>
            <Col>
              <small>Username</small>
              <div className="input-group-sm">
                <input
                  type="text"
                  name="username"
                  ref=***REMOVED***register(***REMOVED*** required: true***REMOVED***)***REMOVED***
                  className="form-control"
                  aria-describedby="username"
                  defaultValue=***REMOVED***user.username***REMOVED***
                />
              </div>
              ***REMOVED***errors.username?.type === "required" && (
                <div>
                  <small className="text-danger"> This is required</small>
                </div>
              )***REMOVED***
            </Col>
          </Row>

          <Row>
            <Col>
              <small>New password</small>
              <div className="input-group-sm">
                <input
                  type="password"
                  name="password"
                  ref=***REMOVED***register(***REMOVED*** required: true***REMOVED***)***REMOVED***
                  className="form-control"
                  defaultValue="password123"
                  aria-describedby="Password"
                />
              </div>
              ***REMOVED***errors.password?.type === "required" && (
                <div>
                  <small className="text-danger"> This is required</small>
                </div>
              )***REMOVED***
            </Col>
            <Col>
              <small>Authorities</small>
              <div className="input-group-sm">
                <input
                  type="text"
                  className="form-control"
                  aria-describedby="Roles"
                  name="userRole"
                  ref=***REMOVED***register(***REMOVED*** required: true***REMOVED***)***REMOVED***
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
