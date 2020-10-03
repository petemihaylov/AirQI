import React, { Component } from "react";

export default class RegisterForm extends Component {
  constructor(props) {
    super(props);

    this.state = {
      user: {
        username: "",
        password: "",
      },
    };

    this.onInputChanged = this.onInputChanged.bind(this);
    this.onFormSubmit = this.onFormSubmit.bind(this);
  }

  onInputChanged(event) {
    let user = this.state.user;

    let inputName = event.target.name;
    let inputValue = event.target.value;

    user[inputName] = inputValue;

    this.setState({ user });
  }

  onFormSubmit(event) {
    event.preventDefault();
    console.log(this.state.user);
  }

  render() {
    return (
      <div className="container mt-4">
        <form onSubmit={this.onFormSubmit}>
          <div className="form-group">
            <input
              type="text"
              className="form-control"
              placeholder="Username"
              name="username"
              value={this.state.value}
              onChange={this.onInputChanged}
            />
            <small id="emailHelp" className="form-text text-muted">
              We'll never share your personal info.
            </small>
          </div>

          <div className="form-group">
            <input
              type="password"
              className="form-control"
              name="password"
              value={this.state.value}
              onChange={this.onInputChanged}
              placeholder="Password"
            />
          </div>

          <button type="submit" className="btn btn-primary">
            Submit
          </button>
        </form>
      </div>
    );
  }
}
