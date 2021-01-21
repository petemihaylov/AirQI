import React, ***REMOVED*** useState***REMOVED*** from "react";
import ***REMOVED*** Redirect***REMOVED*** from "react-router-dom";
import ***REMOVED*** connect***REMOVED*** from "react-redux";
import ***REMOVED*** login***REMOVED*** from "../../actions/auth";
import ***REMOVED*** useForm***REMOVED*** from "react-hook-form";
import ***REMOVED*** Card***REMOVED*** from "react-bootstrap";
import ***REMOVED*** BubbleButton***REMOVED*** from "../../assets/js/button/bubble";

const Login = (props: any) => ***REMOVED***
  const ***REMOVED*** isLoggedIn, message***REMOVED*** = props;

  const ***REMOVED*** register, handleSubmit, errors***REMOVED*** = useForm();
  const [loading, handleChange] = useState(false);

  const onSubmit = (data: any) => ***REMOVED***
    handleChange(true);

    const ***REMOVED*** dispatch, history***REMOVED*** = props;
    dispatch(login(data.username, data.password))
      .then(() => ***REMOVED***
        history.push("/dashboard");
        window.location.reload();
     ***REMOVED***)
      .catch(() => ***REMOVED***
        handleChange(false);
     ***REMOVED***);
 ***REMOVED***;

  // Checking if user is logged in
  if (isLoggedIn) return <Redirect to="/profile" />;

  return (
    <div
      className="container d-flex justify-content-center align-items-center"
      style=***REMOVED******REMOVED*** height: "80vh"***REMOVED******REMOVED***
    >
      <Card style=***REMOVED******REMOVED*** width: "20rem", height: "20rem"***REMOVED******REMOVED***>
        <Card.Title className="w-100 text-center pt-4">Login</Card.Title>
        <div className="d-flex align-items-center h-100">
          <Card.Body>
            <form onSubmit=***REMOVED***handleSubmit(onSubmit)***REMOVED***>
              <div className="form-group">
                <label>Username: </label>
                <input
                  ref=***REMOVED***register(***REMOVED*** required: true***REMOVED***)***REMOVED***
                  type="text"
                  className="form-control input-sm"
                  name="username"
                />
                ***REMOVED***errors.username && (
                  <div>
                    <small className="text-danger"> This is required</small>
                  </div>
                )***REMOVED***
              </div>

              <div className="form-group">
                <label>Password: </label>
                <input
                  ref=***REMOVED***register(***REMOVED*** required: true***REMOVED***)***REMOVED***
                  type="password"
                  className="form-control input-sm"
                  name="password"
                  autoComplete="password"
                />

                ***REMOVED***errors.password && (
                  <div>
                    <small className="text-danger"> This is required</small>
                  </div>
                )***REMOVED***
              </div>

              <div
                className="form-group"
                style=***REMOVED******REMOVED*** marginTop: "35px", marginBottom: "100px"***REMOVED******REMOVED***
              >
                <BubbleButton name=***REMOVED***"Login"***REMOVED*** disabled=***REMOVED***loading***REMOVED***>
                  ***REMOVED***loading && (
                    <span className="spinner-border spinner-border-sm"></span>
                  )***REMOVED***
                  ***REMOVED***!loading && <span>Login</span>***REMOVED***
                </BubbleButton>
              </div>

            </form>
          </Card.Body>
        </div>
            ***REMOVED***message && (
                <div className="form-group">
                  <div className="alert alert-secondary" role="alert">
                    ***REMOVED***message***REMOVED***
                  </div>
                </div>
              )***REMOVED***
          
      </Card>
      
    </div>
  );
***REMOVED***;

function mapStateToProps(state: any) ***REMOVED***
  const ***REMOVED*** isLoggedIn***REMOVED*** = state.auth;
  const ***REMOVED*** message***REMOVED*** = state.message;
  return ***REMOVED***
    isLoggedIn,
    message,
 ***REMOVED***;
***REMOVED***

export default connect(mapStateToProps)(Login);
