import React, ***REMOVED***Component***REMOVED*** from "react";
import AuthService from "../services/auth.service";
import Form from "react-validation/build/form";
import Input from "react-validation/build/input";
import CheckButton from "react-validation/build/button";
import Container from "@material-ui/core/Container";

const required = value => ***REMOVED***
    if (!value) ***REMOVED***
        return (<div className="alert alert-danger" role="alert">
            This field is required!
        </div>);
   ***REMOVED***
***REMOVED***;

const vusername = value => ***REMOVED***
    if (value.length < 3 || value.length > 20) ***REMOVED***
        return (<div className="alert alert-danger" role="alert">
            The username must be between 3 and 20 characters.
        </div>);
   ***REMOVED***
***REMOVED***;

const vpassword = value => ***REMOVED***
    if (value.length < 6 || value.length > 40) ***REMOVED***
        return (<div className="alert alert-danger" role="alert">
            The password must be between 6 and 40 characters.
        </div>);
   ***REMOVED***
***REMOVED***;

export default class Register extends Component ***REMOVED***
    constructor(props) ***REMOVED***
        super(props);

        this.state = ***REMOVED***
            username: "",
            password: "",
            firstName: "",
            lastName: "",
            successful: false,
            message: ""
       ***REMOVED***
   ***REMOVED***

    onChangeUsername(e) ***REMOVED***
        this.setState(***REMOVED***username: e.target.value***REMOVED***);
   ***REMOVED***

    onChangePassword(e) ***REMOVED***
        this.setState(***REMOVED***password: e.target.value***REMOVED***);
   ***REMOVED***

    handleRegister(e) ***REMOVED***
        e.preventDefault();

        this.setState(***REMOVED***message: "", successful: false***REMOVED***);

        this.form.validateAll();

        if (this.checkBtn.context._errors.length === 0) ***REMOVED***
            AuthService.register(
                this.state.username,
                this.state.firstName,
                this.state.lastName,
                this.state.password
            ).then(
                response => ***REMOVED***
                    this.setState(***REMOVED***
                        message: response.data.message,
                        successful: true
                   ***REMOVED***);
               ***REMOVED***,
                error => ***REMOVED***
                    const resMessage =
                        (error.response &&
                            error.response.data &&
                            error.response.data.message) ||
                        error.message ||
                        error.toString();

                    this.setState(***REMOVED***
                        successful: false,
                        message: resMessage
                   ***REMOVED***);
               ***REMOVED***
            );
       ***REMOVED***

   ***REMOVED***

    render() ***REMOVED***
        return (
          <Container maxWidth="sm">
            <div className="col-md-12">
              <div className="card card-container p-5 mt-5">
                <h4 className="mb-5 mt-4">Sign Up</h4>
                <Form
                  onSubmit=***REMOVED***this.handleRegister***REMOVED***
                  ref=***REMOVED***(c) => ***REMOVED***
                    this.form = c;
                 ***REMOVED******REMOVED***
                >
                  ***REMOVED***" "***REMOVED***
                  ***REMOVED***!this.state.successful && (
                    <div>
                      <div className="form-group">
                        <label htmlFor="username">Username</label>
                        <Input
                          type="text"
                          className="form-control"
                          name="username"
                          value=***REMOVED***this.state.username***REMOVED***
                          onChange=***REMOVED***this.onChangeUsername***REMOVED***
                          validations=***REMOVED***[required, vusername]***REMOVED***
                        />
                      </div>

                      <div className="form-group">
                        <label htmlFor="firstName">First name</label>
                        <Input
                          type="text"
                          className="form-control"
                          name="firstName"
                          value=***REMOVED***this.state.firstName***REMOVED***
                        />
                      </div>

                      <div className="form-group">
                        <label htmlFor="lastName">Last name</label>
                        <Input
                          type="text"
                          className="form-control"
                          name="lastName"
                          value=***REMOVED***this.state.lastName***REMOVED***
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
                          validations=***REMOVED***[required, vpassword]***REMOVED***
                        />
                      </div>

                      <div className="form-group">
                        <button className="btn btn-success btn-block">
                          Sign Up
                        </button>
                      </div>
                    </div>
                  )***REMOVED***
                  ***REMOVED***this.state.message && (
                    <div className="form-group">
                      <div
                        className=***REMOVED***
                          this.state.successful
                            ? "alert alert-success"
                            : "alert alert-danger"
                       ***REMOVED***
                        role="alert"
                      >
                        ***REMOVED***" "***REMOVED***
                        ***REMOVED***this.state.message***REMOVED******REMOVED***" "***REMOVED***
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
