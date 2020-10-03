import React, ***REMOVED*** Component***REMOVED*** from "react";
import ***REMOVED*** BrowserRouter as Router, Switch, Route***REMOVED*** from "react-router-dom";
import Dashboard from "../Dashboard";
import RegisterForm from "../RegisterForm";

class App extends Component ***REMOVED***
  render() ***REMOVED***
    return (
      <Router>
        <Switch>
          <Route exact path="/">
            <Dashboard />
          </Route>
          <Route path="/register" component=***REMOVED***RegisterForm***REMOVED*** />
        </Switch>
      </Router>
    );
 ***REMOVED***
***REMOVED***

export default App;
