import React from "react";
import ***REMOVED*** Switch, Route***REMOVED*** from "react-router-dom";

/* Styling */
import ***REMOVED*** createUseStyles***REMOVED*** from "react-jss";
/* Components */
import Map from "../map/map";
import Register from "../pages/register";
import Login from "../pages/login";
import Profile from "../pages/profile";
import Dashboard from "../pages/dashboard";
import AdminBoard from "../pages/admin/adminboard";
import Notifications from "../pages/notifications";
import ***REMOVED*** WelcomePage***REMOVED*** from "../pages/welcome";

const Main = () => ***REMOVED***
  const classes = useStyles();

  /* Routing the components */
  return (
    <main className=***REMOVED***classes.content***REMOVED***>
      <Switch>
        <Route exact path="/login" component=***REMOVED***Login***REMOVED*** />
        <Route exact path="/register" component=***REMOVED***Register***REMOVED*** />
        <Route exact path="/profile" component=***REMOVED***Profile***REMOVED*** />
        <Route exact path="/notifications" component=***REMOVED***Notifications***REMOVED*** />
        <Route path="/user" component=***REMOVED***Dashboard***REMOVED*** />
        <Route path="/mod" component=***REMOVED***Dashboard***REMOVED*** />
        <Route path="/welcome" component=***REMOVED***WelcomePage***REMOVED*** />
        <Route path="/admin" component=***REMOVED***AdminBoard***REMOVED*** />
        <Route path="/dashboard" component=***REMOVED***Dashboard***REMOVED*** />
        <Route path="/map" component=***REMOVED***Map***REMOVED*** />
        <Route path="/" component=***REMOVED***WelcomePage***REMOVED*** />
      </Switch>
    </main>
  );
***REMOVED***;

export default Main;

const useStyles = createUseStyles(***REMOVED***
  content: ***REMOVED***
    flexGrow: 1,
    zIndex: 0,
 ***REMOVED***,
***REMOVED***);
