import React, ***REMOVED*** useCallback, useState***REMOVED*** from "react";
import ***REMOVED*** connect***REMOVED*** from "react-redux";
import ***REMOVED*** useForm***REMOVED*** from "react-hook-form";
import ***REMOVED*** Card***REMOVED*** from "react-bootstrap";
import ***REMOVED*** register as registerAction***REMOVED*** from "../../actions/auth";

import User from "../../entities/User";
import Roles from "../../entities/Roles";
import ***REMOVED*** FontAwesomeIcon***REMOVED*** from "@fortawesome/react-fontawesome";
import ***REMOVED*** faExclamationTriangle***REMOVED*** from "@fortawesome/free-solid-svg-icons";

interface RegistrationFormData ***REMOVED***
  username: string;
  password: string;
  firstName: string;
  lastName: string;
***REMOVED***

const Register = (props: any) => ***REMOVED***
  const ***REMOVED*** message***REMOVED*** = props;
  const [loading, handleChange] = useState(false);
  const ***REMOVED*** register, handleSubmit, errors***REMOVED*** = useForm<RegistrationFormData>();

  const onSubmit = useCallback((data: RegistrationFormData) => ***REMOVED***
    handleChange(false);

    const ***REMOVED*** dispatch, history***REMOVED*** = props;
    const ***REMOVED*** username, firstName, lastName, password***REMOVED*** = data;

    let userObj = new User(
      username,
      firstName,
      lastName,
      password,
      Roles.Moderator,
      true
    );

    dispatch(registerAction(userObj)).then(() => ***REMOVED***
      handleChange(true);
      history.push("/login");
      window.location.reload();
   ***REMOVED***);
 ***REMOVED***, []);

  return (
    <div className="container d-flex justify-content-center">
      <Card style=***REMOVED******REMOVED*** width: "20rem", height: "30rem"***REMOVED******REMOVED***>
        <Card.Title className="w-100 text-center pt-4">Register</Card.Title>
        <div className="d-flex align-items-center h-100">
          <Card.Body>
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
                  <p>
                    <small className="text-danger"> This is required</small>
                  </p>
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
                  <p>
                    <small className="text-danger"> This is required</small>
                  </p>
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
                  <p>
                    <small className="text-danger"> This is required</small>
                  </p>
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
                  <small className="text-danger">
                    Your password is too weak
                  </small>
                )***REMOVED***

                ***REMOVED***errors.password?.type === "required" && (
                  <p>
                    <small className="text-danger"> This is required</small>
                  </p>
                )***REMOVED***
              </div>

              <div className="form-group">
                <button
                  className="btn btn-success btn-block"
                  disabled=***REMOVED***loading***REMOVED***
                  name="button"
                >
                  ***REMOVED***loading && (
                    <span className="spinner-border spinner-border-sm"></span>
                  )***REMOVED***
                  ***REMOVED***!loading && <span>Sign Up</span>***REMOVED***
                </button>
              </div>

              ***REMOVED***message && (
                <div className="form-group">
                  <div className="alert alert-secondary" role="alert">
                    <FontAwesomeIcon icon=***REMOVED***faExclamationTriangle***REMOVED*** /> ***REMOVED***message***REMOVED***
                  </div>
                </div>
              )***REMOVED***
            </form>
          </Card.Body>
        </div>
      </Card>
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
