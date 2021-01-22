import React, { useCallback } from "react";
import { Redirect } from "react-router-dom";
import { connect } from "react-redux";
import { Container, Row, Col } from "react-bootstrap";
import { useForm } from "react-hook-form";
import ProfileImage from "./image";
import "./css/style.css";
import { updateUser } from "../../../actions/userActions";
import { update } from "../../../actions/auth";
import User from "../../../entities/User";
import Auth from "../../../entities/Auth";

interface CreateFormData {
  username: string;
  password: string;
  firstName: string;
  lastName: string;
  userRole: string;
}

const Profile = (props: any) => {
  const { register, handleSubmit, errors } = useForm<CreateFormData>();
  const { user } = props;

  const onSubmit = useCallback((data: CreateFormData) => {
    const { username, firstName, lastName, password, userRole } = data;
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
  }, []);

  if (!user) {
    return <Redirect to="/login" />;
  }

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

        <form onSubmit={handleSubmit(onSubmit)}>
          <Row className="mb-5">
            <Col xs={12} md={8} className="centered">
              <div>
                <h2>
                  <b>Edit profile</b>
                </h2>
                <small>
                  People on AirQI will get to know you with the info below
                </small>
              </div>
            </Col>
            <Col xs={6} md={4} className="centered">
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
                  ref={register({ required: true })}
                  className="form-control"
                  aria-describedby="first name"
                  defaultValue={user.firstName}
                  name="firstName"
                />
              </div>
              {errors.firstName?.type === "required" && (
                <div>
                  <small className="text-danger"> This is required</small>
                </div>
              )}
            </Col>
            <Col>
              <small>Last name</small>
              <div className="input-group-sm">
                <input
                  type="text"
                  name="lastName"
                  ref={register({ required: true })}
                  className="form-control"
                  aria-describedby="last name"
                  defaultValue={user.lastName}
                />
              </div>
              {errors.lastName?.type === "required" && (
                <div>
                  <small className="text-danger"> This is required</small>
                </div>
              )}
            </Col>{" "}
          </Row>

          <Row>
            <Col>
              <small>Username</small>
              <div className="input-group-sm">
                <input
                  type="text"
                  name="username"
                  ref={register({ required: true })}
                  className="form-control"
                  aria-describedby="username"
                  defaultValue={user.username}
                />
              </div>
              {errors.username?.type === "required" && (
                <div>
                  <small className="text-danger"> This is required</small>
                </div>
              )}
            </Col>
          </Row>

          <Row>
            <Col>
              <small>New password</small>
              <div className="input-group-sm">
                <input
                  type="password"
                  name="password"
                  ref={register({ required: true })}
                  className="form-control"
                  defaultValue="password123"
                  aria-describedby="Password"
                />
              </div>
              {errors.password?.type === "required" && (
                <div>
                  <small className="text-danger"> This is required</small>
                </div>
              )}
            </Col>
            <Col>
              <small>Authorities</small>
              <div className="input-group-sm">
                <input
                  type="text"
                  className="form-control"
                  aria-describedby="Roles"
                  name="userRole"
                  ref={register({ required: true })}
                  defaultValue={user.userRole}
                />
              </div>
            </Col>{" "}
          </Row>
        </form>
      </Container>
    </Container>
  );
};

function mapStateToProps(state: any) {
  const { user } = state.auth;
  return {
    user,
  };
}

export default connect(mapStateToProps)(Profile);
