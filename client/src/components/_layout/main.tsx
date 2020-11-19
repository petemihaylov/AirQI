import React from "react";
import ***REMOVED*** Switch, Route***REMOVED*** from "react-router-dom";
import Drawer from "@material-ui/core/Drawer";

/* Styling */
import ***REMOVED*** makeStyles***REMOVED*** from "@material-ui/core/styles";

/* Components */
import Map from "../map/map";
import Register from "../_pages/register";
import Login from "../_pages/login";
import Profile from "../_pages/profile";
import Dashboard from "../_pages/dashboard";
import AdminBoard from "../_pages/admin/adminboard";
import Messages from "../_pages/messages";

const Main = () => ***REMOVED***
  const classes = useStyles();

  /* Routing the components */
  return (
    <main className=***REMOVED***classes.content***REMOVED***>
      <div className=***REMOVED***classes.toolbar***REMOVED*** />

      <Switch>
        <Route exact path="/login" component=***REMOVED***Login***REMOVED*** />
        <Route exact path="/register" component=***REMOVED***Register***REMOVED*** />
        <Route exact path="/profile" component=***REMOVED***Profile***REMOVED*** />
        <Route exact path="/messages" component=***REMOVED***Messages***REMOVED*** />
        <Route path="/user" component=***REMOVED***Drawer***REMOVED*** />
        <Route path="/mod" component=***REMOVED***Drawer***REMOVED*** />
        <Route path="/admin" component=***REMOVED***AdminBoard***REMOVED*** />
        <Route path="/dashboard" component=***REMOVED***Dashboard***REMOVED*** />
        <Route path="/map" component=***REMOVED***Map***REMOVED*** />
      </Switch>
    </main>
  );
***REMOVED***;

export default Main;

const useStyles = makeStyles((theme) => (***REMOVED***
  toolbar: ***REMOVED***
    display: "flex",
    alignItems: "center",
    justifyContent: "flex-end",
    padding: theme.spacing(0, 2),
    // necessary for content to be below app bar
    ...theme.mixins.toolbar,
 ***REMOVED***,
  content: ***REMOVED***
    flexGrow: 1,
    padding: theme.spacing(3),
 ***REMOVED***,
***REMOVED***));
