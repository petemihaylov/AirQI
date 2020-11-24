import React, ***REMOVED*** useState, useEffect***REMOVED*** from "react";
import ***REMOVED*** Link***REMOVED*** from "react-router-dom";
import Navigation from "./navbar";

import clsx from "clsx";
import ***REMOVED*** makeStyles***REMOVED*** from "@material-ui/core/styles";
import Drawer from "@material-ui/core/Drawer";
import AppBar from "@material-ui/core/AppBar";
import List from "@material-ui/core/List";
import CssBaseline from "@material-ui/core/CssBaseline";
import Divider from "@material-ui/core/Divider";
import IconButton from "@material-ui/core/IconButton";
import ListItem from "@material-ui/core/ListItem";
import ListItemIcon from "@material-ui/core/ListItemIcon";
import ListItemText from "@material-ui/core/ListItemText";

import ChevronLeftIcon from "@material-ui/icons/ChevronLeft";
import ChevronRightIcon from "@material-ui/icons/ChevronRight";
import NotificationsActive from "@material-ui/icons/NotificationsActive";
import HomeIcon from "@material-ui/icons/Home";
import Person from "@material-ui/icons/Person";

/* Router :: Components */
import ***REMOVED*** connect***REMOVED*** from "react-redux";
import Main from "./main";

/* Style rules of the component */
var navShift = 73;
const drawerWidth = 240;

const NavDrawer = (props: any) => ***REMOVED***
  const classes = useStyles();
  const [open, setOpen] = useState(false);
  const ***REMOVED*** user***REMOVED*** = props;

  useEffect(() => ***REMOVED***
    if (user !== null) navShift = 0;
 ***REMOVED***, []);

  const handleDrawerOpen = () => ***REMOVED***
    setOpen(true);
 ***REMOVED***;

  const handleDrawerClose = () => ***REMOVED***
    setOpen(false);
 ***REMOVED***;

  return (
    <div className=***REMOVED***classes.root***REMOVED***>
      <CssBaseline />

      <AppBar
        position="fixed"
        className=***REMOVED***clsx(classes.appBar, ***REMOVED***
          [classes.appBarShift]: open,
       ***REMOVED***)***REMOVED***
      >
        <Navigation />
      </AppBar>

      ***REMOVED***user ? (
        <Drawer
          variant="permanent"
          className=***REMOVED***clsx(classes.drawer, ***REMOVED***
            [classes.drawerOpen]: open,
            [classes.drawerClose]: !open,
         ***REMOVED***)***REMOVED***
          classes=***REMOVED******REMOVED***
            paper: clsx(***REMOVED***
              [classes.drawerOpen]: open,
              [classes.drawerClose]: !open,
           ***REMOVED***),
         ***REMOVED******REMOVED***
        >
          <div className=***REMOVED***classes.toolbar***REMOVED***>
            ***REMOVED***open === true ? (
              <IconButton onClick=***REMOVED***handleDrawerClose***REMOVED***>
                <ChevronLeftIcon />
              </IconButton>
            ) : (
              <IconButton onClick=***REMOVED***handleDrawerOpen***REMOVED***>
                <ChevronRightIcon />
              </IconButton>
            )***REMOVED***
          </div>
          <List>
            <Link
              to=***REMOVED***"/profile"***REMOVED***
              style=***REMOVED******REMOVED*** textDecoration: "none", color: "gray"***REMOVED******REMOVED***
            >
              <ListItem button key="Account">
                <ListItemIcon>
                  <Person />
                </ListItemIcon>
                <ListItemText primary=***REMOVED***"Account settings"***REMOVED*** />
              </ListItem>
            </Link>

            <Link
              to=***REMOVED***"/Notifications"***REMOVED***
              style=***REMOVED******REMOVED*** textDecoration: "none", color: "gray"***REMOVED******REMOVED***
            >
              <ListItem button key="Notifications">
                <ListItemIcon>
                  <NotificationsActive className=***REMOVED***"blob"***REMOVED*** />
                </ListItemIcon>
                <ListItemText primary=***REMOVED***"Notifications"***REMOVED*** />
              </ListItem>
            </Link>

            <Link
              to=***REMOVED***"/dashboard"***REMOVED***
              style=***REMOVED******REMOVED*** textDecoration: "none", color: "gray", marginTop: "-5px"***REMOVED******REMOVED***
            >
              <ListItem button key="Dashboard">
                <ListItemIcon>
                  <HomeIcon />
                </ListItemIcon>
                <ListItemText primary=***REMOVED***"Dashboard"***REMOVED*** />
              </ListItem>
            </Link>
          </List>
        </Drawer>
      ) : (
        " "
      )***REMOVED***

      <Main />
    </div>
  );
***REMOVED***;

const useStyles = makeStyles((theme) => (***REMOVED***
  root: ***REMOVED***
    display: "flex",
    outline: "none",
    textDecoration: "none",
 ***REMOVED***,
  appBar: ***REMOVED***
    zIndex: theme.zIndex.drawer + 1,
    marginLeft: navShift,
    width: `calc(100% - $***REMOVED***navShift***REMOVED***px)`,
    transition: theme.transitions.create(["width", "margin"], ***REMOVED***
      easing: theme.transitions.easing.sharp,
      duration: theme.transitions.duration.leavingScreen,
   ***REMOVED***),
    background: "#f3f3f3",
    boxShadow: "none",
 ***REMOVED***,
  appBarShift: ***REMOVED***
    marginLeft: drawerWidth,
    width: `calc(100% - $***REMOVED***drawerWidth***REMOVED***px)`,
    transition: theme.transitions.create(["width", "margin"], ***REMOVED***
      easing: theme.transitions.easing.sharp,
      duration: theme.transitions.duration.enteringScreen,
   ***REMOVED***),
 ***REMOVED***,
  hide: ***REMOVED***
    display: "none",
 ***REMOVED***,
  drawer: ***REMOVED***
    width: drawerWidth,
    flexShrink: 0,
    whiteSpace: "nowrap",
 ***REMOVED***,
  drawerOpen: ***REMOVED***
    width: drawerWidth,
    transition: theme.transitions.create("width", ***REMOVED***
      easing: theme.transitions.easing.sharp,
      duration: theme.transitions.duration.enteringScreen,
   ***REMOVED***),
 ***REMOVED***,
  drawerClose: ***REMOVED***
    transition: theme.transitions.create("width", ***REMOVED***
      easing: theme.transitions.easing.sharp,
      duration: theme.transitions.duration.leavingScreen,
   ***REMOVED***),
    overflowX: "hidden",
    width: theme.spacing(7) + 1,
    [theme.breakpoints.up("sm")]: ***REMOVED***
      width: theme.spacing(9) + 1,
   ***REMOVED***,
 ***REMOVED***,
  toolbar: ***REMOVED***
    display: "flex",
    alignItems: "center",
    justifyContent: "flex-end",
    padding: theme.spacing(0, 2),
    // necessary for content to be below app bar
    ...theme.mixins.toolbar,
 ***REMOVED***,
***REMOVED***));

function mapStateToProps(state: any) ***REMOVED***
  const ***REMOVED*** user***REMOVED*** = state.auth;
  return ***REMOVED***
    user,
 ***REMOVED***;
***REMOVED***

export default connect(mapStateToProps)(NavDrawer);
