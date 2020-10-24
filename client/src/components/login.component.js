import React, ***REMOVED*** Component***REMOVED*** from "react";
import Form from "react-validation/build/form";
import Input from "react-validation/build/input";
import CheckButton from "react-validation/build/button";

import AuthService from "../services/auth.service";
import Container from "@material-ui/core/Container";
import Avatar from "@material-ui/core/Avatar";

const required = (value) => ***REMOVED***
  if (!value) ***REMOVED***
    return (
      <div className="alert alert-danger" role="alert">
        This field is required!
      </div>
    );
 ***REMOVED***
***REMOVED***;

export default class Login extends Component ***REMOVED***
  constructor(props) ***REMOVED***
    super(props);
    this.handleLogin = this.handleLogin.bind(this);
    this.onChangeUsername = this.onChangeUsername.bind(this);
    this.onChangePassword = this.onChangePassword.bind(this);

    this.state = ***REMOVED***
      username: "",
      password: "",
      loading: false,
      message: "",
   ***REMOVED***;
 ***REMOVED***

  onChangeUsername(e) ***REMOVED***
    
    this.setState(***REMOVED***
      username: e.target.value,
   ***REMOVED***);
 ***REMOVED***

  onChangePassword(e) ***REMOVED***
    this.setState(***REMOVED***
      password: e.target.value,
   ***REMOVED***);
 ***REMOVED***

  handleLogin(e) ***REMOVED***
    e.preventDefault();

    this.setState(***REMOVED***
      message: "",
      loading: true,
   ***REMOVED***);

    this.form.validateAll();

    if (this.checkBtn.context._errors.length === 0) ***REMOVED***
      
     AuthService.login(this.state.username, this.state.password).then(
        () => ***REMOVED***
          this.props.history.push("/profile");
          window.location.reload();
       ***REMOVED***,
        error => ***REMOVED***
          const resMessage =
            (error.response &&
              error.response.data &&
              error.response.data.message) ||
            error.message ||
            error.toString();

          this.setState(***REMOVED***
            loading: false,
            message: resMessage
         ***REMOVED***);
       ***REMOVED***
      );
   ***REMOVED*** else ***REMOVED***
      this.setState(***REMOVED***
        loading: false,
     ***REMOVED***);
   ***REMOVED***
 ***REMOVED***

  render() ***REMOVED***
    return (
      <Container maxWidth="sm">
        <div className="col-md-12 mt-5">
          <div className="card card-container p-5 mt-5 d-flex">
            
            <h4 className="mb-5 mt-3 ">Login</h4>
            <Form
              onSubmit=***REMOVED***this.handleLogin***REMOVED***
              ref=***REMOVED***(c) => ***REMOVED***
                this.form = c;
             ***REMOVED******REMOVED***
            >
              <div className="form-group">
                <label htmlFor="username">Username</label>
                <Input
                  type="text"
                  className="form-control"
                  name="username"
                  value=***REMOVED***this.state.username***REMOVED***
                  onChange=***REMOVED***this.onChangeUsername***REMOVED***
                  validations=***REMOVED***[required]***REMOVED***
                />
              </div>

              <div className="form-group">
                <label htmlFor="password">Password</label>
                <Input
                  type="password"
                  className="form-control"
                  name="password"
                  value=***REMOVED***this.state.password***REMOVED***
                  onChange=***REMOVED***this.onChangePassword***REMOVED***
                  validations=***REMOVED***[required]***REMOVED***
                />
              </div>

              <div className="form-group">
                <button
                  className="btn btn-success btn-block"
                  disabled=***REMOVED***this.state.loading***REMOVED***
                >
                  ***REMOVED***this.state.loading && (
                    <span className="spinner-border spinner-border-sm"></span>
                  )***REMOVED***
                  <span>Login</span>
                </button>
              </div>

              ***REMOVED***this.state.message && (
                <div className="form-group">
                  <div className="alert alert-danger" role="alert">
                    ***REMOVED***this.state.message***REMOVED***
                  </div>
                </div>
              )***REMOVED***
              <CheckButton
                style=***REMOVED******REMOVED*** display: "none"***REMOVED******REMOVED***
                ref=***REMOVED***(c) => ***REMOVED***
                  this.checkBtn = c;
               ***REMOVED******REMOVED***
              />
            </Form>
          </div>
        </div>
      </Container>
    );
 ***REMOVED***
***REMOVED***
