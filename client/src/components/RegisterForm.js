import React, ***REMOVED*** Component***REMOVED*** from "react";

export default class RegisterForm extends Component ***REMOVED***
  constructor(props) ***REMOVED***
    super(props);

    this.state = ***REMOVED***
      user: ***REMOVED***
        username: "",
        password: "",
     ***REMOVED***,
   ***REMOVED***;

    this.onInputChanged = this.onInputChanged.bind(this);
    this.onFormSubmit = this.onFormSubmit.bind(this);
 ***REMOVED***

  onInputChanged(event) ***REMOVED***
    let user = this.state.user;

    let inputName = event.target.name;
    let inputValue = event.target.value;

    user[inputName] = inputValue;

    this.setState(***REMOVED*** user***REMOVED***);
 ***REMOVED***

  onFormSubmit(event) ***REMOVED***
    event.preventDefault();
    console.log(this.state.user);
 ***REMOVED***

  render() ***REMOVED***
    return (
      <div className="container mt-4">
        <form onSubmit=***REMOVED***this.onFormSubmit***REMOVED***>
          <div className="form-group">
            <input
              type="text"
              className="form-control"
              placeholder="Username"
              name="username"
              value=***REMOVED***this.state.value***REMOVED***
              onChange=***REMOVED***this.onInputChanged***REMOVED***
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
              value=***REMOVED***this.state.value***REMOVED***
              onChange=***REMOVED***this.onInputChanged***REMOVED***
              placeholder="Password"
            />
          </div>

          <button type="submit" className="btn btn-primary">
            Submit
          </button>
        </form>
      </div>
    );
 ***REMOVED***
***REMOVED***
