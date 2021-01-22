import React, ***REMOVED*** useCallback, useState***REMOVED*** from "react";
import ***REMOVED*** connect***REMOVED*** from "react-redux";
import ***REMOVED*** useForm***REMOVED*** from "react-hook-form";
import ***REMOVED*** Card***REMOVED*** from "react-bootstrap";
import ***REMOVED*** register as registerAction***REMOVED*** from "../../actions/auth";

import User from "../../entities/User";
import Roles from "../../entities/Roles";
import ***REMOVED*** FontAwesomeIcon***REMOVED*** from "@fortawesome/react-fontawesome";
import ***REMOVED*** faExclamationTriangle***REMOVED*** from "@fortawesome/free-solid-svg-icons";
import ***REMOVED*** BubbleButton***REMOVED*** from "../../assets/js/button/bubble";

interface RegistrationFormData ***REMOVED***
  username: string;
  password: string;
  firstName: string;
  lastName: string;
  lastActive: Date;
  isActive: boolean;
***REMOVED***

const Register = (props: any) => ***REMOVED***
  const ***REMOVED*** message***REMOVED*** = props;
  const [loading, handleChange] = useState(false);
  const ***REMOVED*** register, handleSubmit, errors***REMOVED*** = useForm<RegistrationFormData>();

  const onSubmit = useCallback((data: RegistrationFormData) => ***REMOVED***
    handleChange(false);

    const ***REMOVED*** dispatch, history***REMOVED*** = props;
    const ***REMOVED*** username, firstName, lastName, password, lastActive, isActive***REMOVED*** = data;
    
    let userObj = new User(
      username,
      firstName,
      lastName,
      new Date(),
      true,
      password,
      Roles.Moderator
    );

    dispatch(registerAction(userObj)).then(() => ***REMOVED***
      handleChange(true);
      history.push("/login");
      window.location.reload();
   ***REMOVED***);
 ***REMOVED***, []);

  return (
    <div
      className="container d-flex-column justify-content-center align-items-center pt-3"
      style=***REMOVED******REMOVED*** width: "22vw"***REMOVED******REMOVED***
    >
      <Card style=***REMOVED******REMOVED*** width: "22vw", height: "33rem"***REMOVED******REMOVED*** className="mt-5">
        <Card.Title className="w-100 text-center pt-4 mb-5">
          Register
        </Card.Title>
        <Card.Body className="d-flex align-items-center h-100 mt-5">
          <form onSubmit=***REMOVED***handleSubmit(onSubmit)***REMOVED***>
            <div className="form-group">
              <label>Username: </label>
              <input
                ref=***REMOVED***register(***REMOVED*** required: true***REMOVED***)***REMOVED***
                type="text"
                className="form-control input-sm"
                name="username"
              />
              ***REMOVED***errors.username && (
                <div>
                  <small className="text-danger"> This is required</small>
                </div>
              )***REMOVED***
            </div>

            <div className="form-group">
              <label>First name: </label>
              <input
                ref=***REMOVED***register(***REMOVED*** required: true***REMOVED***)***REMOVED***
                type="text"
                className="form-control input-sm"
                name="firstName"
              />
              ***REMOVED***errors.firstName && (
                <div>
                  <small className="text-danger"> This is required</small>
                </div>
              )***REMOVED***
            </div>

            <div className="form-group">
              <label>Last name: </label>
              <input
                ref=***REMOVED***register(***REMOVED*** required: true***REMOVED***)***REMOVED***
                type="text"
                className="form-control input-sm"
                name="lastName"
              />
              ***REMOVED***errors.lastName && (
                <div>
                  <small className="text-danger"> This is required</small>
                </div>
              )***REMOVED***
            </div>

            <div className="form-group">
              <label>Password: </label>
              <input
                ref=***REMOVED***register(***REMOVED*** required: true, minLength: 5***REMOVED***)***REMOVED***
                type="password"
                className="form-control input-sm"
                name="password"
                autoComplete="password"
              />

              ***REMOVED***errors.password?.type === "minLength" && (
                <small className="text-danger">Your password is too weak</small>
              )***REMOVED***

              ***REMOVED***errors.password?.type === "required" && (
                <div>
                  <small className="text-danger"> This is required</small>
                </div>
              )***REMOVED***
            </div>

            <div
              className="form-group"
              style=***REMOVED******REMOVED*** marginTop: "35px", marginBottom: "100px"***REMOVED******REMOVED***
            >
              <BubbleButton name=***REMOVED***"SignUp"***REMOVED*** disabled=***REMOVED***loading***REMOVED***>
                ***REMOVED***loading && (
                  <span className="spinner-border spinner-border-sm"></span>
                )***REMOVED***
                ***REMOVED***!loading && <span>SignUp</span>***REMOVED***
              </BubbleButton>
            </div>
          </form>
        </Card.Body>
      </Card>
      ***REMOVED***message && (
        <div className="form-group mt-4 d-flex justify-content-center">
          <div className="alert alert-secondary" role="alert">
            <FontAwesomeIcon icon=***REMOVED***faExclamationTriangle***REMOVED*** /> ***REMOVED***message***REMOVED***
          </div>
        </div>
      )***REMOVED***
    </div>
  );
***REMOVED***;

function mapStateToProps(state: any) ***REMOVED***
  const ***REMOVED*** message***REMOVED*** = state.message;
  return ***REMOVED***
    message,
 ***REMOVED***;
***REMOVED***

export default connect(mapStateToProps)(Register);
