import { Container, Modal } from "react-bootstrap";
import React, { useCallback, useState } from "react";
import { useForm } from "react-hook-form";
import { connect } from "react-redux";
import { register as registerAction } from "../../../actions/auth";

import User from "../../../entities/User";
import Roles from "../../../entities/Roles";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faExclamationTriangle } from "@fortawesome/free-solid-svg-icons";

interface CreateFormData {
  username: string;
  password: string;
  firstName: string;
  lastName: string;
  role: string;
}

const CreateModal = (props: any) => {
  const { message } = props;
  const { register, handleSubmit, errors } = useForm<CreateFormData>();

  const onSubmit = useCallback((data: CreateFormData) => {
    const { dispatch } = props.props;
    const { username, firstName, lastName, password, role } = data;

    let userObj = new User(
      username,
      firstName,
      lastName,
      password,
      role,
      true
    );
    dispatch(registerAction(userObj)).then(() => {
      props.onHide();
    });
  }, []);

  return (
    <Modal {...props} aria-labelledby="contained-modal-title-vcenter" centered>
      <Modal.Header closeButton></Modal.Header>
      <Modal.Body>
        <Container className="d-flex pl-5 pr-5">
          <form onSubmit={handleSubmit(onSubmit)} className="w-100">
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
                <small className="text-danger">Your password is too weak</small>
              )}

              {errors.password?.type === "required" && (
                <p>
                  <small className="text-danger"> This is required</small>
                </p>
              )}
            </div>

            <div className="form-group">
              <label>Role:</label>
              <select
                className="custom-select"
                name="role"
                ref={register({ required: true })}
              >
                <option value="Moderator">Moderator</option>
                <option value="Admin">Admin</option>
                <option value="User">User</option>
              </select>
              {errors.role?.type === "required" && (
                <p>
                  <small className="text-danger"> This is required</small>
                </p>
              )}
            </div>
            <div className="form-group d-flex justify-content-center">
              <button className="btn btn-dark btn-block w-75">Create</button>
            </div>

            {message && (
              <div className="form-group">
                <div className="alert alert-secondary" role="alert">
                  <FontAwesomeIcon icon={faExclamationTriangle} /> {message}
                </div>
              </div>
            )}
          </form>
        </Container>
      </Modal.Body>
    </Modal>
  );
};

function mapStateToProps(state: any) {
  const { message } = state.message;
  return {
    message,
  };
}

export default connect(mapStateToProps)(CreateModal);
