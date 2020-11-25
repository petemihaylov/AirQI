import React, { useCallback, useState } from "react";
import { connect } from "react-redux";
import { useForm } from "react-hook-form";
import { Card } from "react-bootstrap";
import { register as registerAction } from "../../actions/auth";

import User from "../../entities/User";
import Roles from "../../entities/Roles";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faExclamationTriangle } from "@fortawesome/free-solid-svg-icons";
import { BubbleButton } from "../../assets/js/button/bubble";

interface RegistrationFormData {
  username: string;
  password: string;
  firstName: string;
  lastName: string;
}

const Register = (props: any) => {
  const { message } = props;
  const [loading, handleChange] = useState(false);
  const { register, handleSubmit, errors } = useForm<RegistrationFormData>();

  const onSubmit = useCallback((data: RegistrationFormData) => {
    handleChange(false);

    const { dispatch, history } = props;
    const { username, firstName, lastName, password } = data;

    let userObj = new User(
      username,
      firstName,
      lastName,
      password,
      Roles.Moderator,
      true
    );

    dispatch(registerAction(userObj)).then(() => {
      handleChange(true);
      history.push("/login");
      window.location.reload();
    });
  }, []);

  return (
    <div
      className="container d-flex justify-content-center align-items-center"
      style={{ height: "80vh" }}
    >
      <Card style={{ width: "20rem", height: "30rem" }}>
        <Card.Title className="w-100 text-center pt-4">Register</Card.Title>
        <div className="d-flex align-items-center h-100">
          <Card.Body>
            <form onSubmit={handleSubmit(onSubmit)}>
              <div className="form-group">
                <label>Username: </label>
                <input
                  ref={register({ required: true })}
                  type="text"
                  className="form-control input-sm"
                  name="username"
                />
                {errors.username && (
                  <p>
                    <small className="text-danger"> This is required</small>
                  </p>
                )}
              </div>

              <div className="form-group">
                <label>First name: </label>
                <input
                  ref={register({ required: true })}
                  type="text"
                  className="form-control input-sm"
                  name="firstName"
                />
                {errors.firstName && (
                  <p>
                    <small className="text-danger"> This is required</small>
                  </p>
                )}
              </div>

              <div className="form-group">
                <label>Last name: </label>
                <input
                  ref={register({ required: true })}
                  type="text"
                  className="form-control input-sm"
                  name="lastName"
                />
                {errors.lastName && (
                  <p>
                    <small className="text-danger"> This is required</small>
                  </p>
                )}
              </div>

              <div className="form-group">
                <label>Password: </label>
                <input
                  ref={register({ required: true, minLength: 5 })}
                  type="password"
                  className="form-control input-sm"
                  name="password"
                  autoComplete="password"
                />

                {errors.password?.type === "minLength" && (
                  <small className="text-danger">
                    Your password is too weak
                  </small>
                )}

                {errors.password?.type === "required" && (
                  <p>
                    <small className="text-danger"> This is required</small>
                  </p>
                )}
              </div>

              <div
                className="form-group"
                style={{ marginTop: "35px", marginBottom: "100px" }}
              >
                <BubbleButton name={"SignUp"} disabled={loading}>
                  {loading && (
                    <span className="spinner-border spinner-border-sm"></span>
                  )}
                  {!loading && <span>SignUp</span>}
                </BubbleButton>
              </div>

              {message && (
                <div className="form-group">
                  <div className="alert alert-secondary" role="alert">
                    <FontAwesomeIcon icon={faExclamationTriangle} /> {message}
                  </div>
                </div>
              )}
            </form>
          </Card.Body>
        </div>
      </Card>
    </div>
  );
};

function mapStateToProps(state: any) {
  const { message } = state.message;
  return {
    message,
  };
}

export default connect(mapStateToProps)(Register);
