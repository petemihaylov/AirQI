import React from "react";
import { Switch, Route } from "react-router-dom";

/* Styling */
import { createUseStyles } from "react-jss";
/* Components */
import Map from "../map/map";
import Register from "../_pages/register";
import Login from "../_pages/login";
import Profile from "../_pages/profile";
import Dashboard from "../_pages/dashboard";
import AdminBoard from "../_pages/admin/adminboard";
import Notifications from "../_pages/notifications";
import { WelcomePage } from "../_pages/welcome";

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
