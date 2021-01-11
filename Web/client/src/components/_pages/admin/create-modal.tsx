import ***REMOVED*** Container, Modal***REMOVED*** from "react-bootstrap";
import React, ***REMOVED*** useCallback, useState***REMOVED*** from "react";
import ***REMOVED*** useForm***REMOVED*** from "react-hook-form";
import ***REMOVED*** connect***REMOVED*** from "react-redux";
import ***REMOVED*** createUser***REMOVED*** from "../../../actions/userActions";

import User from "../../../entities/User";
import Roles from "../../../entities/Roles";
import ***REMOVED*** FontAwesomeIcon***REMOVED*** from "@fortawesome/react-fontawesome";
import ***REMOVED*** faExclamationTriangle***REMOVED*** from "@fortawesome/free-solid-svg-icons";

interface CreateFormData ***REMOVED***
  username: string;
  password: string;
  firstName: string;
  lastName: string;
  lastActive: Date;
  isActive: boolean;
  role: string;
***REMOVED***

const CreateModal = (props: any) => ***REMOVED***
  const ***REMOVED*** message***REMOVED*** = props;
  const ***REMOVED*** register, handleSubmit, errors***REMOVED*** = useForm<CreateFormData>();

  const onSubmit = useCallback((data: CreateFormData) => ***REMOVED***
    const ***REMOVED*** dispatch***REMOVED*** = props.props;
    const ***REMOVED***
      username,
      firstName,
      lastName,
      password,
      role,
      lastActive,
      isActive,
   ***REMOVED*** = data;

    let userObj = new User(
      username,
      firstName,
      lastName,
      lastActive,
      isActive,
      password,
      role
    );
    dispatch(createUser(userObj)).then(() => ***REMOVED***
      props.onHide();
   ***REMOVED***);
 ***REMOVED***, []);

  return (
    <Modal ***REMOVED***...props***REMOVED*** aria-labelledby="contained-modal-title-vcenter" centered>
      <Modal.Header closeButton></Modal.Header>
      <Modal.Body>
        <Container className="d-flex pl-5 pr-5">
          <form onSubmit=***REMOVED***handleSubmit(onSubmit)***REMOVED*** className="w-100">
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
                <small className="text-danger">Your password is too weak</small>
              )***REMOVED***

              ***REMOVED***errors.password?.type === "required" && (
                <p>
                  <small className="text-danger"> This is required</small>
                </p>
              )***REMOVED***
            </div>

            <div className="form-group">
              <label>Role:</label>
              <select
                className="custom-select"
                name="role"
                ref=***REMOVED***register(***REMOVED*** required: true***REMOVED***)***REMOVED***
              >
                <option value="Moderator">Moderator</option>
                <option value="Admin">Admin</option>
                <option value="User">User</option>
              </select>
              ***REMOVED***errors.role?.type === "required" && (
                <p>
                  <small className="text-danger"> This is required</small>
                </p>
              )***REMOVED***
            </div>
            <div className="form-group d-flex justify-content-center">
              <button className="btn btn-dark btn-block w-75">Create</button>
            </div>

            ***REMOVED***message && (
              <div className="form-group">
                <div className="alert alert-secondary" role="alert">
                  <FontAwesomeIcon icon=***REMOVED***faExclamationTriangle***REMOVED*** /> ***REMOVED***message***REMOVED***
                </div>
              </div>
            )***REMOVED***
          </form>
        </Container>
      </Modal.Body>
    </Modal>
  );
***REMOVED***;

function mapStateToProps(state: any) ***REMOVED***
  const ***REMOVED*** message***REMOVED*** = state.message;
  const ***REMOVED*** users***REMOVED*** = state.users;
  return ***REMOVED***
    message,
    users,
 ***REMOVED***;
***REMOVED***

export default connect(mapStateToProps)(CreateModal);
