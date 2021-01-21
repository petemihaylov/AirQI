import React, { useState } from "react";
import { Redirect } from "react-router-dom";
import { connect } from "react-redux";
import { login } from "../../actions/auth";
import { useForm } from "react-hook-form";
import { Card } from "react-bootstrap";
import { BubbleButton } from "../../assets/js/button/bubble";

const Login = (props: any) => {
  const { isLoggedIn, message } = props;

  const { register, handleSubmit, errors } = useForm();
  const [loading, handleChange] = useState(false);

  const onSubmit = (data: any) => {
    handleChange(true);

    const { dispatch, history } = props;
    dispatch(login(data.username, data.password))
      .then(() => {
        history.push("/dashboard");
        window.location.reload();
      })
      .catch(() => {
        handleChange(false);
      });
  };

  // Checking if user is logged in
  if (isLoggedIn) return <Redirect to="/profile" />;

  return (
    <div
      className="container d-flex justify-content-center align-items-center"
      style={{ height: "80vh" }}
    >
      <Card style={{ width: "20rem", height: "20rem" }}>
        <Card.Title className="w-100 text-center pt-4">Login</Card.Title>
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
                  <div>
                    <small className="text-danger"> This is required</small>
                  </div>
                )}
              </div>

              <div className="form-group">
                <label>Password: </label>
                <input
                  ref={register({ required: true })}
                  type="password"
                  className="form-control input-sm"
                  name="password"
                  autoComplete="password"
                />

                {errors.password && (
                  <div>
                    <small className="text-danger"> This is required</small>
                  </div>
                )}
              </div>

              <div
                className="form-group"
                style={{ marginTop: "35px", marginBottom: "100px" }}
              >
                <BubbleButton name={"Login"} disabled={loading}>
                  {loading && (
                    <span className="spinner-border spinner-border-sm"></span>
                  )}
                  {!loading && <span>Login</span>}
                </BubbleButton>
              </div>

            </form>
          </Card.Body>
        </div>
            {message && (
                <div className="form-group">
                  <div className="alert alert-secondary" role="alert">
                    {message}
                  </div>
                </div>
              )}
          
      </Card>
      
    </div>
  );
};

function mapStateToProps(state: any) {
  const { isLoggedIn } = state.auth;
  const { message } = state.message;
  return {
    isLoggedIn,
    message,
  };
}

export default connect(mapStateToProps)(Login);
