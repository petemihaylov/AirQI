import React, ***REMOVED***useCallback***REMOVED*** from "react";
import ***REMOVED*** Redirect***REMOVED*** from "react-router-dom";
import ***REMOVED*** updateUser***REMOVED*** from "../../../actions/userActions";
import ***REMOVED*** connect***REMOVED*** from "react-redux";
import ***REMOVED*** Container, Row, Col***REMOVED*** from "react-bootstrap";
import ***REMOVED*** useForm***REMOVED*** from "react-hook-form";
import ProfileImage from "./image";
import "./css/style.css";
import User from "../../../entities/User";


interface CreateFormData ***REMOVED***
  username: string;
  password: string;
  firstName: string;
  lastName: string;
***REMOVED***

const Profile = (props: any) => ***REMOVED***

  const ***REMOVED*** register, handleSubmit, errors***REMOVED*** = useForm<CreateFormData>();  
  const ***REMOVED*** user***REMOVED*** = props;


  const onSubmit = useCallback((data: CreateFormData) => ***REMOVED***
    const ***REMOVED*** dispatch***REMOVED*** = props;
    const ***REMOVED***
      username,
      firstName,
      lastName,
   ***REMOVED*** = data;

    let userObj = new User(
      username,
      firstName,
      lastName,
      new Date(),
      true,
      user.password,
      user.userRole
    );
    console.log(userObj);
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
                <p>
                  <small className="text-danger"> This is required</small>
                </p>
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
                <p>
                  <small className="text-danger"> This is required</small>
                </p>
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
                <p>
                  <small className="text-danger"> This is required</small>
                </p>
              )***REMOVED***
            </Col>
          </Row>

          <Row>
            <Col>
              <small>Access token</small>
              <div className="input-group-sm">
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
              <div className="input-group-sm">
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
