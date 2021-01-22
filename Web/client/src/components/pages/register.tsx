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
  lastActive: Date;
  isActive: boolean;
}

const Register = (props: any) => {
  const { message } = props;
  const [loading, handleChange] = useState(false);
  const { register, handleSubmit, errors } = useForm<RegistrationFormData>();

  const onSubmit = useCallback((data: RegistrationFormData) => {
    handleChange(false);

    const { dispatch, history } = props;
    const { username, firstName, lastName, password, lastActive, isActive } = data;
    
    let userObj = new User(
      username,
      firstName,
      lastName,
      new Date(),
      true,
      password,
      Roles.Moderator
    );

    dispatch(registerAction(userObj)).then(() => {
      handleChange(true);
      history.push("/login");
      window.location.reload();
    });
  }, []);

  return (
    <div
      className="container d-flex-column justify-content-center align-items-center pt-3"
      style={{ width: "22vw" }}
    >
      <Card style={{ width: "22vw", height: "33rem" }} className="mt-5">
        <Card.Title className="w-100 text-center pt-4 mb-5">
          Register
        </Card.Title>
        <Card.Body className="d-flex align-items-center h-100 mt-5">
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
                <div>
                  <small className="text-danger"> This is required</small>
                </div>
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
                <div>
                  <small className="text-danger"> This is required</small>
                </div>
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
                <div>
                  <small className="text-danger"> This is required</small>
                </div>
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
                <small className="text-danger">Your password is too weak</small>
              )}

              {errors.password?.type === "required" && (
                <div>
                  <small className="text-danger"> This is required</small>
                </div>
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
          </form>
        </Card.Body>
      </Card>
      {message && (
        <div className="form-group mt-4 d-flex justify-content-center">
          <div className="alert alert-secondary" role="alert">
            <FontAwesomeIcon icon={faExclamationTriangle} /> {message}
          </div>
        </div>
      )}
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
