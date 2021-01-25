import React from "react";
import { Switch, Route } from "react-router-dom";

/* Styling */
import { createUseStyles } from "react-jss";
/* Components */
import Map from "../map/map";
import Register from "../pages/register";
import Login from "../pages/login";
import Profile from "../pages/profile";
import Dashboard from "../pages/dashboard";
import AdminBoard from "../pages/admin/adminboard";
import Notifications from "../pages/notifications";
import { WelcomePage } from "../pages/welcome";

const Main = () => {
  const classes = useStyles();

  /* Routing the components */
  return (
    <main className={classes.content}>
      <Switch>
        <Route exact path="/login" component={Login} />
        <Route exact path="/register" component={Register} />
        <Route exact path="/profile" component={Profile} />
        <Route exact path="/notifications" component={Notifications} />
        <Route path="/user" component={Dashboard} />
        <Route path="/mod" component={Dashboard} />
        <Route path="/welcome" component={WelcomePage} />
        <Route path="/admin" component={AdminBoard} />
        <Route path="/dashboard" component={Dashboard} />
        <Route path="/map" component={Map} />
        <Route path="/" component={WelcomePage} />
      </Switch>
    </main>
  );
};

export default Main;

const useStyles = createUseStyles({
  content: {
    flexGrow: 1,
    zIndex: 0,
  },
});
